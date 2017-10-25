<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TecnicoListEv.aspx.cs" Inherits="web.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Mis evaluaciones" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
  <div class="panel-body">

     
  

      <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered bs-table" EmptyDataText="No hay evaluaciones registradas" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
          <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
          <Columns>
              <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
              <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
              <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
              <asp:BoundField DataField="Id_tipo" HeaderText="Id_tipo" SortExpression="Id_tipo" />
              <asp:BoundField DataField="Id_empresa" HeaderText="Id_empresa" SortExpression="Id_empresa" />
          </Columns>
      </asp:GridView>


     
      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListarEvaluacionTecnico" TypeName="BLL.EvaluacionDTO">
          <SelectParameters>
              <asp:SessionParameter Name="rut" SessionField="Rut" Type="String" />
          </SelectParameters>
      </asp:ObjectDataSource>


     
  </div>
            </div>

</asp:Content>
