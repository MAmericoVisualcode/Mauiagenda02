namespace Mauiagenda02
{
    public partial class App : Application
    {
        static Properties.Helpers.SQLiteDatabaseHelper _db;

        public static Properties.Helpers.SQLiteDatabaseHelper Db // Corrigido para public static
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new Properties.Helpers.SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Resources.Views.ListaProduto());
        }
    }
}