<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <link href="style.css" rel="stylesheet" />
</head>
<body >
    <form id="form1" runat="server">
    <div class="ortalama">
        <h1 class="baslik1" > GİRİŞ PANELİ </h1> <br />

        <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı:" CssClass="textboxLabelgrs" ></asp:Label>
        <asp:TextBox ID="TextBoxkad" runat="server" CssClass="form-control  textbox" placeholder="Kullanıcı Adı"></asp:TextBox> <br />

        <asp:Label ID="Label2" runat="server" Text="Şifre:" CssClass ="textboxLabelgrs" ></asp:Label>
        <asp:TextBox ID="TextBoxsfr" runat="server" CssClass="form-control textbox" TextMode="Password" placeholder="Şifre"></asp:TextBox><br />

        <asp:Button ID="Buttongrs" runat="server" OnClick="Buttongrs_Click" CssClass="btn btn-success buton" Text="GİRİŞ " />

    </div>
    </form>
</body>
</html>
