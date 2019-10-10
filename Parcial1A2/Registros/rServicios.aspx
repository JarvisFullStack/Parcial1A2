<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="rServicios.aspx.cs" Inherits="Parcial1A2.Registros.rServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManger" runat="server"></asp:ScriptManager>
	<div class="card">
		<div class="card-title">
			<div class="card-text">Registro de Servicios</div>
		</div>
		<div class="card-body">
			<div class="row">
				<div class="form-group col-6">
					<div class="input-group">
						<div class="input-group-prepend">
							<div class="input-group-text">
								<a>ID</a>
							</div>
						</div>
						<asp:TextBox runat="server" ID="TextBoxId" CssClass="form-control"></asp:TextBox>

						<div class="input-group-append">
							 <asp:LinkButton CausesValidation="false" runat="server" CssClass="btn btn-primary" ID="BotonBusqueda" OnClick="BotonBusqueda_Click"><i class="fa fa-search"></i></asp:LinkButton>
							
						</div>
					</div>
					<div class="col-2"></div>
					<div class="input-group-group col-4 offset-4">
						<div class="input-group-prepend">
							<div class="input-group-text">
								<a>Fecha</a>
							</div>
						</div>

						<asp:TextBox runat="server" ID="TextBoxFecha" ReadOnly="true" CssClass="form-control"></asp:TextBox>
					</div>
				</div>
			</div>


			<div class="row">
				<div class="form-group col-6">
					<div class="input-group-prepend">
						<div class="input-group-text">
							<a>Nombre</a>
						</div>
					</div>
					<asp:TextBox runat="server" ID="TextBoxNombreEstudiante" CssClass="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxNombreEstudiante" CssClass="text-danger" Text="Introduzca este campo correctamente"></asp:RequiredFieldValidator>
				</div>
			</div>



			<div class="row">
				<div class="form-control col-md-4">
					<div class="input-group">
						<div class="input-group-prepend">
						<div class="input-group-text"><a>Servicio</a></div>
							</div>
						<asp:TextBox runat="server" ID="TextBoxNombreServicio" CssClass="form-control"></asp:TextBox>
					</div>
					
				</div>

				<div class="form-control col-md-4">
					<div class="input-group">
						<div class="input-group-prepend">
						<div class="input-group-text"><a>Cantidad</a></div>
							</div>
					<asp:TextBox runat="server" ID="TextBoxCantidad" OnTextChanged="TextBoxCantidad_TextChanged" CssClass="form-control"></asp:TextBox>
						</div>
				</div>

				<div class="form-control col-md-4">
					<div class="input-group">
						<div class="input-group-prepend">
						<div class="input-group-text"><a>Precio</a></div>
							</div>
					<asp:TextBox runat="server" ID="TextBoxPrecio" OnTextChanged="TextBoxPrecio_TextChanged" CssClass="form-control"></asp:TextBox>
						</div>
				</div>
			</div>
			<div class="row">
				<div class="form-control col-md-4">
					<div class="input-group">
						<div class="input-group-prepend">
						<div class="input-group-text"><a>Importe</a></div>
							</div>
					<asp:TextBox CausesValidation="false" runat="server" ID="TextBoxImporte" CssClass="form-control" ReadOnly="true"></asp:TextBox>
						</div>
				</div>

				<div class="form-control col-md-4">

					<asp:LinkButton runat="server" CausesValidation="false" ID="BotonAgregarDetalle" OnClick="BotonAgregarDetalle_Click" CssClass="btn btn-primary" Text="Agregar"></asp:LinkButton>
				</div>

			</div>


			<br />
			<br />

			
			<asp:UpdatePanel ID="UpdatePanel" runat="server">
				<ContentTemplate>
					<div class="row">
						<div class="table table-responsive col-md-12">
							<asp:GridView ID="DetalleGridView"
								runat="server"
								CssClass="table table-condensed table-bordered table-responsive"
								CellPadding="4" ForeColor="#333333" GridLines="None"
								OnPageIndexChanging="DetalleGridView_PageIndexChanging"
								AllowPaging="true" PageSize="5" AutoGenerateColumns="true">
								<AlternatingRowStyle BackColor="LightBlue" />
								<Columns>
									<asp:TemplateField ShowHeader="False" HeaderText="Opciones">
										<ItemTemplate>
											<asp:Button ID="RemoverDetalle" runat="server" CausesValidation="false" CommandName="Select"
												Text="Remover" class="btn btn-danger btn-sm" OnClick="RemoverDetalle_Click" />
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
								<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
								<RowStyle BackColor="#EFF3FB" />
							</asp:GridView>


							<div class="input-group col-4">
								<div class="input-group-prepend">
									<div class="input-group-text"><a>Total</a></div>
								</div>
								<asp:TextBox runat="server" ID="TextBoxTotal" CssClass="form-control" CausesValidation="false" ReadOnly="true"></asp:TextBox>
							</div>
						</div>
					</div>
				</ContentTemplate>
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="DetalleGridView" />
				</Triggers>
			</asp:UpdatePanel>




		</div>
		<div class="card-footer">
			<asp:LinkButton ID="BotonNuevo" class="btn btn-primary" runat="server" OnClick="BotonNuevo_Click">Nuevo</asp:LinkButton>
			<asp:LinkButton ID="BotonGuardar" class="btn btn-success" runat="server" OnClick="BotonGuardar_Click">Guardar</asp:LinkButton>
			<asp:LinkButton ID="BotonEliminar" class="btn btn-danger" runat="server" OnClick="BotonEliminar_Click">Eliminar</asp:LinkButton>
		</div>
		</div>
	
	
</asp:Content>
