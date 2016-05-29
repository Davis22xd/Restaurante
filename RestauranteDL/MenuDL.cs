using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RestauranteDL
{
    public class MenuDL
    {

        int idMenu;

        public int IdMenu
        {
            get { return idMenu; }
            set { idMenu = value; }
        }
        string nombreMenu;

        public string NombreMenu
        {
            get { return nombreMenu; }
            set { nombreMenu = value; }
        }
        string descripcionMenu;

        public string DescripcionMenu
        {
            get { return descripcionMenu; }
            set { descripcionMenu = value; }
        }
        decimal precioMenu;

        public decimal PrecioMenu
        {
            get { return precioMenu; }
            set { precioMenu = value; }
        }
        string disponibilidadMenu;

        public string DisponibilidadMenu
        {
            get { return disponibilidadMenu; }
            set { disponibilidadMenu = value; }
        }
        
        SqlConnection conexion;
        SqlDataAdapter adaptador;
        SqlCommand comando;
        DataSet dsDatos = new DataSet();
        string sentencia;

        public MenuDL()
        {
             conexion = new SqlConnection("Data Source=localhost;Initial Catalog=RestauranteMicrosoft;Integrated Security=True");
        } 

        public void Insertar()
        {
            //try
            //{
                sentencia = "insert into MENU values (" + idMenu + ",'" + nombreMenu + "','" + descripcionMenu + "'," + precioMenu + ",'" + disponibilidadMenu + "')";
                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    if (conexion.State != null)
            //    conexion.Close();
            //    conexion.Dispose();
            //}
        }

        public void Actualizar()
        {
            try
            {
                sentencia = "Update MENU Set NOMBREPLATO ='" + nombreMenu + "',DESCRIPCIONPLATO='" + descripcionMenu + "',PRECIOPLATO =" + precioMenu + ",DISPONIBILIDADPLATO='" + disponibilidadMenu + "' Where IDMENU =" + idMenu;
                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State != null)
                    conexion.Close();
                conexion.Dispose();
            }
        }

        public void Eliminar()
        {
            try
            {
                sentencia = "Delete from MENU Where IDMENU ="+idMenu;

                conexion.Open();
                comando = new SqlCommand (sentencia, conexion);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State != null)
                    conexion.Close();
                conexion.Dispose();
            }
        }

        public DataSet BuscarTodo()
        {
            try
            {
                sentencia = "Select * from MENU";
                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(dsDatos, "MENU");
                
                return dsDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
                conexion.Dispose();
            }
        }

        public DataSet BuscarId()
        {
            try
            {
                sentencia = "Select * from MENU Where IDMENU =" + idMenu;
                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(dsDatos, "MENU");
                
                return dsDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
                conexion.Dispose();
            }
        }
        
        
    
    }
}
