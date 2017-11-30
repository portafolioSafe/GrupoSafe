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
   
      </div>
           <div class="panel-body">
        <label for="tx_especialidad">Año</label>
        
               <asp:TextBox ID="txtyear"  CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtyear" ErrorMessage="Rango de 1900 a 2099" Font-Bold="False" ForeColor="Red" ValidationExpression="^(19|20)\d{2}$"></asp:RegularExpressionValidator>
  
        <br />
  

    </div>

      <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" DataSourceID="ObjectDataSource2" AutoGenerateColumns="False" CssClass="table table-bordered bs-table"  EmptyDataText="No hay datos que mostrar">
          <Columns>
              <%--  --%>

             
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
              <asp:BoundField DataField="Asistencia" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderText="Cupos" SortExpression="Asistencia" ItemStyle-Width="120px" >
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


                     
              <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-warning"  Text="Editar" CommandName="Select"  HeaderText="Acción" >
                  <HeaderStyle CssClass=" text-center" ForeColor="White" BackColor="#337ab7" ></HeaderStyle>
<ControlStyle CssClass="btn btn-warning"  ></ControlStyle>
              </asp:ButtonField>

          </Columns>
      </asp:GridView>


     
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="ListarCapacitacionxaño" TypeName="BLL.capacitacionDTO">
            <SelectParameters>
                <asp:ControlParameter ControlID="ComboEmpresa" Name="nombreEmpresa" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="txtyear" Name="year" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>


     
          </div>
            
</asp:Content>
