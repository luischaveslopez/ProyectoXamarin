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
    public class NotificacionesViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Asunto;
        DateTime _Fecha;
        string _FechaActual;
        string _ResultadoFecha;
        public ObservableCollection<IncidenteModel> _Resultados;
        string _Categoria;
        string _Correo;

        #endregion
        #region CONSTRUCTOR
        public NotificacionesViewModel(INavigation navigation, string correo)
        {
            Navigation = navigation;
            FechaActual = DateTime.Now.ToString("yyyy/MM/dd");
            Fecha = DateTime.Now;
            Correo = correo;
            Asunto = Correo;
            Console.WriteLine(Correo);
            ConsultarIncidentesPeriodicamente();
        }
        #endregion
        #region OBJETOS
        public string Asunto
        {
            get
            {
                return _Asunto;
            }
            set { SetValue(ref _Asunto, value); }
        }
        public string ResultadoFecha
        {
            get { return _ResultadoFecha; }
            set { SetValue(ref _ResultadoFecha, value); }
        }
        public string FechaActual
        {
            get { return _FechaActual; }
            set { SetValue(ref _FechaActual, value); }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set
            {
                SetValue(ref _Fecha, value);
                ResultadoFecha = _Fecha.ToString("yyyy/MM/dd");
            }
        }
        public string Categoria
        {
            get
            {
                return _Categoria;
            }
            set { SetValue(ref _Categoria, value); }
        }
        public ObservableCollection<IncidenteModel> Resultados
        {
            get { return _Resultados; }
            set
            {
                SetValue(ref _Resultados, value);
                OnPropertyChanged();
            }
        }
        public string Correo
        {
            get { return _Correo; }
            set { SetValue(ref _Correo, value); }
        }
        #endregion
        #region PROCESOS
        public async Task BuscarIncidentes()
        {
            try
            {
                if (string.IsNullOrEmpty(Correo))
                {
                    Console.WriteLine("El correo no puede estar vacío.");
                    return;
                }

                var incidentesFiltrados = await IncidenteRepository.FiltrarIncidentesPorNombre(Correo);

                if (incidentesFiltrados != null)
                {
                    Resultados = incidentesFiltrados;
                }
                else
                {
                    Console.WriteLine("La lista de incidentes filtrados es nula.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al buscar incidentes: {ex.Message}");
            }
        }

        private async Task ConsultarIncidentesPeriodicamente()
        {
            while (true)
            {
                await Task.Delay(5000);
                await BuscarIncidentes();
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
