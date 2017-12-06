<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="asistenciaCapacitaciones.aspx.cs" Inherits="web.asistenciaCapacitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-default" style="margin-right: 10%; margin-left: 10%;">
  <div class="panel-heading"><asp:Label ID="Label3" runat="server" Text="Asistencia" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
  <div class="panel-body">

                          <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
      <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">

          <ContentTemplate>

              <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1">

              </asp:GridView>
              <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="web.asistenciaCapacitaciones">
                  <SelectParameters>
                      <asp:SessionParameter Name="id" SessionField="id_capacitacion" Type="Int32" />
                  </SelectParameters>
              </asp:ObjectDataSource>
          </ContentTemplate>

      </asp:UpdatePanel>


     
  </div>
            </div>
</asp:Content>
