﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TecnicoAgregarEvaluacion.aspx.cs" Inherits="web.TecnicoAgregarEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script runat="server">


</script>

        <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
            <div class="panel-heading">
                <asp:Label ID="Label3" runat="server" Text="Agregar evaluacion" Font-Bold="True" Font-Size="Larger"></asp:Label>
            </div>

            <div class="panel-body">
                <div class="form-group">
                    <label for="em">Empresa</label>
                    <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" DataSourceID="ObjectDataSource1" DataTextField="nombre_empresa" DataValueField="rut_empresa">
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

                                            <asp:RadioButton ID="rb_Na" runat="server" GroupName="GpName" Text="Na" OnCheckedChanged="rb_Na_Click" AutoPostBack="true" />

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
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Registrar" OnClick="Button1_Click" />
                </div>


            </div>
        </div>
       
</asp:Content>