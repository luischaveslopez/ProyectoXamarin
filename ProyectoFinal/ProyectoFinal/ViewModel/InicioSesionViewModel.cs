using ProyectoFinal.Model;
using ProyectoFinal.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModel
{
    public class InicioSesionViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Correo;
        string _Contrasena;

        #endregion
        #region CONSTRUCTOR
        public InicioSesionViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Correo
        {
            get
            {
                return _Correo;
            }
            set { SetValue(ref _Correo, value); }
        }
        public string Contrasena
        {
            get { return _Contrasena; }
            set { SetValue(ref _Contrasena, value); }
        }
        #endregion
        #region PROCESOS
        public async Task IniciarSesion()
        {
            var usuarioInfo = await InicioSesionRepository.IniciarSesion(Correo, Contrasena);

            if (usuarioInfo != null)
            {
                if (usuarioInfo.Rol == "1")
                {
                    await Navigation.PushAsync(new PageTabbedAdmin(usuarioInfo.Rol));
                }
                else if (usuarioInfo.Rol == "2")
                {
                    await Navigation.PushAsync(new PageTabbed(Correo));
                }
                else
                {
                    // El rol no está definido correctamente
                    await DisplayAlert("Error", "El rol del usuario no está definido correctamente.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Usuario y/o contraseña incorrectas", "", "OK");
            }
        }
        public async Task Volver()
        {
            await Navigation.PushAsync(new PantalladeInicioPage());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand IniciarSesionCommand => new Command(async () => await IniciarSesion());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}