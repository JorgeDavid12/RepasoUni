﻿using System;
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

        //public void CP_mtdAgregarVehiculos(string Marca, string Modelo, int Año, decimal Precio, string Estado)
        //{

        //    string Usp_crear = "uspVehiculosInsertar";
        //    SqlCommand cmd_InsertarVehiculos = new SqlCommand(Usp_crear, conexion.MtdAbrirConexion());
        //    cmd_InsertarVehiculos.CommandType = CommandType.StoredProcedure;

        //    cmd_InsertarVehiculos.Parameters.AddWithValue("@Marca", Marca);
        //    cmd_InsertarVehiculos.Parameters.AddWithValue("@Modelo", Modelo);
        //    cmd_InsertarVehiculos.Parameters.AddWithValue("@Año", Año);
        //    cmd_InsertarVehiculos.Parameters.AddWithValue("@Precio", Precio);
        //    cmd_InsertarVehiculos.Parameters.AddWithValue("@Estado", Estado);
        //    cmd_InsertarVehiculos.ExecuteNonQuery();

        //    conexion.MtdCerrarConexion();

        //}

        //public int CP_mtdActualizarVh(int VehiculoID, string Marca, string Modelo, int Año, decimal Precio, string Estado)
        //{
        //    int vContarRegistrosAfectados = 0;

        //    string vUspActualizarVh = "uspVehiculosUpdate";
        //    SqlCommand commActualizarVh = new SqlCommand(vUspActualizarVh, conexion.MtdAbrirConexion());
        //    commActualizarVh.CommandType = CommandType.StoredProcedure;

        //    commActualizarVh.Parameters.AddWithValue("@VehiculoID", VehiculoID);
        //    commActualizarVh.Parameters.AddWithValue("@Marca", Marca);
        //    commActualizarVh.Parameters.AddWithValue("@Modelo", Modelo);
        //    commActualizarVh.Parameters.AddWithValue("@Año", Año);
        //    commActualizarVh.Parameters.AddWithValue("@Precio", Precio);
        //    commActualizarVh.Parameters.AddWithValue("@Estado", Estado);

        //    vContarRegistrosAfectados = commActualizarVh.ExecuteNonQuery();

        //    conexion.MtdCerrarConexion();
        //    return vContarRegistrosAfectados;
        //}

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
