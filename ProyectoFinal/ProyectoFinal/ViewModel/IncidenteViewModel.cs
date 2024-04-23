using ProyectoFinal.Model;
using ProyectoFinal.ViewModel;
using ProyectoFinal.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinal.View_Model
{
    public class IncidenteViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Nombre;
        string _Asunto;
        DateTime _Fecha;
        string _FechaActual;
        string _ResultadoFecha;
        DateTime _Hora;
        string _HoraActual;
        string _ResultadoHora;
        string _Ubicacion;
        string _Categoria;
        string _Impacto;
        string _Prioridad;
        string _Descripcion;

        #endregion
        #region CONSTRUCTOR
        public IncidenteViewModel(INavigation navigation)
        {
            Navigation = navigation;
            FechaActual = DateTime.Now.ToString("yyyy/MM/dd");
            Fecha = DateTime.Now;
            HoraActual = DateTime.Now.ToString("hh:mm");
            Hora = DateTime.Now;
        }
        #endregion
        #region OBJETOS
        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }
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
        public string ResultadoHora
        {
            get { return _ResultadoHora; }
            set { SetValue(ref _ResultadoHora, value); }
        }
        public string HoraActual
        {
            get { return _HoraActual; }
            set { SetValue(ref _HoraActual, value); }
        }

        public DateTime Hora
        {
            get { return _Hora; }
            set
            {
                SetValue(ref _Hora, value);
                ResultadoHora = _Hora.ToString("hh:mm");
            }
        }
        public string Ubicacion
        {
            get
            {
                return _Ubicacion;
            }
            set { SetValue(ref _Ubicacion, value); }
        }
        public string Categoria
        {
            get
            {
                return _Categoria;
            }
            set { SetValue(ref _Categoria, value); }
        }
        public string Impacto
        {
            get
            {
                return _Impacto;
            }
            set { SetValue(ref _Impacto, value); }
        }
        public string Prioridad
        {
            get
            {
                return _Prioridad;
            }
            set { SetValue(ref _Prioridad, value); }
        }
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set { SetValue(ref _Descripcion, value); }
        }
        #endregion
        #region PROCESOS
        public async Task CrearIncidente()
        {
            var incidente = new IncidenteModel();
            incidente.Nombre = Nombre;
            incidente.Asunto = Asunto;
            incidente.Fecha = ResultadoFecha;
            incidente.Hora = ResultadoHora;
            incidente.Ubicacion = Ubicacion;
            incidente.Categoria = Categoria;
            incidente.Impacto = Impacto;
            incidente.Prioridad = Prioridad;
            incidente.Descripcion = Descripcion;

            await IncidenteRepository.AgregarIncidente(incidente);
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
        public ICommand GuardarCommand => new Command(async () => await CrearIncidente());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}