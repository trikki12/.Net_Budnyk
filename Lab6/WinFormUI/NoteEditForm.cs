using System;
using System.Windows.Forms;
using Core;

namespace WinFormUI
{
    public partial class NoteEditForm : Form
    {
        private TextBox titleTextBox = null!;
        private TextBox contentTextBox = null!;
        private DateTimePicker createdDatePicker = null!;
        private Button saveButton = null!;
        private Button cancelButton = null!;

        public Note Note { get; private set; }

        public NoteEditForm()
            : this(new Note { CreatedDate = DateTime.Now })
        {
        }

        public NoteEditForm(Note note)
        {
            InitializeComponent();

            Note = note;

            InitializeControls();

            titleTextBox.Text = Note.Title;
            contentTextBox.Text = Note.Content;
            createdDatePicker.Value = Note.CreatedDate == default ? DateTime.Now : Note.CreatedDate;
        }

        private void InitializeControls()
        {
            Text = "Редагування нотатки";
            Width = 420;
            Height = 280;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.Padding = new Padding(10);
            layout.RowCount = 4;
            layout.ColumnCount = 2;

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            titleTextBox = new TextBox();
            titleTextBox.Dock = DockStyle.Fill;

            contentTextBox = new TextBox();
            contentTextBox.Dock = DockStyle.Fill;
            contentTextBox.Multiline = true;
            contentTextBox.Height = 70;

            createdDatePicker = new DateTimePicker();
            createdDatePicker.Dock = DockStyle.Fill;
            createdDatePicker.Format = DateTimePickerFormat.Short;

            saveButton = new Button();
            saveButton.Text = "Зберегти";
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button();
            cancelButton.Text = "Скасувати";
            cancelButton.Click += (s, e) => Close();

            FlowLayoutPanel buttonsPanel = new FlowLayoutPanel();
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Controls.Add(cancelButton);

            layout.Controls.Add(new Label { Text = "Назва:", AutoSize = true }, 0, 0);
            layout.Controls.Add(titleTextBox, 1, 0);

            layout.Controls.Add(new Label { Text = "Текст:", AutoSize = true }, 0, 1);
            layout.Controls.Add(contentTextBox, 1, 1);

            layout.Controls.Add(new Label { Text = "Дата:", AutoSize = true }, 0, 2);
            layout.Controls.Add(createdDatePicker, 1, 2);

            layout.Controls.Add(buttonsPanel, 1, 3);

            Controls.Add(layout);
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Введіть назву нотатки.");
                return;
            }

            Note.Title = titleTextBox.Text.Trim();
            Note.Content = contentTextBox.Text.Trim();
            Note.CreatedDate = createdDatePicker.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}