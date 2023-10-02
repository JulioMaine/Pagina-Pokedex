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
                datos.setearConsulta("select id, email, pass, admin, imagenPerfil, nombre, apellido, fechaNacimiento from USERS where email = @email and pass = @pass");
                datos.setearParametro("@email", trainee.Email);
                datos.setearParametro("@pass", trainee.Password);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["id"];
                    trainee.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["imagenPerfil"] is DBNull))
                        trainee.Imagen = (string)datos.Lector["imagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        trainee.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        trainee.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["fechaNacimiento"] is DBNull))
                        trainee.FechaNacimiento = (DateTime)datos.Lector["fechaNacimiento"];
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
                datos.setearConsulta("update users set imagenPerfil = @imagenPerfil, nombre = @nombre, apellido = @apellido, fechaNacimiento = @fecha where id = @Id");
                datos.setearParametro("@imagenPerfil", (object)trainee.Imagen ?? DBNull.Value);
                datos.setearParametro("@nombre", trainee.Nombre);
                datos.setearParametro("@apellido", trainee.Apellido);
                datos.setearParametro("@fecha", trainee.FechaNacimiento);
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
