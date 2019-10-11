using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	[Serializable]
	public class ServicioDetalle
	{
		[Key]
		public int Id_Servicio_Detalle { get; set; }
		public int Id_Servicio { get; set; }
		public string NombreServicio { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Importe { get; set; }

		[ForeignKey("Id_Servicio")]
		public virtual Servicio Servicio { get; set; }

		public ServicioDetalle()
		{
			this.Id_Servicio = 0;
			this.Id_Servicio_Detalle = 0;
			this.Cantidad = 0;
			this.Precio = 0;
			this.Importe = 0;
			this.Servicio = null;
		}

		public ServicioDetalle(int id_Servicio_Detalle, int id_Servicio, string nombreServicio, int cantidad, decimal precio, decimal importe)
		{
			Id_Servicio_Detalle = id_Servicio_Detalle;
			Id_Servicio = id_Servicio;
			NombreServicio = nombreServicio;
			Cantidad = cantidad;
			Precio = precio;
			Importe = importe;
			this.Servicio = null;
		}
	}
}
