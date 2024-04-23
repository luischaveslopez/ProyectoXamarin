using ProyectoFinal.View_Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncidentePage : ContentPage
	{
		public IncidentePage ()
		{
			InitializeComponent ();
            BindingContext = new IncidenteViewModel(Navigation);
        }
        
    }
}