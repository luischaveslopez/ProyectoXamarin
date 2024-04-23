using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Model
{
    public class ProyectoRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://proyectofinal-3a693-default-rtdb.firebaseio.com/");

        public async Task<bool> Save(Proyecto proyecto)
        {
            var data = await firebaseClient.Child(nameof(Proyecto)).PostAsync(JsonConvert.SerializeObject(proyecto));

            if (!string.IsNullOrEmpty(data.Key)) return true;

            return false;
        }

        public async Task<List<Proyecto>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Proyecto)).OnceAsync<Proyecto>()).Select(item => new Proyecto
            {
                Name= item.Object.Name,
                Asunto = item.Object.Asunto,
                Fecha = item.Object.Fecha,
                Hora = item.Object.Hora,
                Ubicacion = item.Object.Ubicacion,
                Categoria = item.Object.Categoria,
                Impacto = item.Object.Impacto,
                Prioridad = item.Object.Prioridad,
                Descripcion = item.Object.Descripcion
            }).ToList();
        }

        public async Task<Proyecto> GetById(string id)
        {
            return (await firebaseClient.Child(nameof(Proyecto) + "/" + id).OnceSingleAsync<Proyecto>());
        }

        public async Task<bool> Update(Proyecto proyecto)
        {
            await firebaseClient.Child(nameof(Proyecto) + "/" + proyecto.Id).PutAsync(JsonConvert.SerializeObject(proyecto));
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Proyecto) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
