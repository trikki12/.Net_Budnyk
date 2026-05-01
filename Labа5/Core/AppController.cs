namespace Core
{
    public class AppController
    {
        private Configuration config;

        public AppController()
        {
            config = new Configuration(); // Компохиція
        }

        public void ShowAppInfo()
        {
            System.Console.WriteLine($"App: {config.AppName}");
        }
    }
}