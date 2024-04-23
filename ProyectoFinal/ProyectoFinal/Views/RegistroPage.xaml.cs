using ProyectoFinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
            BindingContext = new RegistroViewModel(Navigation);
        }

        public RegistroPage(string rol)
        {
            InitializeComponent();
            BindingContext = new RegistroViewModel(Navigation, rol);
        }
    }
}