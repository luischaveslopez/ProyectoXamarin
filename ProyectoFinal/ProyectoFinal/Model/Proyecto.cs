using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoFinal.Model
{
    public class Proyecto : INotifyPropertyChanged
    {
        public string id;
        public string name;
        public string asunto;
        public DateTime fecha;
        public TimeSpan hora;
        public string ubicacion;
        public string categoria;
        public string impacto;
        public string prioridad;
        public string descripcion;
        

        public string Id
        {
            get => id;
            set 
            { 
                id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => name; 
            set 
            { 
                name = value;
                OnPropertyChanged();
            }
        }

        public string Asunto
        {
            get => asunto;
            set
            {
                asunto = value;
                OnPropertyChanged();
            }
        }

        public DateTime Fecha
        {
            get => fecha;
            set
            {
                fecha = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Hora
        {
            get => hora;
            set
            {
                hora = value;
                OnPropertyChanged();
            }
        }

        public string Ubicacion
        {
            get => ubicacion;
            set
            {
                ubicacion = value;
                OnPropertyChanged();
            }
        }

        public string Categoria
        {
            get => categoria;
            set
            {
                categoria = value;
                OnPropertyChanged();
            }
        }

        public string Impacto
        {
            get => impacto;
            set
            {
                impacto = value;
                OnPropertyChanged();
            }
        }

        public string Prioridad
        {
            get => prioridad;
            set
            {
                prioridad = value;
                OnPropertyChanged();
            }
        }

        public string Descripcion
        {
            get => descripcion;
            set
            {
                descripcion = value;
                OnPropertyChanged();
            }
        }

        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para invocar el evento PropertyChanged
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
