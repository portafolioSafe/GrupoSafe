<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TecnicoAgregarEvaluacion.aspx.cs" Inherits="web.TecnicoAgregarEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script runat="server">


</script>

        <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
            <div class="panel-heading">
                <style>
                    #mensajeSI, #mensajeNO,#MensajeNa {
                        display: table;
                        margin: 0 auto;
                    }
                </style> 


               
                <asp:Label ID="Label3" runat="server" Text="Agregar evaluación" Font-Bold="True" Font-Size="Larger"></asp:Label>
            </div>

            <div class="panel-body">
                 <div>
                    <div id="mensajeSI" runat="server" class="alert alert-success" style="width: 100%" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡EVALUACIÓN AGREGADA EXITOSAMENTE!

                    </div>
                    <div id="mensajeNO" runat="server" class="alert alert-danger" style="width: 100%" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡ERROR DE CONEXIÓN, INTENTE OTRA VEZ! (CODIGO EV00)

                    </div>
                        <div id="MensajeNa" runat="server" class="alert alert-info" style="width: 100%" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span class="glyphicon glyphicon-info-sign"></span>&nbsp; ¡DEBE COMPLETAR EL FORMULARIO! (CODIGO EV01)

                    </div>
                </div>
                <div class="form-group">
                    <label for="em">Empresa</label>
                    <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre_empresa" DataValueField="Rut_empresa">
                        <asp:ListItem>Seleccione empresa</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListadoEmpresas" TypeName="BLL.EmpresaDTO"></asp:ObjectDataSource>

                </div>
                <div class="form-group">
                    <label for="em">Tipo evaluación</label>
                    <asp:DropDownList ID="DropDownList2" class="form-control" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id">
                        <asp:ListItem>Seleccione una evaluacion</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="listadodeEvaluaciones" TypeName="BLL.TipoEvaluacionDTO"></asp:ObjectDataSource>



                </div>
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">

                        <ContentTemplate>

                            <asp:GridView ID="Grd" runat="server" CssClass="table table-bordered bs-table" EmptyDataText="No hay preguntas asociadas al tipo de evaluacion." AutoGenerateColumns="False" DataSourceID="ObjectDataSource3">
                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <Columns>

                                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="20%" >

                                    <ItemStyle Width="20%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Pregunta" ItemStyle-Width="40%" HeaderText="Pregunta" >


                                    <ItemStyle Width="40%" />
                                    </asp:BoundField>


                                    <asp:TemplateField ItemStyle-Width="40%" HeaderText="Accion">
                                        <ItemTemplate>

                                            <asp:RadioButton ID="rb_Yes" runat="server" GroupName="GpName" Text="Si" OnCheckedChanged="rb_Yes_Click" AutoPostBack="true" />

                                            <asp:RadioButton ID="rb_No" runat="server" GroupName="GpName" Text="No" OnCheckedChanged="rb_No_Click" AutoPostBack="true" />

                                            <asp:RadioButton ID="rb_Na" runat="server" GroupName="GpName" Text="No aplica" OnCheckedChanged="rb_Na_Click" AutoPostBack="true" />

                                        </ItemTemplate>

                                        <ItemStyle Width="40%" />

                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>

                            
                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetData" TypeName="web.TecnicoAgregarEvaluacion">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DropDownList2" DefaultValue="1" Name="idtipo" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>

                            
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>



                <div class="form-group">
                    <label for="tx_especialidad">Observaciones</label>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Ingrese Observaciones" TextMode="MultiLine"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="El rango es de 5 a 300 caracteres" Font-Bold="False" ForeColor="Red" ValidationExpression="^[\s\S]{5,300}$"></asp:RegularExpressionValidator>

                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Registrar" OnClick="Button1_Click" />
                </div>


            </div>
        </div>
       
</asp:Content>
