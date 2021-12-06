using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExamenIS.Models
{
  public class UsuarioModel
  {
    [Required(ErrorMessage = "Es necesario que indique su identificación")]
    [Display(Name = "Identificación*")]
    public String Identificacion { get; set; }

    [Required(ErrorMessage = "Es necesario que indique su nombre completo")]
    [Display(Name = "Nombre completo*")]
    public String Nombre { get; set; }

    [Required(ErrorMessage = "Es necesario que indique su número de teléfono")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar números")]
    [Display(Name = "Teléfono*")]
    public long Telefono { get; set; }

    [Required(ErrorMessage = "Es necesario que indique su dirección")]
    [Display(Name = "Dirección exacta*")]
    public String Direccion { get; set; }
    public String Provincia { get; set; }
    public String Canton { get; set; }
    public String Distrito { get; set; }
    public Double PagoTotal { get; set; }
    public String Productos { get; set; }
  }
}