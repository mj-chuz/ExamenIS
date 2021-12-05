using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using ExamenIS.Models;
namespace ExamenIS.Handlers
{
  public class PizzaHandler
  {
    private SqlConnection conexionArtículo;
    private string rutaConexion;

    public PizzaHandler()
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

    public bool AgregarPizza(PizzaModel pizzaHecha)
    {
      bool exitoInsertarPizza = false;
      string consulta = "INSERT INTO Artículo (nombrePK, disponibilidad, precio) " +
        "VALUES (@nombreArticulo, @disponibilidad, @precioArticulo)";
      exitoInsertarPizza = InsertarDatosArtículo(consulta, pizzaHecha);
      if (exitoInsertarPizza)
      {
        consulta = "INSERT INTO Pizza (nombreFK, tamano, tipoMasa, tipoSalsa, cantidadQueso, ingredientes) " +
        "VALUES (@nombrePizza, @tamano, @tipoMasa, @)";
        exitoInsertarPizza = InsertarDatosArtículo(consulta, pizzaHecha);
        exitoInsertarPizza = InsertarDatosArtículo(consulta, pizzaHecha);
      }
      return exitoInsertarPizza;
    }

    public bool InsertarDatosArtículo(String consulta, PizzaModel articulo)
    {
      bool exitoInsertarDatos = false;
      SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexionArtículo);
      comandoParaConsulta.Parameters.AddWithValue("@nombreArticulo", articulo.Nombre);
      comandoParaConsulta.Parameters.AddWithValue("@disponibilidad", articulo.Disponibilidad);
      comandoParaConsulta.Parameters.AddWithValue("@precioArticulo", articulo.Precio);
      conexionArtículo.Open();
      exitoInsertarDatos = comandoParaConsulta.ExecuteNonQuery() >= 1;
      conexionArtículo.Close();
      return exitoInsertarDatos;
    }

    
  }
}