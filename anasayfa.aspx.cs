using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session["User"]))
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void ButtonogrenciKyt_Click(object sender, EventArgs e)
    {
        Response.Redirect("ogrenciKayit.aspx");
    }

    protected void ButtonogrenciLst_Click(object sender, EventArgs e)
    {
        Response.Redirect("ogrenciListe.aspx");
    }

    protected void ButtonNotEkle_Click(object sender, EventArgs e)
    {
        Response.Redirect("ogrenciNotEkle.aspx");
    }

    protected void ButtonNotLst_Click(object sender, EventArgs e)
    {
        Response.Redirect("ogrenciNotListesi.aspx");
    }

    protected void btnCikis_Click(object sender, EventArgs e)
    {
        Session["User"] = false;
        Response.Redirect("Login.aspx");
    }
}