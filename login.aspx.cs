using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["kullanici"] = TextBoxkad.Text;
        Session["User"] = false;

    }

    protected void Buttongrs_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        try
        {
            con.Open();      
            SqlCommand cmd = new SqlCommand("select * from tblAdmin where kullaniciad='" + TextBoxkad.Text + "' and kullanicisfr='" + TextBoxsfr.Text + "'", con);
            SqlDataReader  Reader = cmd.ExecuteReader();

            if (Reader.Read())
            {
                Session["User"] = true;
                Response.Redirect("anasayfa.aspx");
            }

            else
                Label1.Visible = true;
                Response.Write("<script lang='JavaScript'> alert (' LÜTFEN DOĞRU BİLGİ GİRİNİZ! ');</script>");
            Reader.Close();
            con.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }
}