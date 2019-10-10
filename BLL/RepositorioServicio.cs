using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class RepositorioServicio : RepositorioBase<Servicio>
	{
		public override Servicio Buscar(int id)
		{
			Servicio Servicio = new Servicio();
			Contexto contexto = new Contexto();
			try
			{
				Servicio = contexto.Servicio.Include(x => x.Detalle).Where(x => x.Id_Servicio == id).FirstOrDefault();
			}
			catch (Exception)
			{

				throw;

			}
			finally
			{

				contexto.Dispose();

			}
			return Servicio;
		}


		public override bool Modificar(Servicio entity)
		{
			bool paso = false;
			Servicio Anterior = Buscar(entity.Id_Servicio);
			Contexto context = new Contexto();
			try
			{
				using (Contexto contexto = new Contexto())
				{
					foreach (var item in Anterior.Detalle.ToList())
					{
						if (!entity.Detalle.Exists(x => x.Id_Servicio_Detalle == item.Id_Servicio_Detalle))
						{
							contexto.Entry(item).State = EntityState.Deleted;
						}
					}
					contexto.SaveChanges();
				}
				foreach (var item in entity.Detalle)
				{
					var estado = EntityState.Modified;
					if (item.Id_Servicio_Detalle == 0)
						estado = EntityState.Added;
					context.Entry(item).State = estado;
				}
				context.Entry(entity).State = EntityState.Modified;
				paso = context.SaveChanges() > 0;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				context.Dispose();
			}
			return paso;
		}
	}

}

