using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTabbedAdmin : TabbedPage
    {
        public PageTabbedAdmin(string rol)
        {
            InitializeComponent();
            var registroPage = new RegistroPage(rol);
            var navigationPage = new NavigationPage(registroPage);
            navigationPage.Title = "Crear Usuario";
            Children.Add(navigationPage);
        }
    }
}