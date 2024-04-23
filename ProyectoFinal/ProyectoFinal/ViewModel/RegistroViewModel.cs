using ProyectoFinal.Model;
using ProyectoFinal.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModel
{
    public class RegistroViewModel : BaseViewModel
    {
        #region VARIABLES
        string _ID;
        string _Correo;
        string _Contrasena;
        string _ConfirmacionContrasena;
        string _Rol;

        #endregion
        #region CONSTRUCTOR
        public RegistroViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        public RegistroViewModel(INavigation navigation, string rol)
        {
            Navigation = navigation;
            Rol = rol;
        }
        #endregion
        #region OBJETOS
        public string ID
        {
            get { return _ID; }
            set { SetValue(ref _ID, value); }
        }
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
        public string ConfirmacionContrasena
        {
            get { return _ConfirmacionContrasena; }
            set { SetValue(ref _ConfirmacionContrasena, value); }
        }
        public string Rol
        {
            get { return _Rol; }
            set { SetValue(ref _Rol, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Registrar()
        {
            if (Contrasena.Equals(ConfirmacionContrasena))
            {
                if (Rol != null)
                {
                    var parametros = new RegistroModel();
                    parametros.ID = ID;
                    parametros.Correo = Correo;
                    parametros.Contrasena = Contrasena;
                    parametros.Rol = 1;

                    await RegistroRepository.RegistrarUsuario(parametros);
                    await Volver();
                }
                else
                {
                    var parametros = new RegistroModel();
                    parametros.ID = ID;
                    parametros.Correo = Correo;
                    parametros.Contrasena = Contrasena;
                    parametros.Rol = 2;

                    await RegistroRepository.RegistrarUsuario(parametros);
                    await Volver();
                }
            }
            else
            {
                await DisplayAlert("Las contraseñas deben de ser iguales", "", "OK");
            }
        }
        public async Task Volver()
        {
            await Navigation.PushAsync(new PantalladeInicioPage());
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
        public ICommand RegistroCommand => new Command(async () => await Registrar());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand IniciarSesionCommand => new Command(async () => await IniciarSesion());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}