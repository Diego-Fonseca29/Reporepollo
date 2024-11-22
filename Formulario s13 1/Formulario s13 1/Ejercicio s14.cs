using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_s13_1
{
    public partial class Form1 : Form
    {
        private List<Ciudad> ciudades;
        private Ciudad ciudadesSel = new Ciudad();
        public Form1()
        {
            InitializeComponent();
            ciudades = new List<Ciudad>();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ciudad ciudad = new Ciudad();
            ciudad.ID = int.Parse(txtCodigo.Text);
            ciudad.Nombre = txtNombre.Text;

            int index = ciudades.FindIndex(item => item.ID == ciudad.ID);

            if (index != -1)
            {
                ciudades[index] = ciudad;
            }
            else
            {
                ciudades.Add(ciudad);
            }

            MostrarDatos();
            LimpiarCodigo();


        }
        private void MostrarDatos()
        {
            dgvRegistro.DataSource = null;
            dgvRegistro.DataSource = ciudades;
        }

        private void LimpiarCodigo()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Archivos DAT (*.dat)|*.dat";
                saveFileDialog1.Title = "Guardar archivo";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    CiudadArchivo archivo = new CiudadArchivo();

                    archivo.GuardarArchivo(ciudades, saveFileDialog1.FileName);
                    MessageBox.Show("Se ha guardado el archivo", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Archivos DAT (*.dat)|*.dat|Todos los archivos (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = openFileDialog1.FileName;

                CiudadArchivo archivo = new CiudadArchivo();
                ciudades = archivo.cargarCiudades(ruta);

                MostrarDatos();
            }
            else
            {
                MessageBox.Show("No se selecciono ningun archivo. ");
            }
            

            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ciudades.Remove(ciudadesSel);
                MessageBox.Show("Ciudad eliminada...", "Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMostrarDatos_CelIDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dgvRegistro.CurrentRow;
            if (currentRow == null )
            {
                ciudadesSel.ID = int.Parse(currentRow.Cells[0].Value.ToString());
                ciudadesSel.Nombre = currentRow.Cells[1].Value.ToString();
                txtCodigo.Text = ciudadesSel.ID.ToString();
                txtNombre.Text = ciudadesSel.Nombre;
            }
          
        }

        private void gUARDARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Archivos DAT (*.dat)|*.dat";
                saveFileDialog1.Title = "Guardar archivo";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    CiudadArchivo archivo = new CiudadArchivo();

                    archivo.GuardarArchivo(ciudades, saveFileDialog1.FileName);
                    MessageBox.Show("Se ha guardado el archivo", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Archivos DAT (*.dat)|*.dat|Todos los archivos (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = openFileDialog1.FileName;

                CiudadArchivo archivo = new CiudadArchivo();
                ciudades = archivo.cargarCiudades(ruta);

                MostrarDatos();
            }
            else
            {
                MessageBox.Show("No se selecciono ningun archivo. ");
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ciudades.Remove(ciudadesSel);
                MessageBox.Show("Ciudad eliminada...", "Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}