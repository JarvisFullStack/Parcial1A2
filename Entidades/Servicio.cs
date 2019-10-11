using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

	[Serializable]
    public class Servicio 
    {
		[Key]
		public int Id_Servicio { get; set; }
		public string NombreEstudiante { get; set; }
		[DataType(DataType.Date)]
		public DateTime Fecha { get; set; }
		public virtual List<ServicioDetalle> Detalle { get; set; }

		public Servicio()
		{
			Id_Servicio = 0;
			NombreEstudiante = string.Empty;
			this.Fecha = DateTime.Now.Date;
			this.Detalle = new List<ServicioDetalle>();
		}
	}
}
