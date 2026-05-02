using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;

namespace WinFormUI
{
    public partial class MainForm : Form
    {
        private DataGridView dataGridView;
        private BindingSource bindingSource;
        private BindingList<Note> notes;

        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Button saveJsonButton;
        private Button loadJsonButton;
        private Button saveXmlButton;
        private Button loadXmlButton;

        public MainForm()
        {
            InitializeComponent();

            notes = new BindingList<Note>();
            bindingSource = new BindingSource();

            InitializeControls();
            LoadTestData();
        }

        private void InitializeControls()
        {
            Text = "Notes Manager";
            Width = 900;
            Height = 500;
            StartPosition = FormStartPosition.CenterScreen;

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Top;
            panel.Height = 50;
            panel.Padding = new Padding(10);

            addButton = new Button { Text = "Додати", Width = 90 };
            editButton = new Button { Text = "Редагувати", Width = 100 };
            deleteButton = new Button { Text = "Видалити", Width = 90 };
            saveJsonButton = new Button { Text = "Зберегти JSON", Width = 120 };
            loadJsonButton = new Button { Text = "Завантажити JSON", Width = 140 };
            saveXmlButton = new Button { Text = "Зберегти XML", Width = 120 };
            loadXmlButton = new Button { Text = "Завантажити XML", Width = 140 };

            addButton.Click += AddButton_Click;
            editButton.Click += EditButton_Click;
            deleteButton.Click += DeleteButton_Click;
            saveJsonButton.Click += SaveJsonButton_Click;
            loadJsonButton.Click += LoadJsonButton_Click;
            saveXmlButton.Click += SaveXmlButton_Click;
            loadXmlButton.Click += LoadXmlButton_Click;

            panel.Controls.Add(addButton);
            panel.Controls.Add(editButton);
            panel.Controls.Add(deleteButton);
            panel.Controls.Add(saveJsonButton);
            panel.Controls.Add(loadJsonButton);
            panel.Controls.Add(saveXmlButton);
            panel.Controls.Add(loadXmlButton);

            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource.DataSource = notes;
            dataGridView.DataSource = bindingSource;

            Controls.Add(dataGridView);
            Controls.Add(panel);
        }

        private void LoadTestData()
        {
            notes.Add(new Note
            {
                Title = "Lab 6",
                Content = "Windows Forms GUI",
                CreatedDate = DateTime.Now
            });

            notes.Add(new Note
            {
                Title = "JSON",
                Content = "Saving and loading notes",
                CreatedDate = DateTime.Now.AddDays(-1)
            });

            notes.Add(new Note
            {
                Title = "XML",
                Content = "Export recent notes",
                CreatedDate = DateTime.Now.AddDays(-3)
            });
        }

        private Note GetSelectedNote()
        {
            return bindingSource.Current as Note;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (NoteEditForm form = new NoteEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    notes.Add(form.Note);
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Note selected = GetSelectedNote();

            if (selected == null)
            {
                MessageBox.Show("Оберіть нотатку для редагування.");
                return;
            }

            using (NoteEditForm form = new NoteEditForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bindingSource.ResetBindings(false);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Note selected = GetSelectedNote();

            if (selected == null)
            {
                MessageBox.Show("Оберіть нотатку для видалення.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Ви дійсно хочете видалити цю нотатку?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                notes.Remove(selected);
            }
        }

        private void SaveJsonButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "JSON files (*.json)|*.json";
                dialog.DefaultExt = "json";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    NoteJsonStorage.SaveToJson(notes.ToList(), dialog.FileName);
                    MessageBox.Show("Дані збережено у JSON.");
                }
            }
        }

        private void LoadJsonButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON files (*.json)|*.json";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var loadedNotes = NoteJsonStorage.LoadFromJson(dialog.FileName);

                    notes = new BindingList<Note>(loadedNotes);
                    bindingSource.DataSource = notes;
                    dataGridView.DataSource = bindingSource;

                    MessageBox.Show("Дані завантажено з JSON.");
                }
            }
        }

        private void SaveXmlButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "XML files (*.xml)|*.xml";
                dialog.DefaultExt = "xml";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    NoteXmlExporter.ExportRecentNotes(notes.ToList(), dialog.FileName);
                    MessageBox.Show("Дані збережено у XML.");
                }
            }
        }

        private void LoadXmlButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "XML files (*.xml)|*.xml";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var loadedNotes = NoteXmlExporter.LoadFromXml(dialog.FileName);

                    notes = new BindingList<Note>(loadedNotes);
                    bindingSource.DataSource = notes;
                    dataGridView.DataSource = bindingSource;

                    MessageBox.Show("Дані завантажено з XML.");
                }
            }
        }
    }
}