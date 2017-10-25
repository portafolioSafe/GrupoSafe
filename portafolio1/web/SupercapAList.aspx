<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SupercapAList.aspx.cs" Inherits="web.Formulario_web41" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Listar capacitaciones anuales " Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
  <div class="panel-body">
        <label for="tx_especialidad">Empresa</label>
      <asp:DropDownList ID="ComboEmpresa" runat="server" DataSourceID="ObjectDataSource1" CssClass="form-control" DataTextField="Nombre_empresa" DataValueField="Nombre_empresa" AutoPostBack="True"></asp:DropDownList>
  

      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListadoEmpresas" TypeName="BLL.EmpresaDTO"></asp:ObjectDataSource>
  

      <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource2" AutoGenerateColumns="False" EmptyDataText="No hay datos que mostrar">
          <Columns>
              <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
              <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
              <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
              <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
              <asp:BoundField DataField="Tema" HeaderText="Tema" SortExpression="Tema" />
              <asp:BoundField DataField="Expositor" HeaderText="Expositor" SortExpression="Expositor" />
              <asp:BoundField DataField="Asistencia" HeaderText="Asistencia" SortExpression="Asistencia" />
              <asp:BoundField DataField="Rut_empresa" HeaderText="Rut_empresa" SortExpression="Rut_empresa" />
              <asp:BoundField DataField="Tipo_cap" HeaderText="Tipo_cap" SortExpression="Tipo_cap" />
          </Columns>
      </asp:GridView>


     
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="ListarCapacitacionxEmpresa" TypeName="BLL.capacitacionDTO">
            <SelectParameters>
                <asp:ControlParameter ControlID="ComboEmpresa" Name="nombreEmpresa" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>


     
  </div>
            </div>
</asp:Content>
