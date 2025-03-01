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

        public int CP_mtdActualizarVh(int VehiculoID, string Marca, string Modelo, int Año, decimal Precio, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            string vUspActualizarVh = "uspVehiculosUpdate";
            SqlCommand commActualizarVh = new SqlCommand(vUspActualizarVh, conexion.MtdAbrirConexion());
            commActualizarVh.CommandType = CommandType.StoredProcedure;

            commActualizarVh.Parameters.AddWithValue("@VehiculoID", VehiculoID);
            commActualizarVh.Parameters.AddWithValue("@Marca", Marca);
            commActualizarVh.Parameters.AddWithValue("@Modelo", Modelo);
            commActualizarVh.Parameters.AddWithValue("@Año", Año);
            commActualizarVh.Parameters.AddWithValue("@Precio", Precio);
            commActualizarVh.Parameters.AddWithValue("@Estado", Estado);

            vContarRegistrosAfectados = commActualizarVh.ExecuteNonQuery();

            conexion.MtdCerrarConexion();
            return vContarRegistrosAfectados;
        }

        //public int CP_mtdEliminarVh(int codigo)
        //{
        //    int vCantidadRegistrosEliminados = 0;

        //    string vUspEliminarVh = "uspVehiculosDelete";
        //    SqlCommand commEliminarVh = new SqlCommand(vUspEliminarVh, conexion.MtdAbrirConexion());
        //    commEliminarVh.CommandType = CommandType.StoredProcedure;

        //    commEliminarVh.Parameters.AddWithValue("@VehiculoID", codigo);

        //    vCantidadRegistrosEliminados = commEliminarVh.ExecuteNonQuery();
        //    conexion.MtdCerrarConexion();
        //    return vCantidadRegistrosEliminados;
        //}
    }
}
