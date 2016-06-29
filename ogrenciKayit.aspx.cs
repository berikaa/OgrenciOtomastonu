using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class adminpanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session["User"]))
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            sinifliste();
            fakulteliste();
            
        }
    }

    void sinifliste()
    {
        
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
            SqlDataReader Reader;
            SqlCommand cmd = new SqlCommand("SELECT sinifid,sinifad from tblSinif", con);

            try
            {

                con.Open();
                Reader = cmd.ExecuteReader();

                DropDownListsinif.DataSource = Reader;
                DropDownListsinif.DataValueField = "sinifid";
                DropDownListsinif.DataTextField = "sinifad";
                DropDownListsinif.DataBind();
                Reader.Close();
            }

            catch
            {
                Response.Write("Bir hata oluştu");
            }

            finally
            {
                con.Close();


           }
       
    }

    void bolumliste(int fakulte_id, DropDownList DropDownListbolum)
    {
        DropDownListbolum.Items.Clear();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblBolum where fakulteid= " + fakulte_id + " ORDER BY bolumad", con);
       
        try
        {

            con.Open();
            Reader = cmd.ExecuteReader();

            DropDownListbolum.DataSource = Reader;
            DropDownListbolum.DataValueField = "bolumid";
            DropDownListbolum.DataTextField = "bolumad";
            DropDownListbolum.DataBind();
            Reader.Close();
            
        }

        catch (Exception ex)
        {
            Response.Write("Bir hata oluştu");
        }

        finally
        {
            con.Close();

            
        }

    }
    void fakulteliste()
    {

        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT fakulteid,fakultead FROM tblFakulte order by fakultead ", con);

        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();

            DropDownListfakulte.DataSource = Reader;
            DropDownListfakulte.DataValueField = "fakulteid";
            DropDownListfakulte.DataTextField = "fakultead";
            DropDownListfakulte.DataBind();
            Reader.Close();
        }

        catch (Exception ex)
        {
            Response.Write("Bir hata oluştu");
        }

        finally
        {
            con.Close();


        }

    }

    protected void Buttonkyt_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextBoxno.Text) || string.IsNullOrWhiteSpace(TextBoxad.Text) || string.IsNullOrWhiteSpace(TextBoxsoyad.Text))
        {
            Response.Write("<script lang='JavaScript'> alert (' TÜM KUTUCUKLARI DOLDURUNUZ! ');</script>");
        }
        else
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into tblOgrenci(ogrencino,ogrenciad,ogrencisoyad,sinifid,bolumid) values ('" + TextBoxno.Text + "','" + TextBoxad.Text + "','" + TextBoxsoyad.Text + "','" + Convert.ToInt32(DropDownListsinif.SelectedValue) + "','" + Convert.ToInt32(DropDownListbolum.SelectedValue) + "')";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Connection.Open();

                int a = cmd.ExecuteNonQuery();
                Response.Write("<script lang='JavaScript'> alert (' BAŞARIYLA KAYIT OLDUNUZ ');</script>");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }
    }

    protected void DropDownListfakulte_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListfakulte.SelectedIndex == 0)
        {
            DropDownListbolum.DataSource = null;
            DropDownListbolum.Enabled = false;
        }
        else
        {
            DropDownListbolum.Enabled = true;
            int bolumid = Convert.ToInt32(DropDownListfakulte.SelectedValue.ToString());
            bolumliste(bolumid, DropDownListbolum);
        }

    }

    protected void Buttonanasayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("anasayfa.aspx");
    }
}