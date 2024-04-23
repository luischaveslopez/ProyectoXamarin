using ProyectoFinal.Model;
using ProyectoFinal.ViewModel;
using ProyectoFinal.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinal.View_Model
{
    public class SeguimientoViewModel : BaseViewModel
    {
        #region VARIABLES
        ObservableCollection<IncidenteModel> _incidentes;
        IncidenteModel _incidenteSeleccionado;
        string _estadoSeleccionado;

        #endregion
        #region CONSTRUCTOR
        public SeguimientoViewModel(INavigation navigation)
        {
            Navigation = navigation;
            CargarIncidentes();
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<IncidenteModel> Incidentes
        {
            get { return _incidentes; }
            set { SetProperty(ref _incidentes, value); }
        }

        public IncidenteModel IncidenteSeleccionado
        {
            get { return _incidenteSeleccionado; }
            set { SetProperty(ref _incidenteSeleccionado, value); }
        }

        public string EstadoSeleccionado
        {
            get { return _estadoSeleccionado; }
            set { SetProperty(ref _estadoSeleccionado, value); }
        }
        #endregion
        #region PROCESOS
        public async Task CargarIncidentes()
        {
            try
            {
                var incidentes = await IncidenteRepository.ObtenerIncidentes();
                Incidentes = new ObservableCollection<IncidenteModel>(incidentes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al cargar los incidentes: {ex.Message}");
            }
        }

        public async Task ActualizarEstado()
        {
            if (IncidenteSeleccionado != null)
            {
                IncidenteSeleccionado.Estado = EstadoSeleccionado;
                await IncidenteRepository.ModificarIncidente(IncidenteSeleccionado.Id, IncidenteSeleccionado);
                // Aquí puedes agregar la lógica adicional después de actualizar el estado del incidente
            }
            else
            {
                Console.WriteLine("No se ha seleccionado ningún incidente.");
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
        public ICommand ActualizarEstadoCommand => new Command(async () => await ActualizarEstado());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}