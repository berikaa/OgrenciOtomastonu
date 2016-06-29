<%@ Page Language="C#" AutoEventWireup="true" CodeFile="anasayfa.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style>       
       p.solid {border-style: solid;}
       .baslik {
            background:url(http://www.omu.edu.tr/sites/all/themes/anasayfa/images/ogrnci1.png), linear-gradient(to bottom, #C5D0A9 0%,#D1D9BB 0%,#6F9130 100%);
            color: white;
            padding: 115px;
        }   
        .orta {
            margin-top:70px;
            width: 1000px;
            padding:5px;
            float:left;
            height:140px;                   
        }
          .yan {
            width: 190px;
            padding:14px;
            float:left;                
        }
        .son {
            background-color: black;
            color: white;
            clear: both;
            text-align: center;
            padding: 10px;
        }
    </style>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body >
    <form id="form1" runat="server">

        <div class="baslik" >
             <h1>ÖĞRENCİ OTOMASYONU</h1>             
        </div>

        <div class="yan" >  
        </div>       

        <p class="solid"></p>

        <div class="orta">            
        <asp:Button ID="ButtonogrenciKyt" OnClick="ButtonogrenciKyt_Click" class="btn btn-danger btn-lg " runat="server" Text="ÖĞRENCİ KAYIT "  /> &emsp; 
        <asp:Button ID="ButtonogrenciLst" OnClick="ButtonogrenciLst_Click" class="btn btn-danger btn-lg" runat="server" Text="ÖĞRENCİ LİSTELE" />&emsp; 
        <asp:Button ID="ButtonNotEkle" OnClick="ButtonNotEkle_Click" class="btn btn-danger btn-lg" runat="server" Text="ÖĞRENCİ NOT EKLE" />&emsp; 
        <asp:Button ID="ButtonNotLst" OnClick="ButtonNotLst_Click" class="btn btn-danger btn-lg" runat="server" Text="ÖĞRENCİ NOT LİSTESİ" /> &emsp;          
        <asp:Button ID="btnCikis" OnClick="btnCikis_Click" class="btn btn-danger btn-lg" runat="server" Text="ÇIKIŞ" />           
        </div>

        <div class="son">
             <h4>İLETİŞİM BİLGİLERİ:</h4>
             <p>ADRES: **** &emsp;&emsp; TELEFON: ****</p>
             <p>FAKS: ****  &emsp;&emsp;  E_MAİL: ****</p>           
             <p>© 2016 - Her hakkı saklıdır.</p>
         </div>

    </form>
</body>
</html>
