using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RestauranteDL
{
    public class ImpuestoDL
    {
        SqlConnection conexion;
        SqlDataAdapter adaptador; //Obj que permite realizar el puente hacia la bdd
        SqlCommand comando;//parametriza todo el query, o store procedures
        DataSet dsDatos = new DataSet();// dataset sin tipo sirve para colocar todos los registros que traiga de la bdd q consulte
        string sentencia;
       

        public ImpuestoDL() {
            conexion = new SqlConnection("Data Source=localhost;Initial Catalog=RestauranteMicrosoft;Integrated Security=True");
        }


        public void Insertar()
        {
            try
            {
                sentencia = "Insert into IMPUESTO values (" + idImp + ",'" + nombreImp + "'," + valorImp + ",'" + estadoImp + "','" + fechaImp + "')";
                // Insert into Impuesto values (3,'pepe', 0.15, 'A', '2013-10-14')

                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                conexion.Close();
                Console.WriteLine("Exito en la Operacion");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error en la Operacion" + "\n" + ex.Message);
                throw ex;

            }
            finally
            {
                if (conexion.State != null)
                    conexion.Close();
            }
        }

        public void Actualizar()
        {
            try
            {
                sentencia = "Update IMPUESTO Set NOMBREIMPUESTO ='" + nombreImp + "', VALORIMPUESTO = " + valorImp + ", ESTADOIMPUESTO = '" + estadoImp + "', FECHAIMP = '" + fechaImp + "' Where IDIMPUESTO =" + idImp;
                //   Update IMPUESTO Set ESTADOIMPUESTO = 'D', NOMBREIMPUESTO = 'lENNIN' Where IDIMPUESTO = 10;

                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                conexion.Close();
                Console.WriteLine("Exito en la Operacion");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error en la Operacion" + "\n" + ex.Message);
                throw ex;

            }
            finally
            {
                if (conexion.State != null)
                    conexion.Close();
            }
        }

        public void Eliminar()
        {
            try
            {
                sentencia = "Delete FROM IMPUESTO Where IDIMPUESTO =" + idImp;
                //  DELETE FROM customer WHERE country = "USA";

                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                comando.Dispose();

                Console.WriteLine("Exito en la Operacion");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error en la Operacion" + "\n" + ex.Message);
                throw ex;

            }
            finally
            {
                if (conexion.State != null)
                    conexion.Close();
            }
        }

        public DataSet buscarTodo()
        {
            try
            {
                sentencia = "Select * from IMPUESTO";
                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(dsDatos, "IMPUESTO");
                return dsDatos;
                Console.WriteLine("Exito en la Operacion");
            }


            catch (Exception ex)
            {
                //Console.WriteLine("Error en la Operacion" + "\n" + ex.Message);
                throw ex;

            }
            finally
            {
                if (conexion.State != null)
                    conexion.Close();
            }
        }

        public DataSet buscarId()
        {
            try
            {
                sentencia = "Select * from IMPUESTO where IdImpuesto =" + idImp;
                conexion.Open();
                comando = new SqlCommand(sentencia, conexion);
                adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(dsDatos, "IMPUESTO");
                return dsDatos;
                Console.WriteLine("Exito en la Operacion");
            }


            catch (Exception ex)
            {
                //Console.WriteLine("Error en la Operacion" + "\n" + ex.Message);
                throw ex;

            }
            finally
            {
                if (conexion.State != null)
                    conexion.Close();
            }
        }
       
        int idImp;
        public int IdImp
        {
            get { return idImp; }
            set { idImp = value; }
        }
        string nombreImp;

        public string NombreImp
        {
            get { return nombreImp; }
            set { nombreImp = value; }
        }
        double valorImp;

        public double ValorImp
        {
            get { return valorImp; }
            set { valorImp = value; }
        }
        string estadoImp;

        public string EstadoImp
        {
            get { return estadoImp; }
            set { estadoImp = value; }
        }
        DateTime fechaImp;

        public DateTime FechaImp
        {
            get { return fechaImp; }
            set { fechaImp = value; }
        }
    }
}
