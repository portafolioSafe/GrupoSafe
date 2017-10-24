<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SupercapEdit.aspx.cs" Inherits="web.Formulario_web6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

               <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Modificar capacitación" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
  <div class="panel-body">

     <div class="form-group">
<<<<<<< HEAD
         <div id="mensajeSI" runat="server" class="alert alert-success"  style="width:90%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡CAPACITACIÓN AGREGADA EXITOSAMENTE!

                        </div>
           <div id="mensajeNO" runat="server" class="alert alert-danger"  style="width:90%" visible="false">   
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span> &nbsp; ¡ERROR DE CONEXIÓN, INTENTE OTRA VEZ!

                        </div>

    <label for="em">Empresa</label>
      <asp:DropDownList ID="Comboemp" class="form-control" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre_empresa" DataValueField="Rut_empresa" ></asp:DropDownList>
  

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetlistarEmpresaList" TypeName="BLL.EmpresaDTO"></asp:ObjectDataSource>
     

     </div>
=======
    <label for="em">Capacitación anual</label>
      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"></asp:DropDownList>
  </div>
>>>>>>> 2dad8eb95b93d2065ade786ba24866566c0ffe6d
 

      <div class="form-group">

<<<<<<< HEAD
    <label for="tx_especialidad">Tipo de capacitacion</label>

       <asp:DropDownList ID="Combotipocap" class="form-control" runat="server" DataSourceID="ObjectDataSource2" DataTextField="nombre" DataValueField="id" ></asp:DropDownList>
=======
    <label for="tx_especialidad">Capacitación a editar</label>
>>>>>>> 2dad8eb95b93d2065ade786ba24866566c0ffe6d

       <asp:DropDownList ID="DropDownList2" class="form-control" runat="server"></asp:DropDownList>

  </div>
            <div class="form-group">

<<<<<<< HEAD
    <label for="tx_especialidad">Tema</label>
                <asp:TextBox ID="Txttema" CssClass="form-control" runat="server" ></asp:TextBox>
=======
    <label for="tx_especialidad">Nueva capacitación</label>
>>>>>>> 2dad8eb95b93d2065ade786ba24866566c0ffe6d

    <asp:DropDownList ID="DropDownList3" class="form-control" runat="server"></asp:DropDownList>

  </div>

<<<<<<< HEAD
    <label for="tx_especialidad">Area</label>

          <asp:DropDownList ID="Comboarea" class="form-control" runat="server" DataSourceID="ObjectDataSource3" DataTextField="Nombre_area" DataValueField="Nombre_area" ></asp:DropDownList>

                      <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="listarArea" TypeName="web.ServiceReference1.wsa1SoapClient"></asp:ObjectDataSource>
  

  </div>
                  <div class="form-group">

    <label for="tx_especialidad">Expositor</label>

          <asp:TextBox ID="txtExpositor" class="form-control" runat="server"  TextMode="Date"></asp:TextBox>
  

  </div>
                  <div class="form-group">

    <label for="tx_especialidad">Asistencia minima</label>

          <asp:TextBox ID="TxtAsistencia" class="form-control" runat="server"  TextMode="Number" ValidationGroup="valivali"></asp:TextBox>
  

                      <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Valor fuera de rango" ControlToValidate="txtasistencia" MaximumValue="300" MinimumValue="10" Type="Integer" ForeColor="Red"  ValidationGroup="valivali" Font-Bold="False"></asp:RangeValidator>
  

  </div>
            <div class="form-group">
=======
               <div class="form-group">
>>>>>>> 2dad8eb95b93d2065ade786ba24866566c0ffe6d

    <label for="tx_especialidad">Fecha</label>

                   <asp:TextBox ID="TextBox1" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
  </div>
 
  
<<<<<<< HEAD
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Agregar capacitación" ValidationGroup="valivali" OnClick="Button1_Click" />
=======
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Modificar" />
>>>>>>> 2dad8eb95b93d2065ade786ba24866566c0ffe6d
     

        </div>
</div>
 

</asp:Content>
