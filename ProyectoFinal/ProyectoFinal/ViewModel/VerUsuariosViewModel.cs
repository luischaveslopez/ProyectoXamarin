using ProyectoFinal.Model;
using ProyectoFinal.ViewModel;
using ProyectoFinal.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinal.View_Model
{
    public class VerUsuariosViewModel : BaseViewModel
    {
        #region VARIABLES
        public ObservableCollection<RegistroModel> _Resultados;

        #endregion
        #region CONSTRUCTOR
        public VerUsuariosViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BuscarIncidentes();
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<RegistroModel> Resultados
        {
            get { return _Resultados; }
            set
            {
                SetValue(ref _Resultados, value);
                OnPropertyChanged();
            }
        }
        #endregion
        #region PROCESOS
        public async Task BuscarIncidentes()
        {
            try
            {
                var todosIncidentes = await RegistroRepository.ObtenerUsuarios();

                Resultados = new ObservableCollection<RegistroModel>(todosIncidentes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al buscar incidentes: {ex.Message}");
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
        public ICommand BuscarCommand => new Command(async () => await BuscarIncidentes());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}