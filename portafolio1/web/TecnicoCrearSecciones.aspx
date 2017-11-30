<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TecnicoCrearSecciones.aspx.cs" Inherits="web.TecnicoCrearSecciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .style2 {
            margin-left: 30%;
        }
        

        #mensajeSI, #mensajeNO, #mensajeNa,#mensajeSiM {
            display: table;
            margin: 0 auto;
        }
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
        <div class="panel-heading">
            <asp:Label ID="Label3" runat="server" Text="Agregar Seccion de preguntas" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
        <div class="panel-body">
            <div>
                <div id="mensajeSI" runat="server" class="alert alert-success" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡PREGUNTA AGREGADA EXITOSAMENTE!

                </div>
                <div id="mensajeSiM" runat="server" class="alert alert-success" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡PREGUNTA MODIFICADA EXITOSAMENTE!

                </div>
                <div id="mensajeNO" runat="server" class="alert alert-danger" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡DEBE ESCOGER CATEGORIA!

                  
                    (CODIGO EV05)</div>
                <div id="mensajeNa" runat="server" class="alert alert-danger" style="width: 90%" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡DEBE AGREGAR UNA PREGUNTA!

                  
                    (CODIGO EV06)</div>
            </div>


            <div class="form-group">
                <label for="em">Seleccione categoria</label>
                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">Seleccione categoría</asp:ListItem>
                </asp:DropDownList>

            </div>
            <br />
            &nbsp;
         <div class="form-group">
             <label for="em">Agregar pregunta</label>
             <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Ingrese pregunta" TextMode="SingleLine"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="El rango es de 1 a 150 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{1,150}$"></asp:RegularExpressionValidator>

         </div>
            <div class="form-group">
                <label for="em">Estado de la evaluación</label>
                <asp:DropDownList ID="DropDownList3" class="form-control" runat="server" AutoPostBack="false">
                    <asp:ListItem Value="Activo">Activo</asp:ListItem>
                    <asp:ListItem Value="Desactivado">Desactivado</asp:ListItem>
                </asp:DropDownList>

            </div>
            <asp:Button ID="Button1" runat="server" CssClass="btn alert-success center-block" Text="Agregar" Width="86px" OnClick="Button1_Click" />

            <asp:Button ID="Button2" runat="server" CssClass="btn alert-success center-block" Text="Modificar" Width="86px" OnClick="Button2_Click" />
            <br />
            <br />

            <br />
            <asp:Button ID="Button3" runat="server" CssClass="btn alert-danger center-block" Text="Cancelar" Width="86px" OnClick="Button3_Click" />


            <h4 style="text-align: center;">Listado de preguntas por categoria</h4>
            <div>
                <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" runat="server" EmptyDataText="No hay preguntas." CssClass="table table-bordered bs-table" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Pregunta1" HeaderText="Pregunta" SortExpression="Pregunta1" ControlStyle-Width="60%" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />


                         <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Modificar" CommandName="Select" HeaderText="Acción">
                        <HeaderStyle CssClass=" text-center" ForeColor="White" BackColor="#337ab7"></HeaderStyle>
                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                    </asp:ButtonField>

                    </Columns>
                </asp:GridView>




                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="lisatopreguntas" TypeName="BLL.PreguntasDTO">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" DefaultValue="1" Name="id" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>




            </div>







        </div>
    </div>
</asp:Content>
