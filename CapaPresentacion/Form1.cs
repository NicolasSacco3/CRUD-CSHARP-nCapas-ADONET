using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class FormularioCRUD : Form
    {

        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
        private bool Editar = false;
        public FormularioCRUD()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNombre.TabIndex = 1;
            txtDescripcion.TabIndex = 2;
            txtMarca.TabIndex = 3;
            txtPrecio.TabIndex = 4;
            txtStock.TabIndex = 5;
            MostrarProductos();
        }
        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarProductos();
                    limpiarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la insersión de datos, details: " + ex);
                }
            }
            if (Editar == true)
            {
                try{
                    objetoCN.EditarProductos(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se editó correctamente");
                    MostrarProductos();
                    Editar = false;
                    limpiarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No fue posible insertar los datos, error:" + ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //boton modidicar
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProductos(idProducto);
                MessageBox.Show("Se BORRO correctamente");
                MostrarProductos();
            }
           
        




        }
        private void limpiarControles()
        {
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }

        }
