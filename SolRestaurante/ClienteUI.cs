using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestauranteBL;

namespace SolRestaurante
{
    public partial class ClienteUI : Form
    {
        //ClienteBL cliente = new ClienteBL();
        string genero;

        public ClienteUI()
        {
            InitializeComponent();
        }
        private void btnGurdar_Click(object sender, EventArgs e)
        {
            try 
            {
                ClienteBL cliente = new ClienteBL();
                if (cmbGenero.Text.Equals("Masculino"))
                    genero = "M"; 
                else
                    genero = "F";

                cliente.Insertar(Convert.ToInt32(txtId.Text), txtNombre.Text, txtCI.Text, txtDireccion.Text, mtxtTelefono.Text, Convert.ToInt32(npdEdad.Value), genero);
                this.ClienteUI_Load(sender, e);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBL cliente = new ClienteBL();
                if (cmbGenero.Text.Equals("Masculino"))
                    genero = "M";
                else
                    genero = "F";

                cliente.Actualizar(Convert.ToInt32(txtId.Text), txtNombre.Text, txtCI.Text, txtDireccion.Text, mtxtTelefono.Text, Convert.ToInt32(npdEdad.Value), genero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBL cliente = new ClienteBL();
                cliente.Eliminar(Convert.ToInt32(txtId.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClienteBL cliente = new ClienteBL();
            DataSet dsCliente = new DataSet();
            dsCliente = cliente.BuscarId(Convert.ToInt32(txtId.Text));
            if (dsCliente.Tables.Count > 0)
            {
                if (dsCliente.Tables[0].Rows.Count > 0)
                {
                    txtId.Text = dsCliente.Tables[0].Rows[0][0].ToString();
                    txtNombre.Text = dsCliente.Tables[0].Rows[0][1].ToString();
                    txtCI.Text = dsCliente.Tables[0].Rows[0][2].ToString();
                    txtDireccion.Text = dsCliente.Tables[0].Rows[0][3].ToString();
                    mtxtTelefono.Text = dsCliente.Tables[0].Rows[0][4].ToString();
                    npdEdad.Value = Convert.ToDecimal(dsCliente.Tables[0].Rows[0][5].ToString());
                    cmbGenero.Text = dsCliente.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    MessageBox.Show("No existe registro");
                }
            }
        }

        private void ClienteUI_Load(object sender, EventArgs e)
        {
            ClienteBL cliente = new ClienteBL();
            DataSet dsCliente = new DataSet();
            dsCliente = cliente.BuscarTodo();
            if (dsCliente.Tables.Count>0)
            {
                dtgCliente.DataSource= dsCliente.Tables[0];
                dtgCliente.AllowUserToAddRows = false;
                dtgCliente.Columns[6].Visible = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
