using Examen.Service;

namespace Examen
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
            APIService ApiService= new APIService();
        MainPage = new NavigationPage(new InicioPage(ApiService));
        }
    }
}