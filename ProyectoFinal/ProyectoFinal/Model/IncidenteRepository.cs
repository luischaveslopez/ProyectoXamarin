using Firebase.Database.Query;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace ProyectoFinal.Model
{
    public class IncidenteRepository
    {
        public static async Task AgregarIncidente(IncidenteModel incidente)
        {
            try
            {
                await Conexion.firebase
                    .Child("Incidentes")
                    .PostAsync(incidente);

                Console.WriteLine("Incidente agregado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al agregar el incidente: {ex.Message}");
            }
        }

        public static async Task ModificarIncidente(string incidenteId, IncidenteModel incidente)
        {
            try
            {
                await Conexion.firebase
                    .Child("Incidentes")
                    .Child(incidenteId)
                    .PutAsync(incidente);

                Console.WriteLine("Incidente modificado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al modificar el incidente: {ex.Message}");
            }
        }

        public static async Task<ObservableCollection<IncidenteModel>> ObtenerIncidentes()
        {
            try
            {
                var incidentes = await Conexion.firebase
                    .Child("Incidentes")
                    .OnceAsync<IncidenteModel>();

                var listaIncidentes = incidentes.Select(item => new IncidenteModel
                {
                    Id = item.Key,
                    Nombre = item.Object.Nombre,
                    Asunto = item.Object.Asunto,
                    Fecha = item.Object.Fecha,
                    Hora = item.Object.Hora,
                    Ubicacion = item.Object.Ubicacion,
                    Categoria = item.Object.Categoria,
                    Impacto = item.Object.Impacto,
                    Prioridad = item.Object.Prioridad,
                    Descripcion = item.Object.Descripcion
                }).ToList();

                return new ObservableCollection<IncidenteModel>(listaIncidentes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al obtener los incidentes: {ex.Message}");
                return null;
            }
        }

        public static async Task<ObservableCollection<IncidenteModel>> FiltrarIncidentesPorNombre(string nombre)
        {
            try
            {
                var incidentes = await Conexion.firebase
                    .Child("Incidentes")
                    .OnceAsync<IncidenteModel>();

                var incidentesFiltrados = incidentes
                    .Where(item => item.Object.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    .Select(item => new IncidenteModel
                    {
                        Id = item.Key,
                        Nombre = item.Object.Nombre,
                        Asunto = item.Object.Asunto,
                        Fecha = item.Object.Fecha,
                        Hora = item.Object.Hora,
                        Ubicacion = item.Object.Ubicacion,
                        Categoria = item.Object.Categoria,
                        Impacto = item.Object.Impacto,
                        Prioridad = item.Object.Prioridad,
                        Descripcion = item.Object.Descripcion
                    }).ToList();

                return new ObservableCollection<IncidenteModel>(incidentesFiltrados);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al filtrar los incidentes por nombre: {ex.Message}");
                return null;
            }
        }
    }
}