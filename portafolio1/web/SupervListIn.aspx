<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SupervListIn.aspx.cs" Inherits="web.Formulario_web118" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
          <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
        <div class="panel-heading">
            <asp:Label ID="Label3" runat="server" Text="Mis evaluaciones" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
        <div class="panel-body">




            <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered bs-table" OnRowCommand="GridView1_RowCommand" EmptyDataText="No hay evaluaciones registradas" AutoGenerateColumns="False">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <Columns>

                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="10%">

                        <ItemStyle Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-Width="60%">

                        <ItemStyle Width="40%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" ItemStyle-Width="10%">

                        <ItemStyle Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="TipoEvaluacion" HeaderText="Tipo de evaluacion" ItemStyle-Width="20%">

                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Estado" HeaderText="Estado de la evaluacion" ItemStyle-Width="20%">

                        <ItemStyle Width="20%" />
                    </asp:BoundField>


                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Ver detalle" CommandName="Select" HeaderText="Acción">
                        <HeaderStyle CssClass=" text-center" ForeColor="White" BackColor="#337ab7"></HeaderStyle>
                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                    </asp:ButtonField>


                </Columns>
            </asp:GridView>




        </div>
    </div>

</asp:Content>
