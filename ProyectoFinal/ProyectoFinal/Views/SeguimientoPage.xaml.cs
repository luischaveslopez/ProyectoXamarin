using ProyectoFinal.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeguimientoPage : ContentPage
    {
        public SeguimientoPage()
        {
            InitializeComponent();
            BindingContext = new SeguimientoViewModel(Navigation);
        }
    }
}