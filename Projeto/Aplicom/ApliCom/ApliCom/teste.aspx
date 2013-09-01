<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="ApliCom.teste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <table>
     <tr><td>txtId<asp:TextBox ID="txtId" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtCodigo<asp:TextBox ID="txtCodigo" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtNome<asp:TextBox ID="txtNome" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtFone<asp:TextBox ID="txtFone" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtFax<asp:TextBox ID="txtFax" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtCelular<asp:TextBox ID="txtCelular" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtEmail<asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtContato<asp:TextBox ID="txtContato" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtIdTipoPessoa<asp:TextBox ID="txtIdTipoPessoa" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtIdPerfil<asp:TextBox ID="txtIdPerfil" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtCGC<asp:TextBox ID="txtCGC" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtRazaoSocial<asp:TextBox ID="txtRazaoSocial" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtIE<asp:TextBox ID="txtIE" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtIM<asp:TextBox ID="txtIM" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtLimite<asp:TextBox ID="txtLimite" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtDataAniversario<asp:TextBox ID="txtDataAniversario" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtBloqueio<asp:TextBox ID="txtBloqueio" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtBloqueioInformacao<asp:TextBox ID="txtBloqueioInformacao" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>txtDataBloqueio<asp:TextBox ID="txtDataBloqueio" runat="server" ></asp:TextBox> </td></tr>
     <tr><td>btnGravar<asp:Button ID="btnGravar" runat="server" onclick="btnGravar_Click"/></td> 
  </table>
</asp:Content>
