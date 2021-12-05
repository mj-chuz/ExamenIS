using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
  public class UsuarioModel
  {
    public String Identificacion { get; set; }
    public String Nombre { get; set; }
    public long Telefono { get; set; }
    public String Direccion { get; set; }
    public String Provincia { get; set; }
    public String Canton { get; set; }
    public String Distrito { get; set; }
  }
}