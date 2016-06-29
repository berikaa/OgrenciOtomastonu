using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ogrenciNotListesi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session["User"]))
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            ogrencilistesi();
            derslistesi();
            sinfilistesi();
            bolumlistesi();
            fakultelistesi();
        }
    }
    void ogrencilistesi()
    {

        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT ogrencino,ogrenciad from tblOgrenci", con);
        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();
            DropDownListogrenci.DataSource = Reader;
            DropDownListogrenci.DataValueField = "ogrencino";
            DropDownListogrenci.DataTextField = "ogrencino";
            DropDownListogrenci.DataBind();
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

    void derslistesi()
    {
        //DropDownListdrsad.Items.Clear();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblDersler ", con);

        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();
            DropDownListders.DataSource = Reader;
            DropDownListders.DataValueField = "dersid";
            DropDownListders.DataTextField = "dersad";
            DropDownListders.DataBind();
            Reader.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Bir hata oluştuuuu");
        }
        finally
        {
            con.Close();

        }
    }

    void sinfilistesi()
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
    void bolumlistesi()
    {
        // DropDownListblm.Items.Clear();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblBolum ORDER BY bolumad", con);

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
    void fakultelistesi()
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

    protected void Buttonlist_Click(object sender, EventArgs e)
    {
        SqlDataReader reader;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        DataTable tbl = new DataTable();
        string ogrenci = DropDownListogrenci.SelectedValue.ToString().Split('-')[0].ToString();
        string ders = DropDownListders.SelectedValue.ToString().Split('-')[0].ToString();
        string bolum = DropDownListblm.SelectedValue.ToString().Split('-')[0].ToString();
        string fakulte = DropDownListfklt.SelectedValue.ToString().Split('-')[0].ToString();
        string sinif = DropDownListsnf.SelectedValue.ToString().Split('-')[0].ToString();
        SqlCommand cmd = new SqlCommand("select tblOgrenci.ogrencino as 'ÖĞRENCİ NO',CAST(tblOgrenci.ogrenciad AS nvarchar) + ' ' + CAST(tblOgrenci.ogrencisoyad AS nvarchar) as 'AD SOYAD',"
               + " tblSinif.sinifad as 'SINIF', tblBolum.bolumad as 'BÖLÜM', tblFakulte.fakultead as 'FAKÜLTE',"
               + " tblDersler.dersad as 'DERS', tblOgrenciNot.ogrencinotu as 'NOT' from tblOgrenci "
               + " INNER JOIN tblSinif ON tblOgrenci.sinifid = tblSinif.sinifid"
               + " INNER JOIN tblBolum ON tblOgrenci.bolumid = tblBolum.bolumid"
               + " INNER JOIN tblFakulte ON tblBolum.fakulteid = tblFakulte.fakulteid"
               + " INNER JOIN tblOgrenciNot ON tblOgrenci.ogrencino = tblOgrenciNot.ogrencino"
               + " INNER JOIN tblDersler ON tblOgrenciNot.dersid = tblDersler.dersid where tblOgrenci.ogrencino=" + ogrenci + " or"
               + " tblFakulte.fakulteid=" + fakulte + " or tblBolum.bolumid=" + bolum + " or tblSinif.sinifid=" + sinif + " or tblDersler.dersid=" + ders + "", con);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            GridViewliste.DataSource = reader;
            GridViewliste.DataBind();
            reader.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void Buttontmlist_Click(object sender, EventArgs e)
    {
        SqlDataReader reader;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        DataTable tbl = new DataTable();
        string bolum = DropDownListblm.SelectedValue.ToString().Split('-')[0].ToString();
        string fakulte = DropDownListfklt.SelectedValue.ToString().Split('-')[0].ToString();
        string sinif = DropDownListsnf.SelectedValue.ToString().Split('-')[0].ToString();
        SqlCommand cmd = new SqlCommand("select tblOgrenci.ogrencino as 'ÖĞRENCİ NO',CAST(tblOgrenci.ogrenciad AS nvarchar) + ' ' + CAST(tblOgrenci.ogrencisoyad AS nvarchar) as 'AD SOYAD',"
               + " tblSinif.sinifad as 'SINIF', tblBolum.bolumad as 'BÖLÜM', tblFakulte.fakultead as 'FAKÜLTE',"
               + " tblDersler.dersad as 'DERS', tblOgrenciNot.ogrencinotu as 'NOT' from tblOgrenci "
               + " INNER JOIN tblSinif ON tblOgrenci.sinifid = tblSinif.sinifid"
               + " INNER JOIN tblBolum ON tblOgrenci.bolumid = tblBolum.bolumid"
               + " INNER JOIN tblFakulte ON tblBolum.fakulteid = tblFakulte.fakulteid"
               + " INNER JOIN tblOgrenciNot ON tblOgrenci.ogrencino = tblOgrenciNot.ogrencino"
               + " INNER JOIN tblDersler ON tblOgrenciNot.dersid = tblDersler.dersid order by tblOgrenci.ogrencino ", con);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            GridViewliste.DataSource = reader;
            GridViewliste.DataBind();
            reader.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void Buttonanasayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("anasayfa.aspx");
    }

    protected void Buttonaktar_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
        HttpContext.Current.Response.Charset = "windows-1254";
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=öğrenciListesi.xls");
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridViewliste.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Kontrolün renderlandığı doğrulanıyor */
    }
}