namespace AndradeEexamen3
{
    public partial class App : Application
    {
        public static Services.VehiculoDatabase VehiculoDB { get; private set; }

        public App(Services.VehiculoDatabase db)
        {
            InitializeComponent();
            VehiculoDB = db;
            MainPage = new AppShell();
        }
    }
}
