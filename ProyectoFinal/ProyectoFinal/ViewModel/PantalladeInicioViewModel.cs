using ProyectoFinal.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModel
{
    public class PantalladeInicioViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public PantalladeInicioViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Registrarse()
        {
            await Navigation.PushAsync(new RegistroPage());
        }
        public async Task IniciarSesion()
        {
            await Navigation.PushAsync(new InicioSesionPage());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand RegistrarseCommand => new Command(async () => await Registrarse());
        public ICommand IniciarSesionCommand => new Command(async () => await IniciarSesion());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}