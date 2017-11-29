<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SuperVisAdd.aspx.cs" Inherits="web.Formulario_web8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Crear visita médica" Font-Bold="True" Font-Size="Larger"></asp:Label>
      <style>
             #mensajeSI,#mensajeNO {
  display: table;
  margin: 0 auto;
}

      </style> 
       </div>


  <div class="panel-body">

     <div class="form-group">
         <div id="mensajeSI" runat="server" class="alert alert-success"  style="width:90%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡CAPACITACIÓN AGREGADA EXITOSAMENTE!

                        </div>
           <div id="mensajeNO" runat="server" class="alert alert-danger"  style="width:90%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡ERROR DE CONEXIÓN, INTENTE OTRA VEZ!

                        </div>

    <label for="em">Empresa</label>
      <asp:DropDownList ID="Comboemp" class="form-control" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre_empresa" DataValueField="Rut_empresa" ></asp:DropDownList>
  </div>
 

      <div class="form-group">

    <label for="tx_especialidad">Tipo de examen</label>

       <asp:DropDownList ID="Combotipocap" class="form-control" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" ></asp:DropDownList>

          <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="ListarTipoExamen" TypeName="BLL.tipo_examenDTO"></asp:ObjectDataSource>

  </div>
            <div class="form-group">

    <label for="tx_especialidad">Lugar</label>
                <asp:TextBox ID="txtLugar" CssClass="form-control" runat="server" ></asp:TextBox>


                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLugar" ErrorMessage="El rango es de 5 a 140 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{5,140}$"></asp:RegularExpressionValidator>
  

  </div>
                  <div class="form-group">

 
            <div class="form-group">

    <label for="tx_especialidad">Fecha</label>

                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#337ab7" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                </asp:Calendar>
  

  </div>
           
  
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Agregar visita médica" ValidationGroup="valivali" OnClick="Button1_Click" />
     

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListadoEmpresas" TypeName="BLL.EmpresaDTO"></asp:ObjectDataSource>
     

        </div>
</div>



</asp:Content>
