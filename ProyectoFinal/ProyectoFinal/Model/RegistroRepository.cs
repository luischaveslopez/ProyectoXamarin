using Firebase.Database.Query;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProyectoFinal.Model
{
    public class RegistroRepository
    {
        public static async Task RegistrarUsuario(RegistroModel parametros)
        {
            try
            {
                await Conexion.firebase
                    .Child("Usuarios")
                    .Child(parametros.ID)
                    .PutAsync(parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al registrar el usuario: {ex.Message}");
            }
        }

        public static async Task<ObservableCollection<RegistroModel>> ObtenerUsuarios()
        {
            try
            {
                var snapshot = await Conexion.firebase
                    .Child("Usuarios")
                    .OnceAsync<RegistroModel>();

                var usuarios = new ObservableCollection<RegistroModel>();

                foreach (var item in snapshot)
                {
                    usuarios.Add(item.Object);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al obtener los usuarios: {ex.Message}");
                return null;
            }
        }

        public static async Task ModificarUsuario(string id, RegistroModel parametros)
        {
            try
            {
                await Conexion.firebase
                    .Child("Usuarios")
                    .Child(id)
                    .PutAsync(parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al modificar el usuario: {ex.Message}");
            }
        }

        public static async Task EliminarUsuario(string id)
        {
            try
            {
                await Conexion.firebase
                    .Child("Usuarios")
                    .Child(id)
                    .DeleteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al eliminar el usuario: {ex.Message}");
            }
        }
    }
}