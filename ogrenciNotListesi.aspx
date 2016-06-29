<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ogrenciNotListesi.aspx.cs" Inherits="ogrenciNotListesi" %>
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
        <h1 class="baslik">ÖĞRENCİ NOT LİSTELE </h1><br />
        
         <asp:Label ID="Label5" runat="server" Text="Öğrenci No:" CssClass="textboxLabel1"></asp:Label>
        <asp:DropDownList ID="DropDownListogrenci" CssClass="btn btn-default dropdown-toggle dropdowlist" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
             <asp:ListItem Value="0" Text="Seçiniz."></asp:ListItem>  
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Fakülte:" CssClass="textboxLabel1"></asp:Label>
        <asp:DropDownList ID="DropDownListfklt" CssClass="btn btn-default dropdown-toggle dropdowlist" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
             <asp:ListItem Value="0" Text="Seçiniz."></asp:ListItem>  
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Bölüm:" CssClass="textboxLabel1"></asp:Label>
        <asp:DropDownList ID="DropDownListblm" CssClass="btn btn-default dropdown-toggle dropdowlist" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
             <asp:ListItem Value="0" Text="Seçiniz."></asp:ListItem>  
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Sınıf:" CssClass="textboxLabel1"></asp:Label>
        <asp:DropDownList ID="DropDownListsnf" CssClass="btn btn-default dropdown-toggle dropdowlist" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
             <asp:ListItem Value="0" Text="Seçiniz."></asp:ListItem>  
        </asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Text="Ders:" CssClass="textboxLabel1"></asp:Label>
        <asp:DropDownList ID="DropDownListders" CssClass="btn btn-default dropdown-toggle dropdowlist" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
             <asp:ListItem Value="0" Text="Seçiniz."></asp:ListItem>  
        </asp:DropDownList> <br /><br />
        
        <asp:Button ID="Buttonlist" CssClass="btn btn-success buton" OnClick="Buttonlist_Click" runat="server" Text="LİSTELE" />  
        <asp:Button ID="Buttontmlist" CssClass="btn btn-success buton" OnClick="Buttontmlist_Click" runat="server" Text="TÜMÜNÜ LİSTELE" />
        <asp:Button ID="Buttonanasayfa" CssClass="btn btn-danger buton" OnClick="Buttonanasayfa_Click" runat="server" Text="ANASAYFA" /><br /><br />     
        <asp:GridView ID="GridViewliste"  CssClass="table table-hover Grid"    runat="server" ></asp:GridView><br />
        
        <asp:Button ID="Buttonaktar" CssClass="btn btn-success buton" OnClick="Buttonaktar_Click" runat="server" Text="EXCEL'E AKTAR" />
        
    </div>
    </form>
</body>
</html>
