using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialA2.Test
{
	[TestClass]
    public class ServicioTest
    {
		[TestMethod]
		public void CrearServicio()
		{
			Servicio servicio1 = new Servicio();
			servicio1.Fecha = DateTime.Parse(DateTime.Now.Date.ToString("dd/MM/yy"));
			servicio1.NombreEstudiante = "Felipe";



			Servicio servicio2 = new Servicio();
			servicio2.Fecha = DateTime.Parse(DateTime.Now.Date.ToString("dd/MM/yy"));
			servicio2.NombreEstudiante = "Jose";

			bool paso1 = true;
			bool paso2 = true;

			RepositorioServicio repositorio = new RepositorioServicio();
			paso1 = repositorio.Guardar(servicio1);
			paso2 = repositorio.Guardar(servicio2);

			Assert.IsTrue(paso1 && paso2);
		}

		[TestMethod]
		public void Buscar()
		{
			RepositorioServicio repositorio = new RepositorioServicio();
			Assert.IsTrue(repositorio.Buscar(1) != null);
		}
		[TestMethod]
		public void GetList()
		{
			RepositorioServicio repositorio = new RepositorioServicio();
			Assert.IsTrue(repositorio.GetList(x=>true).Count() > 0);
		}

		[TestMethod]
		public void Modificar()
		{
			RepositorioServicio repositorio = new RepositorioServicio();
			Servicio servicio = repositorio.Buscar(2);
			servicio.Detalle.Add(new ServicioDetalle(0, 2, "Servicio1", 2, 10, 2*10));
			servicio.Detalle.Add(new ServicioDetalle(0, 2, "Servicio2", 3, 5, 3*5));
			bool paso1 = repositorio.Modificar(servicio);
			Assert.IsTrue(paso1);

		}

		[TestMethod]
		public void Eliminar()
		{
			Assert.IsTrue(new RepositorioServicio().Eliminar(2));
		}
		[TestMethod]
		public void EliminarDetalle()
		{
			RepositorioServicio repositorio = new RepositorioServicio();
			Servicio servicio = repositorio.Buscar(1);
			servicio.Detalle.RemoveAt(1);			
			Assert.IsTrue(new RepositorioServicio().Modificar(servicio));
		}
	}
}
