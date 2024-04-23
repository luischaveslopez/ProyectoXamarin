using ProyectoFinal.View_Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificacionesPage : ContentPage
    {
        public NotificacionesPage(string correo)
        {
            InitializeComponent();
            BindingContext = new NotificacionesViewModel(Navigation, correo);
        }
    }
}