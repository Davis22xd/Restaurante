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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ImpuestoBL Impuesto = new ImpuestoBL();
                Impuesto.Insertar(Convert.ToInt32(txtID.Text), txtNombre.Text, Convert.ToDouble(txtValor.Text), txtEstado.Text, dtpFecha.Value);
                this.Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la operacion +\n" + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ImpuestoBL Impuesto = new ImpuestoBL();
            Impuesto.Actualizar(Convert.ToInt32(txtID.Text), txtNombre.Text, Convert.ToDouble(txtValor.Text), txtEstado.Text, dtpFecha.Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ImpuestoBL Impuesto = new ImpuestoBL();
            Impuesto.Eliminar(Convert.ToInt32(txtID.Text));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImpuestoBL Impuesto = new ImpuestoBL();
            DataSet dsimpuesto = new DataSet();
            dsimpuesto = Impuesto.buscarTodos();
            //dtgImpuesto = Impuesto.buscarTodos();
            //dtgImpuesto = dsimpuesto;
            if (dsimpuesto.Tables.Count > 0)
            {
                dtgImpuesto.DataSource = dsimpuesto.Tables[0];
                dtgImpuesto.AllowUserToAddRows = false;
                dtgImpuesto.Columns[4].Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ImpuestoBL Impuesto = new ImpuestoBL();
            DataSet dsimpuesto = new DataSet();
            dsimpuesto = Impuesto.buscarId(Convert.ToInt32(txtID.Text));
            if (dsimpuesto.Tables.Count > 0)
            {
                if (dsimpuesto.Tables[0].Rows.Count > 0)
                {
                    txtNombre.Text = dsimpuesto.Tables[0].Rows[0][1].ToString();
                    txtValor.Text = dsimpuesto.Tables[0].Rows[0][2].ToString();
                    txtEstado.Text = dsimpuesto.Tables[0].Rows[0][3].ToString();
                    dtpFecha.Value = Convert.ToDateTime(dsimpuesto.Tables[0].Rows[0][4].ToString());
                }
                else
                {
                    MessageBox.Show("No existe registro");
                }
            }
        }
    }
}
