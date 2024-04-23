using ProyectoFinal.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioSesionPage : ContentPage
    {
        public InicioSesionPage()
        {
            InitializeComponent();
            BindingContext = new InicioSesionViewModel(Navigation);
        }
    }
}