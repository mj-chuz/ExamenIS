using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
  public class ArticulosModel
  {
    public String Nombre { get; set; }
    public int Disponibilidad { get; set; }
    public int Precio { get; set; }
    public String CantidadQueso { get; set; }
    public String TipoSalsa { get; set; }
    public String TipoMasa { get; set; }
    public String Tamano { get; set; }
    public List<String> Ingredientes { get; set; }


  }
}