<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SuperMedAdd.aspx.cs" Inherits="web.Formulario_web119" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Crear capacitación" Font-Bold="True" Font-Size="Larger"></asp:Label>
      <style>
             #mensajeSI,#mensajeNO,#MensajeFound, #MensajeNotFound {
  display: table;
  margin: 0 auto;
}

      </style> 
       </div>


  <div class="panel-body">

     <div class="form-group">
         <div id="mensajeSI" runat="server" class="alert alert-success" role="alert"  style="width:100%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡MÉDICO AGREGADO EXITOSAMENTE!

                        </div>
           <div id="mensajeNO" runat="server" class="alert alert-danger"  role="alert"  style="width:100%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡ERROR DE CONEXIÓN, INTENTE OTRA VEZ! (CODIGO MED00)</div>
         <div id="MensajeFound" runat="server" class="alert alert-success" role="alert"   style="width:100%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡RUT VERIFICADO EN LA ESCUELA DE MÉDICOS!

                        </div>
                  <div id="MensajeNotFound" runat="server" class="alert alert-warning" role="alert"   style="width:100%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡RUT NO SE ENCUENTRA EN LA ESCUELA DE MÉDICOS!

                        </div>

    <label for="em">Rut Médico</label>
      <asp:TextBox ID="txtRut" CssClass="form-control" runat="server" ></asp:TextBox>
          <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ClientValidationFunction="validar_rut" ControlToValidate="txtRut" 
            Display="Dynamic" ErrorMessage="RUT no valido" SetFocusOnError="True" ForeColor="Red" ValidationGroup="memito1"></asp:CustomValidator>
        

         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRut" ErrorMessage="Campo Requerido" ForeColor="Red" ValidationGroup="memito1"></asp:RequiredFieldValidator>
        

  </div>
  <asp:Button ID="Button2" runat="server" CssClass="btn  btn-primary" Text="Verificar" OnClick="Button2_Click" ValidationGroup="memito1" />

      <div class="form-group">

    <label for="tx_especialidad">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" Enabled="False" ></asp:TextBox>

   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="El rango es de 3 a 50 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{3,50}$" ValidationGroup="memito" Display="Dynamic"></asp:RegularExpressionValidator>
  
         
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo Requerido" ForeColor="Red" ValidationGroup="memito"></asp:RequiredFieldValidator>
  
         
  </div>
            <div class="form-group">

    <label for="tx_especialidad">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"  Enabled="False"></asp:TextBox>


                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtApellido" ErrorMessage="El rango es de 3 a 50 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{3,50}$" ValidationGroup="memito" Display="Dynamic"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApellido" ErrorMessage="Campo Requerido" ForeColor="Red" ValidationGroup="memito"></asp:RequiredFieldValidator>
  

  </div>
                  <div class="form-group">

    <label for="tx_especialidad">Especialidad</label>

               <asp:TextBox ID="txtEspecialidad" CssClass="form-control" runat="server" Enabled="False" ></asp:TextBox>

   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEspecialidad" ErrorMessage="El rango es de 3 a 50 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{3,50}$" ValidationGroup="memito" Display="Dynamic"></asp:RegularExpressionValidator>
  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEspecialidad" ErrorMessage="Campo Requerido" ForeColor="Red" ValidationGroup="memito"></asp:RequiredFieldValidator>
  
  </div>
                  <div class="form-group">

    <label for="tx_especialidad">Correo</label>

             <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" Enabled="False" TextMode="Email" ></asp:TextBox>
                
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Debe ser un correo valido." ControlToValidate="txtCorreo" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="memito" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Campo Requerido" ForeColor="Red" ValidationGroup="memito"></asp:RequiredFieldValidator>
  
  </div>
                  <div class="form-group">

    <label for="tx_especialidad">Contraseña</label>

          <asp:TextBox ID="txtPass" class="form-control" runat="server"  TextMode="Password" ValidationGroup="valivali" CssClass="form-control" Enabled="False"></asp:TextBox>
  
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPass" ErrorMessage="El rango es de 8 a 15 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{8,15}$" ValidationGroup="memito" Display="Dynamic"></asp:RegularExpressionValidator>
                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPass" ErrorMessage="Campo Requerido" ForeColor="Red" ValidationGroup="memito"></asp:RequiredFieldValidator>
  
  </div>
            <div class="form-group">

    <label for="tx_especialidad">Confirmar Contraseña</label>

                <asp:TextBox ID="txtPassconfirm" CssClass="form-control" runat="server" Enabled="False" TextMode="Password" ControlToValidate="txtPassconfirm"></asp:TextBox>

        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Contraseñas no son iguales" ControlToCompare="txtPass" ControlToValidate="txtPassconfirm" ForeColor="Red" ValidationGroup="memito" Display="Dynamic"></asp:CompareValidator>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPassconfirm" ErrorMessage="Campo Requerido" ForeColor="Red" ValidationGroup="memito"></asp:RequiredFieldValidator>
  

  </div>
           
  
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Agregar médico" ValidationGroup="memito" OnClick="Button1_Click" CssClass="btn btn-primary" Enabled="False"  />
     

        </div>
</div>



        <script type="text/javascript">

            window.setTimeout(function () {
                $(".alert").fadeTo(500, 0).slideUp(500, function () {
                    $(this).remove();
                });
            }, 4000);


            function validar_rut(source, arguments) {
                var rut = arguments.Value; suma = 0; mul = 2; i = 0;

                for (i = rut.length - 3; i >= 0; i--) {
                    suma = suma + parseInt(rut.charAt(i)) * mul;
                    mul = mul == 7 ? 2 : mul + 1;
                }

                var dvr = '' + (11 - suma % 11);

                if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';
                {
                    if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr) {
                        arguments.IsValid = false;
                    }
                    else {
                        arguments.IsValid = true;
                    }
                }
            }

	
</script>

</asp:Content>
