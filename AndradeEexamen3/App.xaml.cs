using AndradeEexamen3.Services;

namespace AndradeEexamen3
{
    public partial class App : Application
    {
        public static VehiculoDatabase VehiculoDB { get; private set; }

        public App(VehiculoDatabase db)
        {
            InitializeComponent();
            VehiculoDB = db;
            MainPage = new AppShell();
        }
    }
}
