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
            //CDVehiculos cdVehiculos = new CDVehiculos();
            DataTable dtMostrarEstu = cdEstudiantes.MtMostrarEstu();
            dgvVehiculos.DataSource = dtMostrarEstu;    
        }

        private void FormEstudiantes_Load(object sender, EventArgs e)
        {
            MtdMostrarEstu();
        }
    }
}
