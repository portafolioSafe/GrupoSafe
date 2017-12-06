<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SuperVisListar.aspx.cs" Inherits="web.Formulario_web121" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Listar visitas médicas" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
  <div class="panel-body">



      <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" CssClass="table table-bordered bs-table" DataSourceID="ObjectDataSource1" Width="90%" HorizontalAlign="Center">
          <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="10px" ItemStyle-Width="40px" HeaderStyle-CssClass=" text-center" ItemStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                    <FooterStyle HorizontalAlign="Center"></FooterStyle>

                    <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#337ab7"  CssClass=" text-center" Width="10px"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle"></ItemStyle>
              </asp:BoundField>
               <asp:BoundField DataField="Lugar" HeaderText="Lugar" SortExpression="Lugar" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass=" text-center" ItemStyle-HorizontalAlign="Center" >
                    <FooterStyle HorizontalAlign="Center"></FooterStyle>

                    <HeaderStyle HorizontalAlign="Center" BackColor="#337ab7"  CssClass=" text-center" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass=" text-center" ItemStyle-HorizontalAlign="Center" >
                    <FooterStyle HorizontalAlign="Center"></FooterStyle>

                    <HeaderStyle HorizontalAlign="Center" BackColor="#337ab7"  CssClass=" text-center" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
              </asp:BoundField>
           
              <asp:BoundField DataField="Rut_empresa" HeaderText="Empresa" SortExpression="Empresa" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass=" text-center" ItemStyle-HorizontalAlign="Center" >
                    <FooterStyle HorizontalAlign="Center"></FooterStyle>

                    <HeaderStyle HorizontalAlign="Center" BackColor="#337ab7"  CssClass=" text-center" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
              </asp:BoundField>
             

              <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass=" text-center" ItemStyle-HorizontalAlign="Center" >
                    <FooterStyle HorizontalAlign="Center"></FooterStyle>

                    <HeaderStyle HorizontalAlign="Center" BackColor="#337ab7"  CssClass=" text-center" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
              </asp:BoundField>
             <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Editar" CommandName="Select"  HeaderText="Acción" >
                  <HeaderStyle CssClass=" text-center" ForeColor="White" BackColor="#337ab7" ></HeaderStyle>
<ControlStyle CssClass="btn btn-warning"  ></ControlStyle>
              </asp:ButtonField>

             
          </Columns>
      </asp:GridView>
      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="listarVisitas" TypeName="BLL.visitasDTO"></asp:ObjectDataSource>
      </div>

  </div>




</asp:Content>
