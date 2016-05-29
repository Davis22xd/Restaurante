using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestauranteDL;
using System.Data;


namespace RestauranteBL
{
    public class ImpuestoBL
    {
        ImpuestoDL impuesto = new ImpuestoDL();

        public void Insertar(int id, string nombre, double valor, string estado, DateTime fecha)
        {
            impuesto.IdImp = id;
            impuesto.NombreImp = nombre;
            impuesto.ValorImp = valor;
            impuesto.EstadoImp = estado;
            impuesto.FechaImp = fecha;
            impuesto.Insertar();
        }

        public void Actualizar (int id, string nombre, double valor, string estado, DateTime fecha)
        {
            impuesto.IdImp = id;
            impuesto.NombreImp = nombre;
            impuesto.ValorImp = valor;
            impuesto.EstadoImp = estado;
            impuesto.FechaImp = fecha;
            impuesto.Actualizar();
        }

        public void Eliminar(int id)
        {
            impuesto.IdImp = id;
            impuesto.Eliminar();
        }

        public DataSet buscarTodos()
        {
            //return impuesto.buscarTodo();  // 1era forma
            DataSet ds = new DataSet();
            ds = impuesto.buscarTodo();
            return ds;
        }

        public DataSet buscarId( int ID)
        {
            impuesto.IdImp = ID;
            return impuesto.buscarId();  
        }

        
    }
}
