using ProyectoFinal.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PantalladeInicioPage : ContentPage
    {
        public PantalladeInicioPage()
        {
            InitializeComponent();
            BindingContext = new PantalladeInicioViewModel(Navigation);
        }
    }
}