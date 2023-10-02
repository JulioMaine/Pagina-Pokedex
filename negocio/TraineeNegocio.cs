using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TraineeNegocio
    {
        public int InsertarNuevo(Trainee nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
            
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Password);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool login (Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, email, pass, admin, imagenPerfil, nombre, apellido from USERS where email = @email and pass = @pass");
                datos.setearParametro("@email", trainee.Email);
                datos.setearParametro("@pass", trainee.Password);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["id"];
                    trainee.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["imagenPerfil"] is DBNull))
                        trainee.Imagen = (string)datos.Lector["imagenPerfil"];
                    trainee.Nombre = (string)datos.Lector["nombre"];
                    trainee.Apellido = (string)datos.Lector["apellido"];
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizar(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update users set imagenPerfil = @imagenPerfil, nombre = @nombre, apellido = @apellido where id = @Id");
                datos.setearParametro("@imagenPerfil", trainee.Imagen);
                datos.setearParametro("@nombre", trainee.Nombre);
                datos.setearParametro("@apellido", trainee.Apellido);
                datos.setearParametro("@Id", trainee.Id);
                datos.ejecutarAccion();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
