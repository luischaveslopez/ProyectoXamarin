using System.Threading.Tasks;
using System;
using Firebase.Database.Query;
using System.Linq;

namespace ProyectoFinal.Model
{
    public class InicioSesionRepository
    {
        public static async Task<UsuarioInfo> IniciarSesion(string correo, string contrasena)
        {
            try
            {
                var snapshot = await Conexion.firebase
                    .Child("Usuarios")
                    .OrderBy("Correo")
                    .EqualTo(correo)
                    .OnceAsync<InicioSesionModel>();

                if (snapshot.Count == 0)
                {
                    Console.WriteLine("Usuario no encontrado.");
                    return null;
                }

                var usuario = snapshot.First().Object;

                if (usuario.Contrasena != contrasena)
                {
                    Console.WriteLine("Contraseña incorrecta.");
                    return null;
                }

                Console.WriteLine($"Inicio de sesión exitoso para el usuario: {correo}");
                return new UsuarioInfo { Correo = correo, Rol = usuario.Rol.ToString() };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al iniciar sesión: {ex.Message}");
                return null;
            }
        }
    }
}