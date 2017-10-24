﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TecnicoCrearSecciones.aspx.cs" Inherits="web.TecnicoCrearSecciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1 {
            margin-left: 30%;
        }
         .style2 {
             margin-left: 30%;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Agregar Seccion de preguntas" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
  <div class="panel-body">
  
      
      <h4 style="text-align:center;">Seleccione categoria</h4>
      &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style1" Height="30px" Width="222px" DataSourceID="ObjectDataSource2" DataTextField="nombre" DataValueField="id" AutoPostBack="True">
          </asp:DropDownList>
      <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="ListarCategoria" TypeName="BLL.DTOCategoria"></asp:ObjectDataSource>
      <br />
      <h4 style="text-align:center">Agregar pregunta </h4>
&nbsp;
        <asp:TextBox ID="TextBox1"  runat="server" CssClass="style2" Width="265px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Agregar" Width="86px" OnClick="Button1_Click" />

       <h4 style="text-align:center;">Listado de preguntas poractegoria</h4>

      <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
          <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
          <Columns>
              <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
              <asp:BoundField DataField="pregunta" HeaderText="pregunta" SortExpression="pregunta" />
              <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" />
          </Columns>
      </asp:GridView>


     
      


     
      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="lisatopreguntas" TypeName="BLL.DTOPreguntas">
          <SelectParameters>
              <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="id" PropertyName="SelectedValue" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>


     
      


     
  </div>
            </div>
</asp:Content>