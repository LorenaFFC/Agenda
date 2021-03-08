<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Agenda.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            E-mail<br />
            <asp:TextBox ID="txbemail" runat="server" BorderColor="#003366" BorderStyle="Inset" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox>
            <br />
            <br />
            Senha<br />
            <asp:TextBox ID="txbsenha" runat="server" BorderColor="#003366" BorderStyle="Inset" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnLogar" runat="server" BackColor="#003366" Font-Bold="True" Font-Size="Medium" ForeColor="White" OnClick="BtnLogar_Click" style="margin-right: 53px" Text="Login" />
            <br />
            <br />
            <asp:Label ID="IMsg" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Text="IMsg"></asp:Label>
        </div>
    </form>
</body>
</html>
