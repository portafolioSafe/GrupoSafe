<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TecnicoDetalleEvaluacion.aspx.cs" Inherits="web.TecnicoDetalleEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
        <div class="panel-heading">
            <asp:Label ID="Label3" runat="server" Text="Detalle evaluación" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
        <div class="panel-body">

            <div class="form-group">
                <label for="em">Empresa</label>
                <asp:Label ID="Empresa" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label for="em">Rut Empresa</label>
                <asp:Label ID="lbl_Rut" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="form-group">
                <label for="em">Tipo evaluación</label>
                <asp:Label ID="lbl_tipo" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="form-group">
                <label for="em">Fecha de evaluación</label>
                <asp:Label ID="lblfecha" runat="server" Text="Label"></asp:Label>
            </div>


            <div class="form-group">
                <label for="GridView1">Detalle respuestas</label>
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered bs-table" EmptyDataText="Error en la recuperación de respuestas" AutoGenerateColumns="false">
                      <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <Columns>

                        <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="10%">

                            <ItemStyle Width="10%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" ItemStyle-Width="60%">

                            <ItemStyle Width="40%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" ItemStyle-Width="10%">

                            <ItemStyle Width="10%" />
                        </asp:BoundField>



                    </Columns>


                </asp:GridView>
            </div>
               <div class="form-group">
                <label for="em">Observación Técnico</label>
                   <asp:TextBox ID="TextBox1" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

            </div>
            <div class="form-group">
                <label for="em">Recomendacion del Ingeniero</label>
                   <asp:TextBox ID="TextBox2" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

            </div>




            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Volver atras" OnClick="Button1_Click" />


        </div>



    </div>
</asp:Content>
