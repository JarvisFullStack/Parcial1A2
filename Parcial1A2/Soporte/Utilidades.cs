using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicada2.Soporte
{
	public class Utilidades
	{
		public static Int32 ToInt(String value)
		{
			int retorno = 0;
			int.TryParse(value, out retorno);

			return retorno;
		}

		public static void LlenarCombo<T>(DropDownList dropDown, BLL.IRepository<T> repositorio, Expression<Func<T, bool>> expression, string dataValueField, string dataTextField) where T : class
		{
			dropDown.Items.Clear();
			dropDown.DataSource = repositorio.GetList(expression);
			dropDown.DataTextField = dataTextField;
			dropDown.DataValueField = dataValueField;
			dropDown.DataBind();
		}


		public static decimal ToDecimal(string valor)
		{
			decimal retorno = 0;
			decimal.TryParse(valor, out retorno);

			return retorno;
		}

		public static void ShowToastr(Page page, string message, string title, string type = "info")
		{
			page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
				  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
		}
	}
}