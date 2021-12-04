using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ExamenIS.Models
{
  public class PizzaModel
  {
    public String Nombre { get; set; }

    public int Disponibilidad { get; set; }
    public int Precio { get; set; }

    [Required(ErrorMessage = "Es necesario que indique la cantidad de queso")]
    [Display(Name = "Cantidad de queso*")]
    public String CantidadQueso { get; set; }

    [Required(ErrorMessage = "Es necesario que indique el tipo de salsa")]
    [Display(Name = "Tipo de salsa*")]
    public String TipoSalsa { get; set; }

    [Required(ErrorMessage = "Es necesario que indique el tipo de masa")]
    [Display(Name = "Tipo de masa*")]
    public String TipoMasa { get; set; }

    [Required(ErrorMessage = "Es necesario que indique el tamaño de la pizza")]
    [Display(Name = "Tamaño de la pizza*")]
    public String Tamano { get; set; }

    public List<String> Ingredientes { get; set; }

    
  }
}