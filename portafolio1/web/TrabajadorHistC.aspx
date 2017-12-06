<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TrabajadorHistC.aspx.cs" Inherits="web.Formulario_web18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Historial capacitaciones" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
  <div class="panel-body">
           
     
  

      <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
          <Columns>
           <asp:BoundField DataField="Id_cap" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Id capacitación" SortExpression="Id_cap" >
               <HeaderStyle CssClass=" text-center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                </asp:BoundField>

              <asp:BoundField DataField="Area_cap" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Area" SortExpression="Id_cap" >
               <HeaderStyle CssClass=" text-center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                </asp:BoundField>
          <asp:BoundField DataField="Expositor" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Expositor" SortExpression="Expositor" >
               <HeaderStyle CssClass=" text-center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="Tema" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Tema" SortExpression="Tema" >
               <HeaderStyle CssClass=" text-center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                </asp:BoundField>
      <asp:BoundField DataField="Tipo" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Tipo" SortExpression="Tipo" >
               <HeaderStyle CssClass=" text-center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                </asp:BoundField>
  
                     </Columns>
      </asp:GridView>


     
      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="listarDetalleCapxUsuario" TypeName="BLL.capacitacionDTO">
          <SelectParameters>
              <asp:SessionParameter Name="nombre" SessionField="rut" Type="String" />
          </SelectParameters>
      </asp:ObjectDataSource>


     
  </div>
            </div>
</asp:Content>
