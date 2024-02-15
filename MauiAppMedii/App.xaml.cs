using MauiAppMedii.Data;
namespace MauiAppMedii
{
    public partial class App : Application
    {
        static EventsTrakerDatabase? database;
        internal static EventsTrakerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new EventsTrakerDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EventsTraker.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
