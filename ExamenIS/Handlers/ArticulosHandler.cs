using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ExamenIS.Models;
namespace ExamenIS.Handlers
{
  public class ArticulosHandler
  {
    private SqlConnection conexionArtículo;
    private string rutaConexion;

    public ArticulosHandler()
    {
      rutaConexion = ConfigurationManager.ConnectionStrings["PizzeriaConnection"].ToString();
      conexionArtículo = new SqlConnection(rutaConexion);
    }

    private DataTable CrearTablaConsulta(string consulta)
    {
      SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexionArtículo);
      SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
      DataTable consultaFormatoTabla = new DataTable();
      conexionArtículo.Open();
      adaptadorParaTabla.Fill(consultaFormatoTabla);
      conexionArtículo.Close();
      return consultaFormatoTabla;
    }

    public List<ArticulosModel> ObtenerArticulos()
    {
      List<ArticulosModel> planetas = new List<ArticulosModel>();
      string consulta = "SELECT * FROM Articulo ";
      DataTable tablaResultado = CrearTablaConsulta(consulta);
      foreach (DataRow columna in tablaResultado.Rows)
      {
        planetas.Add(
        new ArticulosModel
        {
          Nombre = Convert.ToString(columna["nombrePK"]),
          Disponibilidad = Convert.ToInt32(columna["disponibilidad"]),
          Precio = Convert.ToInt32(columna["precio"]),
          NombreImagen = Convert.ToString(columna["imagen"]),
          Descripcion = Convert.ToString(columna["descripcion"]),
        });
      }
      return planetas;
    }
  }
}