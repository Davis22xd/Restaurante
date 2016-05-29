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
    public partial class MenuUI : Form
    {
        public MenuUI()
        {
            InitializeComponent();
        }

        private void MenuUI_Load(object sender, EventArgs e)
        {
            MenuBL menu = new MenuBL();
            DataSet dsMenu = new DataSet();
            dsMenu = menu.BuscarTodo();
            if (dsMenu.Tables.Count > 0)
            {
                dtgMenu.DataSource = dsMenu.Tables[0];
                dtgMenu.AllowUserToAddRows = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MenuBL menu = new MenuBL();
            DataSet dsMenu = new DataSet();
            dsMenu = menu.BuscarId(Convert.ToInt32(txtIdMenu.Text));
            if (dsMenu.Tables.Count > 0)
            {
                if (dsMenu.Tables[0].Rows.Count > 0)
                {
                    txtIdMenu.Text = dsMenu.Tables[0].Rows[0][0].ToString();
                    txtNombreMenu.Text = dsMenu.Tables[0].Rows[0][1].ToString();
                    rtbDescripcionMenu.Text = dsMenu.Tables[0].Rows[0][2].ToString();
                    txtPrecioMenu.Text = dsMenu.Tables[0].Rows[0][3].ToString();
                    txtDisponibilidad.Text = dsMenu.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    MessageBox.Show("No existe registro");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                MenuBL menu = new MenuBL();
                menu.Eliminar(Convert.ToInt32(txtIdMenu.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                MenuBL menu = new MenuBL();

                menu.Actualizar(Convert.ToInt32(txtIdMenu.Text), txtNombreMenu.Text, rtbDescripcionMenu.Text, Convert.ToDecimal(txtPrecioMenu.Text), txtDisponibilidad.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                MenuBL menu = new MenuBL();

                menu.Insertar(Convert.ToInt32(txtIdMenu.Text), txtNombreMenu.Text, rtbDescripcionMenu.Text, Convert.ToDecimal(txtPrecioMenu.Text), txtDisponibilidad.Text);
                this.MenuUI_Load(sender, e);

            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Infracción"))
                {
                    MessageBox.Show("Clave Repetida");


                }
                else
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
        }
    }
}
