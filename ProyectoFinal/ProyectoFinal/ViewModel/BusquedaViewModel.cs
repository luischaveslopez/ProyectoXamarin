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
    public class BusquedaViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Asunto;
        DateTime _Fecha;
        string _FechaActual;
        string _ResultadoFecha;
        public ObservableCollection<IncidenteModel> _Resultados;
        string _Categoria;

        #endregion
        #region CONSTRUCTOR
        public BusquedaViewModel(INavigation navigation)
        {
            Navigation = navigation;
            FechaActual = DateTime.Now.ToString("yyyy/MM/dd");
            Fecha = DateTime.Now;
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
        #endregion
        #region PROCESOS
        public async Task BuscarIncidentes()
        {
            try
            {
                var todosIncidentes = await IncidenteRepository.ObtenerIncidentes();

                var resultadosFiltrados = todosIncidentes.Where(incidente =>
                    (string.IsNullOrEmpty(Asunto) || incidente.Asunto.ToLower().Contains(Asunto.ToLower())) &&
                    (string.IsNullOrEmpty(Categoria) || incidente.Categoria.ToLower() == Categoria.ToLower()) &&
                    (incidente.Fecha == ResultadoFecha || ResultadoFecha == incidente.Fecha));
                Console.WriteLine(resultadosFiltrados);
                Resultados = new ObservableCollection<IncidenteModel>(resultadosFiltrados);
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