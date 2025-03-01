using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FormEstudiantes: Form
    {
        CDEstudiantes cdEstudiantes = new CDEstudiantes();  
        public FormEstudiantes()
        {
            InitializeComponent();
        }
        public void MtdMostrarEstu()
        {
            DataTable dtMostrarEstu = cdEstudiantes.MtMostrarEstu();
            dgvVehiculos.DataSource = dtMostrarEstu;    
        }

        private void mtdLimpiarTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                    ((ComboBox)c).Text = string.Empty;
                }
                else if (c.HasChildren)
                {
                    mtdLimpiarTextBoxes(c);
                }
            }
        }

        private void FormEstudiantes_Load(object sender, EventArgs e)
        {
            MtdMostrarEstu();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                cdEstudiantes.CP_mtdAgregarEstu(txtNombre.Text, txtApellido.Text, DateTime.Parse( txtFecNac.Text), DateTime.Parse(txtFecInc.Text), int.Parse(txtCarrearID.Text), txtDireccion.Text, txtTelefono.Text, cmbEstado.Text);
                MtdMostrarEstu();
                MessageBox.Show("El Estudiante se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvVehiculos.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvVehiculos.SelectedCells[1].Value.ToString();
            txtApellido.Text = dgvVehiculos.SelectedCells[2].Value.ToString();
            txtFecNac.Text = dgvVehiculos.SelectedCells[3].Value.ToString();
            txtFecInc.Text = dgvVehiculos.SelectedCells[4].Value.ToString();
            txtCarrearID.Text = dgvVehiculos.SelectedCells[5].Value.ToString();
            txtDireccion.Text = dgvVehiculos.SelectedCells[6].Value.ToString();
            txtTelefono.Text = dgvVehiculos.SelectedCells[7].Value.ToString();
            cmbEstado.Text = dgvVehiculos.SelectedCells[8].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                int codigo = int.Parse(txtID.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                DateTime fechaNac = DateTime.Parse(txtFecNac.Text);
                DateTime fechaIns = DateTime.Parse(txtFecInc.Text);
                int carreraID = int.Parse(txtCarrearID.Text);
                string direcion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string estado = cmbEstado.Text;

                int vCantidadRegistros = cdEstudiantes.CP_mtdActualizarEs(codigo, nombre, apellido, fechaNac, fechaIns,carreraID, direcion, telefono,estado);
                MtdMostrarEstu();
                MessageBox.Show("El estudiante se actualizo con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                int codigo = int.Parse(txtID.Text);
                int vCantidadRegistros = cdEstudiantes.CP_mtdEliminarEs(codigo);
                MtdMostrarEstu();
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            mtdLimpiarTextBoxes(this);
        }
    }
}
