using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class ogrenciListe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session["User"]))
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            snfliste();
            fkltliste();
        }      
    }
    void snfliste()
    {
         // DropDownListsnf.Items.Clear();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT sinifid,sinifad from tblSinif", con);      
        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();
            DropDownListsnf.DataSource = Reader;
            DropDownListsnf.DataValueField = "sinifid";
            DropDownListsnf.DataTextField = "sinifad";
            DropDownListsnf.DataBind();
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
    void blmliste(int fklt_id, DropDownList DropDownListblm)
    {
        DropDownListblm.Items.Clear();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblBolum where fakulteid= " + fklt_id + " ORDER BY bolumad", con);

        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();
            DropDownListblm.DataSource = Reader;
            DropDownListblm.DataValueField = "bolumid";
            DropDownListblm.DataTextField = "bolumad";
            DropDownListblm.DataBind();
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
    void fkltliste()
    {
        
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT fakulteid,fakultead FROM tblFakulte order by fakultead ", con);

        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();
            DropDownListfklt.DataSource = Reader;
            DropDownListfklt.DataValueField = "fakulteid";
            DropDownListfklt.DataTextField = "fakultead";
            DropDownListfklt.DataBind();
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
    protected void Buttonliste_Click(object sender, EventArgs e)
    {
        SqlDataReader reader;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        DataTable tbl = new DataTable();
        string bolum = DropDownListblm.SelectedValue.ToString().Split('-')[0].ToString();
        string fakulte = DropDownListfklt.SelectedValue.ToString().Split('-')[0].ToString();
        string sinif = DropDownListsnf.SelectedValue.ToString().Split('-')[0].ToString();
        SqlCommand cmd = new SqlCommand("select ogrencino as 'ÖĞRENCİ NO',ogrenciad as 'ÖĞRENCİ AD',ogrencisoyad as 'ÖĞRENCİ SOYAD',"
               + " tblSinif.sinifad as 'SINIF', tblBolum.bolumad as 'BÖLÜM', tblFakulte.fakultead  as 'FAKÜLTE' from tblOgrenci "
               + " INNER JOIN tblSinif ON tblOgrenci.sinifid = tblSinif.sinifid"
               + " INNER JOIN tblBolum ON tblOgrenci.bolumid = tblBolum.bolumid"
               + " INNER JOIN tblFakulte ON tblBolum.fakulteid = tblFakulte.fakulteid where tblFakulte.fakulteid="+fakulte+""
               + " and tblBolum.bolumid="+bolum+" and tblSinif.sinifid="+sinif+"", con);
        try
        {     
            con.Open();
            reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            reader.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void Buttondok_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        HttpContext.Current.Response.Charset = "utf-8";
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=öğrenciListesi.xls");
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void DropDownListfklt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListfklt.SelectedIndex == 0)
        {
            DropDownListblm.DataSource = null;
            DropDownListblm.Enabled = false;
        }
        else
        {
            DropDownListblm.Enabled = true;
            int bolumid = Convert.ToInt32(DropDownListfklt.SelectedValue.ToString());
            blmliste(bolumid, DropDownListblm);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Kontrolün renderlandığı doğrulanıyor */
    }
    protected void Buttonanasayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("anasayfa.aspx");
    }


    protected void Buttontmliste_Click(object sender, EventArgs e)
    {
        SqlDataReader reader;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        DataTable tbl = new DataTable();
        string bolum = DropDownListblm.SelectedValue.ToString().Split('-')[0].ToString();
        string fakulte = DropDownListfklt.SelectedValue.ToString().Split('-')[0].ToString();
        string sinif = DropDownListsnf.SelectedValue.ToString().Split('-')[0].ToString();
        SqlCommand cmd = new SqlCommand("select ogrencino as 'ÖĞRENCİ NO',ogrenciad as 'ÖĞRENCİ AD',ogrencisoyad as 'ÖĞRENCİ SOYAD',"
               + " tblSinif.sinifad as 'SINIF', tblBolum.bolumad as 'BÖLÜM', tblFakulte.fakultead  as 'FAKÜLTE' from tblOgrenci "
               + " INNER JOIN tblSinif ON tblOgrenci.sinifid = tblSinif.sinifid"
               + " INNER JOIN tblBolum ON tblOgrenci.bolumid = tblBolum.bolumid"
               + " INNER JOIN tblFakulte ON tblBolum.fakulteid = tblFakulte.fakulteid ", con);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            reader.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
            int studentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from tblOgrenci where ogrencino='" + studentId + "' ";


            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            cmd.Connection.Open();

            int a = cmd.ExecuteNonQuery();
            Response.Write("<script lang='JavaScript'> alert (' VERİ SİLİNDİ ');</script>");
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}