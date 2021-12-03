using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
	public class Pizza
	{
		public enum Tamano { PERSONAL, MEDIANA, GRANDE, FAMILIAR}
		public enum Masa { DELGADA, GRUESA}
		public enum Queso { REGULAR, EXTRA}
		public enum Ingredientes {JAMÓN, PEPPERONI, HONGOS, PIÑA }
		public enum Extras { JALAPENOS, ACEITUNAS, TOMATE, ANCHOAS}

		public String CantidadQueso { get; set; }
		public String TipoSalsa { get; set; }
		public String TipoMasa { get; set; }
	}
}