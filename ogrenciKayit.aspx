<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ogrenciKayit.aspx.cs" Inherits="adminpanel" %>

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
<body>
  <form id="form1" runat="server">
    <div>
      <h1 class="baslik" >ÖĞRENCİ KAYIT  </h1>
        <asp:Label ID="Labelno" runat="server" Text="Öğrenci Numarası:" CssClass="textboxLabel"></asp:Label>
              <asp:TextBox ID="TextBoxno" CssClass="form-control textbox" runat="server" placeholder="Öğrenci Numarası"></asp:TextBox><br />
        
        <asp:Label ID="Labelad" runat="server" Text="Öğrenci Ad:" CssClass="textboxLabel"></asp:Label>
              <asp:TextBox ID="TextBoxad" CssClass="form-control textbox" runat="server" placeholder="Öğrenci Ad"></asp:TextBox><br />

        <asp:Label ID="Labelsoyad" runat="server" Text="Öğrenci Soyad:" CssClass="textboxLabel"></asp:Label>
              <asp:TextBox ID="TextBoxsoyad" CssClass="form-control textbox" runat="server" placeholder="Öğrenci Soyad"></asp:TextBox><br />

        <asp:Label ID="Labelsinif" runat="server" Text="Sınıf:" CssClass="textboxLabel"></asp:Label><br />
        <asp:DropDownList ID="DropDownListsinif" CssClass="btn btn-default dropdown-toggle dropdowlist2 " runat="server" AppendDataBoundItems="true">
                <asp:ListItem Value="0" Text="Seçiniz."></asp:ListItem>
        </asp:DropDownList> <br /><br />

        <asp:Label ID="Labelfakulte" runat="server" Text="Fakülte:" CssClass="textboxLabel"></asp:Label> <br />
        <asp:DropDownList ID="DropDownListfakulte" CssClass="btn btn-default dropdown-toggle dropdowlist2 " runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownListfakulte_SelectedIndexChanged">
                <asp:ListItem Value="0" Text="Seçiniz."></asp:ListItem>
        </asp:DropDownList><br /><br />

        <asp:Label ID="Labelbolum" runat="server" Text="Bölüm:" CssClass="textboxLabel"></asp:Label><br />
        <asp:DropDownList ID="DropDownListbolum" CssClass=" btn btn-default dropdown-toggle dropdowlist2 " runat="server" AppendDataBoundItems="true">
                <asp:ListItem Value="0" Text="Seçiniz."></asp:ListItem>
        </asp:DropDownList><br /><br />

        <asp:Button ID="Buttonkyt" OnClick="Buttonkyt_Click" CssClass="btn btn-success buton" runat="server" Text="KAYDET" /> &ensp; &ensp;

        <asp:Button ID="Buttonanasayfa" OnClick="Buttonanasayfa_Click" CssClass="btn btn-danger buton" runat="server" Text="ANASAYFA" />

     </div>
    </form>
</body>
</html>
