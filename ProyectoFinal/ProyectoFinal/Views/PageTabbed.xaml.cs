using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTabbed : TabbedPage

    {
        public PageTabbed(string correo)
        {
            InitializeComponent();
            var notificacionesPage = new NotificacionesPage(correo);
            var navigationPage = new NavigationPage(notificacionesPage);
            navigationPage.Title = "Notificaciones";
            Children.Add(navigationPage);


        }
    }
}