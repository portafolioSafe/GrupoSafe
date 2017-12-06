<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClenteListC.aspx.cs" Inherits="web.Formulario_web111" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Listar capacitaciones" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
  <div class="panel-body">

       </div>
           <div class="panel-body">
        <label for="tx_especialidad">Año</label>
        
               <asp:TextBox ID="txtyear"  CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtyear" ErrorMessage="Rango de 1900 a 2099" Font-Bold="False" ForeColor="Red" ValidationExpression="^(19|20)\d{2}$"></asp:RegularExpressionValidator>
  
        <br />
  

    </div>
  

      <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" CssClass="table table-bordered bs-table" DataSourceID="ObjectDataSource1" Width="90%" HorizontalAlign="Center">
          <Columns>
              <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="10px" ItemStyle-Width="40px" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
<FooterStyle HorizontalAlign="Center"></FooterStyle>

<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#337ab7"  CssClass=" text-center" Width="10px"></HeaderStyle>

<ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="Tema" HeaderText="Tema" SortExpression="Tema" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass=" text-center" ItemStyle-HorizontalAlign="Center" >
<FooterStyle HorizontalAlign="Center"></FooterStyle>

<HeaderStyle HorizontalAlign="Center" BackColor="#337ab7"  CssClass=" text-center" ForeColor="White"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="Fecha" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Fecha" SortExpression="Fecha" HeaderStyle-HorizontalAlign="Center" >
<HeaderStyle HorizontalAlign="Center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle CssClass="text-center"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="Area" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Area" SortExpression="Area" >
<HeaderStyle CssClass=" text-center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle CssClass="text-center"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="Expositor" HeaderText="Expositor" SortExpression="Expositor" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="120px" >
<HeaderStyle HorizontalAlign="Center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="Asistencia" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Asistencia" SortExpression="Asistencia" ItemStyle-Width="120px" >
<HeaderStyle CssClass=" text-center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="Rut_empresa" HeaderText="Empresa" SortExpression="Rut_empresa" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" >
<HeaderStyle CssClass=" text-center" BackColor="#337ab7" ForeColor="White"></HeaderStyle>

<ItemStyle CssClass="text-center"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="Tipo_cap" HeaderText="Tipo" SortExpression="Tipo_cap" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" >
<HeaderStyle CssClass=" text-center" ForeColor="White" BackColor="#337ab7" ></HeaderStyle>

<ItemStyle CssClass="text-center"></ItemStyle>
              </asp:BoundField>
                        
          </Columns>
          <RowStyle HorizontalAlign="Center" /> </asp:GridView>

     
   <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListarCapacitacionxaño" TypeName="BLL.capacitacionDTO">
            <SelectParameters>
                <asp:SessionParameter Name="nombreEmpresa" SessionField="login" Type="String" />
                <asp:ControlParameter ControlID="txtyear" Name="year" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
</asp:Content>
