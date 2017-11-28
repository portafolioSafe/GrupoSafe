<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TecnicoCrearCategorias.aspx.cs" Inherits="web.TecnicoCrearCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2 {
            margin-left: 30%;
        }

        #mensajeSI, #mensajeNO, #mensajeNa,#mensajeSiM,#mensajeEx {
            display: table;
            margin: 0 auto;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
        <div class="panel-heading">
            <asp:Label ID="Label3" runat="server" Text="Agregar Categoria" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
        <div class="panel-body">
            <div>
                <div id="mensajeSI" runat="server" class="alert alert-success" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡CATEGORIA AGREGADA EXITOSAMENTE!

                </div>
                
                <div id="mensajeEX" runat="server" class="alert alert-danger" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign fade:10S"></span>&nbsp; ¡CATEGORIA YA EXISTE!

                </div>
                <div id="mensajeSiM" runat="server" class="alert alert-success" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡CATEGORIA MODIFICADA EXITOSAMENTE!

                </div>
                <div id="mensajeNO" runat="server" class="alert alert-danger" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡DEBE ESCOGER TIPO DE EVALUACION!

                  
                </div>
                <div id="mensajeNa" runat="server" class="alert alert-danger" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡DEBE AGREGAR EL NOMBRE DE LA CATEGORIA!

                  
                </div>
            </div>

            <div class="form-group">
                <label for="em">Seleccione tipo de evaluacion</label>
                <asp:DropDownList ID="DropDownList2" class="form-control" runat="server">
                    <asp:ListItem Value="0">SELECCIONE TIPO DE EVALUACION</asp:ListItem>
                </asp:DropDownList>

            </div>




            <div class="form-group">
                <label for="tx_especialidad">Nombre de la categoria</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Ingrese Observaciones" TextMode="SingleLine"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="El rango es de 1 a 300 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{1,100}$"></asp:RegularExpressionValidator>

            </div>
         









            <asp:Button ID="Button1" runat="server" CssClass="btn alert-success center-block" Text="Agregar" Width="86px" OnClick="Button1_Click" />

            <asp:Button ID="Button2" runat="server" CssClass="btn alert-success center-block" Text="Modificar" Width="86px" OnClick="Button2_Click" />
            <br />
            <br />
            <br />

            <asp:Button ID="Button3" runat="server" CssClass="btn alert-danger center-block" Text="Cancelar" Width="86px" OnClick="Button3_Click" />


            <h4 style="text-align: center;">Listado de categorias actuales</h4>

            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" DataKeyNames="id" EmptyDataText="No hay categorias" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" CssClass="table table-bordered bs-table" >
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />

                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Modificar" CommandName="Select" HeaderText="Acción">
                        <HeaderStyle CssClass=" text-center" ForeColor="White" BackColor="#337ab7"></HeaderStyle>
                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                    </asp:ButtonField>
                    
                </Columns>
            </asp:GridView>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="listarCategoria" TypeName="BLL.CategoriaDTO"></asp:ObjectDataSource>



        </div>
    </div>


</asp:Content>

