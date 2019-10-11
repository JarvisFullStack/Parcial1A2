using BLL;
using Entidades;
using PrimerParcialAplicada2.Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1A2.Registros
{
	public partial class rServicios : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			TextBoxFecha.Text = DateTime.Now.Date.ToString("dd/MM/yy");
			if (!IsPostBack)
			{
				Servicio itemevaluacion = new Servicio();
				int id = Utilidades.ToInt(Request.QueryString["id"]);
				ViewState["Servicio"] = new Servicio();
				if (id > 0)
				{
					Servicio servicio = new RepositorioServicio().Buscar(id);
					if (servicio != null)
					{
						LlenarGrid();
						Utilidades.ShowToastr(this, "Registro encontrado", "Busqueda Exitosa!", "success");
					}
					else
					{
						Utilidades.ShowToastr(this, "Registro no encontrado", "Busqueda Fallida", "warning");
					}
				}
			}

			/*else
			{
				Servicio servicio = new Servicio();
				LlenarViewState(servicio, servicio.ServicioDetalle);
			}*/
		}

		private void LlenarGrid()
		{
			this.DetalleGridView.DataSource = ((Servicio)ViewState["Servicio"]).Detalle;
			this.DetalleGridView.DataBind();
		}

		private void LlenarViewState(Servicio servicio)
		{
			ViewState["Servicio"] = servicio;
		}

		protected void BotonNuevo_Click(object sender, EventArgs e)
		{
			Limpiar();
		}

		private void Limpiar()
		{
			this.TextBoxId.Text = string.Empty;
			this.TextBoxNombreEstudiante.Text = string.Empty;
			this.TextBoxNombreServicio.Text = string.Empty;
			this.TextBoxCantidad.Text = "0";
			this.TextBoxPrecio.Text = "0";
			this.TextBoxImporte.Text = "0";
			this.TextBoxTotal.Text = string.Empty;
			TextBoxFecha.Text = DateTime.Now.Date.ToString("dd/MM/yy");
			ViewState["Servicio"] = new Servicio();
			LlenarGrid();
		}

		protected void BotonGuardar_Click(object sender, EventArgs e)
		{
			Servicio servicio = LlenaClase();
			RepositorioServicio repositorio = new RepositorioServicio();
			bool paso = true;
			if (servicio.Id_Servicio == 0)
			{

				paso = repositorio.Guardar(servicio);
			}
			else
			{
				paso = repositorio.Modificar(servicio);
			}

			if (paso)
			{
				Utilidades.ShowToastr(this, "Transaccion Exitosa", "Exito", "success");
				this.Limpiar();
			}
			else
			{
				Utilidades.ShowToastr(this, "Transaccion Erronea", "Error", "error");
			}

		}

		private Servicio LlenaClase()
		{
			Servicio servicio = (Servicio)ViewState["Servicio"];
			servicio.Id_Servicio = Utilidades.ToInt(this.TextBoxId.Text);
			servicio.NombreEstudiante = this.TextBoxNombreEstudiante.Text; 
			servicio.Fecha = DateTime.Parse(TextBoxFecha.Text);
			LlenarViewState(servicio);
			return servicio;
		}


		protected void BotonEliminar_Click(object sender, EventArgs e)
		{
			int id = Utilidades.ToInt(this.TextBoxId.Text);
			if (id > 0)
			{
				RepositorioServicio repositorio = new RepositorioServicio();
				Servicio servicio = repositorio.Buscar(id);
				if (servicio != null)
				{
					bool paso = repositorio.Eliminar(id);
					if (paso)
					{
						Utilidades.ShowToastr(this, "Registro Eliminado!", "Exito", "info");
						
						Limpiar();
					}
					else
					{
						Utilidades.ShowToastr(this, "Error", "Error", "danger");

					}

				}
				{
					Utilidades.ShowToastr(this, "Registro no Existe", "Error", "warning");
				}
			}
		}



		protected void RemoverDetalle_Click(object sender, EventArgs e)
		{
			Servicio servicio = (Servicio)ViewState["Servicio"];
			List<ServicioDetalle> detalle = (List<ServicioDetalle>)ViewState["Detalle"];
			GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
			servicio.Detalle.RemoveAt(row.RowIndex);
			detalle.RemoveAt(row.RowIndex);
			CalcularTotal();
			LlenarGrid();
		}



		protected void BotonAgregarDetalle_Click(object sender, EventArgs e)
		{
			Servicio servicio = (Servicio)ViewState["Servicio"];
			if (ValidarNumericos())
			{
				ServicioDetalle nuevoItem = GetItemDetalle();
				servicio.Detalle.Add(nuevoItem);
				ViewState["Servicio"] = servicio;
				LlenarGrid();
				CalcularTotal();
				LimpiarCamposDetalle();
				Utilidades.ShowToastr(this, "Agregado Correctamente", "Correcto");
			}
			else
			{
				Utilidades.ShowToastr(this, "Error", "error", "warning");
			}


		}

		private void LimpiarCamposDetalle()
		{
			this.TextBoxNombreServicio.Text = string.Empty;
			this.TextBoxPrecio.Text = string.Empty;
			this.TextBoxCantidad.Text = string.Empty;
			this.TextBoxImporte.Text = string.Empty;
		}

		private bool ValidarNumericos()
		{
			bool paso = true;
			try
			{
				Convert.ToDecimal(this.TextBoxCantidad.Text);
			}
			catch (Exception)
			{
				paso = false;
			}

			if (Utilidades.ToDecimal(this.TextBoxPrecio.Text) == 0)
			{
				paso = false;
			}

			try
			{
				Convert.ToDecimal(this.TextBoxPrecio.Text);
			}
			catch (Exception)
			{
				paso = false;
			}

			if (Utilidades.ToDecimal(this.TextBoxPrecio.Text) == 0)
			{
				paso = false;
			}

			if (!paso)
			{
				Utilidades.ShowToastr(this, "Debe llenar los campos correctamente!", "Introduzca datos validos", "warning");
			}
			else
			{
				Utilidades.ShowToastr(this, "Agregado Correctamente!", "Exito", "success");
			}

			return paso;

		}

		protected void DetalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}

		private ServicioDetalle GetItemDetalle()
		{
			ServicioDetalle item = new ServicioDetalle();
			item.Id_Servicio_Detalle = 0;
			item.NombreServicio = TextBoxNombreServicio.Text;
			item.Id_Servicio = ((Servicio)ViewState["Servicio"]).Id_Servicio;
			item.Cantidad = Utilidades.ToInt(this.TextBoxCantidad.Text);
			item.Precio = Utilidades.ToDecimal(this.TextBoxPrecio.Text);
			item.Importe = item.Cantidad * item.Precio;
			return item;
		}

		private Decimal CalcularTotal()
		{
			Servicio servicio = (Servicio)ViewState["Servicio"];
			decimal total = 0;
			foreach (var item in servicio.Detalle.ToList())
			{
				total += (item.Precio * item.Cantidad);
			}
			TextBoxTotal.Text = total.ToString();
			return total;


		}

		private void CalcularImporte()
		{
			this.TextBoxImporte.Text = (TextBoxCantidad.Text.ToInt() * TextBoxPrecio.Text.ToDecimal()).ToString();
		}



		private void LlenaCampos()
		{
			Servicio servicio = (Servicio)ViewState["Servicio"];
			this.TextBoxNombreEstudiante.Text = servicio.NombreEstudiante;
			LlenarGrid();
		}

		protected void BotonBusqueda_Click(object sender, EventArgs e)
		{
			int id = Utilidades.ToInt(this.TextBoxId.Text);
			if (id > 0)
			{
				Servicio servicio = new RepositorioServicio().Buscar(id);
				ViewState["Servicio"] = servicio;
				if (servicio != null)
				{
					LlenaCampos();
					LlenarGrid();
				}
			}
		}

		protected void TextBoxCantidad_TextChanged(object sender, EventArgs e)
		{
			CalcularImporte();
		}

		protected void TextBoxPrecio_TextChanged(object sender, EventArgs e)
		{
			CalcularImporte();
		}
	}
}