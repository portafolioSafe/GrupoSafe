<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SuperMedAdd.aspx.cs" Inherits="web.Formulario_web119" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Crear capacitación" Font-Bold="True" Font-Size="Larger"></asp:Label>
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
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡MÉDICO AGREGADO EXITOSAMENTE!

                        </div>
           <div id="mensajeNO" runat="server" class="alert alert-danger"  style="width:90%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡ERROR DE CONEXIÓN, INTENTE OTRA VEZ!

                        </div>

    <label for="em">Rut Médico</label>
      <asp:TextBox ID="txtRut" CssClass="form-control" runat="server" ></asp:TextBox>

         <asp:Button ID="Button2" runat="server" CssClass="btn  btn-primary" Text="Verificar" OnClick="Button2_Click" />

  </div>
 

      <div class="form-group">

    <label for="tx_especialidad">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" Enabled="False" ></asp:TextBox>

  
         
  </div>
            <div class="form-group">

    <label for="tx_especialidad">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"  Enabled="False"></asp:TextBox>


                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtApellido" ErrorMessage="El rango es de 5 a 20 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{5,20}$"></asp:RegularExpressionValidator>
  

  </div>
                  <div class="form-group">

    <label for="tx_especialidad">Especialidad</label>

               <asp:TextBox ID="txtEspecialidad" CssClass="form-control" runat="server" Enabled="False" ></asp:TextBox>

  

  </div>
                  <div class="form-group">

    <label for="tx_especialidad">Correo</label>

             <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" Enabled="False" ></asp:TextBox>

  

  </div>
                  <div class="form-group">

    <label for="tx_especialidad">Contraseña</label>

          <asp:TextBox ID="txtPass" class="form-control" runat="server"  TextMode="Password" ValidationGroup="valivali" CssClass="form-control" Enabled="False"></asp:TextBox>
  

                      <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Valor fuera de rango" ControlToValidate="txtPass" MaximumValue="300" MinimumValue="10" Type="Integer" ForeColor="Red"  ValidationGroup="valivali" Font-Bold="False"></asp:RangeValidator>
  

  </div>
            <div class="form-group">

    <label for="tx_especialidad">Confirmar Contraseña</label>

                <asp:TextBox ID="txtPassconfirm" CssClass="form-control" runat="server" Enabled="False" TextMode="Password" ></asp:TextBox>

  
  

  </div>
           
  
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Agregar capacitación" ValidationGroup="valivali" OnClick="Button1_Click" CssClass="btn btn-primary" Enabled="False" />
     

        </div>
</div>





</asp:Content>
