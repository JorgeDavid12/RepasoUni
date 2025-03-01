using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //imp
using System.Data.SqlClient; //imp

namespace CapaDatos
{
    public class CDEstudiantes
    {
        CDConexion conexion = new CDConexion();

        public DataTable MtMostrarEstu()
        {
            string QryMostrarEstu = "uspEstudiantesMostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarEstu, conexion.MtdAbrirConexion());
            DataTable dtMostrarEstu = new DataTable();
            adapter.Fill(dtMostrarEstu);
            conexion.MtdCerrarConexion();
            return dtMostrarEstu;
        }

        public void CP_mtdAgregarEstu(string Nombre, string Apellido, DateTime FechaNaci, DateTime FechaIns, int CarreraID, string Direccion, string Telefono, string Estado)
        {

            string Usp_crear = "uspInserEstudiantes";
            SqlCommand cmd_InsertarEstu = new SqlCommand(Usp_crear, conexion.MtdAbrirConexion());
            cmd_InsertarEstu.CommandType = CommandType.StoredProcedure;

            cmd_InsertarEstu.Parameters.AddWithValue("@Nombre", Nombre);
            cmd_InsertarEstu.Parameters.AddWithValue("@Apellido", Apellido);
            cmd_InsertarEstu.Parameters.AddWithValue("@FechaNacimiento", FechaNaci.Date);
            cmd_InsertarEstu.Parameters.AddWithValue("@FechaInscripcion", FechaIns.Date);
            cmd_InsertarEstu.Parameters.AddWithValue("@CarreraID", CarreraID);
            cmd_InsertarEstu.Parameters.AddWithValue("@Direccion", Direccion);
            cmd_InsertarEstu.Parameters.AddWithValue("@Telefono", Telefono);
            cmd_InsertarEstu.Parameters.AddWithValue("@Estado", Estado);
            cmd_InsertarEstu.ExecuteNonQuery();

            conexion.MtdCerrarConexion();

        }

        public int CP_mtdActualizarEs(int EstudianteID,string Nombre, string Apellido, DateTime FechaNaci, DateTime FechaIns, int CarreraID, string Direccion, string Telefono, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            string vUspActualizarEs = "uspUpdateEstudiante";
            SqlCommand commActualizarEstu = new SqlCommand(vUspActualizarEs, conexion.MtdAbrirConexion());
            commActualizarEstu.CommandType = CommandType.StoredProcedure;

            commActualizarEstu.Parameters.AddWithValue("@EstudianteID", EstudianteID);
            commActualizarEstu.Parameters.AddWithValue("@Nombre", Nombre);
            commActualizarEstu.Parameters.AddWithValue("@Apellido", Apellido);
            commActualizarEstu.Parameters.AddWithValue("@FechaNacimiento", FechaNaci.Date);
            commActualizarEstu.Parameters.AddWithValue("@FechaInscripcion", FechaIns.Date);
            commActualizarEstu.Parameters.AddWithValue("@CarreraID", CarreraID);
            commActualizarEstu.Parameters.AddWithValue("@Direccion", Direccion);
            commActualizarEstu.Parameters.AddWithValue("@Telefono", Telefono);
            commActualizarEstu.Parameters.AddWithValue("@Estado", Estado);

            vContarRegistrosAfectados = commActualizarEstu.ExecuteNonQuery();

            conexion.MtdCerrarConexion();
            return vContarRegistrosAfectados;
        }

        public int CP_mtdEliminarEs(int codigo)
        {
            int vCantidadRegistrosEliminados = 0;

            string vUspEliminarEs = "uspDeleteEstudiante";
            SqlCommand commEliminarEs = new SqlCommand(vUspEliminarEs, conexion.MtdAbrirConexion());
            commEliminarEs.CommandType = CommandType.StoredProcedure;

            commEliminarEs.Parameters.AddWithValue("@EstudianteID", codigo);

            vCantidadRegistrosEliminados = commEliminarEs.ExecuteNonQuery();
            conexion.MtdCerrarConexion();
            return vCantidadRegistrosEliminados;
        }
    }
}
