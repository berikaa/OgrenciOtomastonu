using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ogrenciNotEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session["User"]))
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            listele();
            ogrenciliste();
            DropDownListdrsad.Enabled = false;
        }    
    }

    void listele()
    {

        SqlDataReader reader;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        DataTable tbl = new DataTable();
        SqlCommand cmd = new SqlCommand("select id,tblOgrenciNot.ogrencino ,(CAST(tblOgrenci.ogrenciad AS nvarchar) + ' ' + CAST(tblOgrenci.ogrencisoyad AS nvarchar)) AS adsoyad,"
               + " tblDersler.dersad, ogrencinotu  from tblOgrenciNot "
               + " INNER JOIN tblOgrenci ON tblOgrenciNot.ogrencino=tblOgrenci.ogrencino"
               + " INNER JOIN tblDersler ON tblOgrenciNot.dersid = tblDersler.dersid order by tblOgrenciNot.ogrencino asc ", con);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            GridViewnot.DataSource = reader;
            GridViewnot.DataBind();
            reader.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }

    void ogrenciliste()
    {
        
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT ogrencino,ogrenciad from tblOgrenci", con);
        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();
            DropDownListogrno.DataSource = Reader;
            DropDownListogrno.DataValueField = "ogrencino";
            DropDownListogrno.DataTextField = "ogrencino";
            DropDownListogrno.DataBind();
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

    void dersliste(int ogrno, DropDownList DropDownListdrsad)
    {
        DropDownListdrsad.Items.Clear();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlDataReader Reader;
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblDersler WHERE bolumid=(select bolumid from tblOgrenci where ogrencino=" + ogrno + ") ", con);

        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();
            DropDownListdrsad.DataSource = Reader;
            DropDownListdrsad.DataValueField = "dersid";
            DropDownListdrsad.DataTextField = "dersad";
            DropDownListdrsad.DataBind();
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

    protected void DropDownListogrno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListogrno.SelectedIndex == 0)
        {
            DropDownListdrsad.DataSource = null;
            DropDownListdrsad.Enabled = false;
        }
        else
        {
            DropDownListdrsad.Enabled = true;
            int dersid = Convert.ToInt32(DropDownListogrno.SelectedValue.ToString());
            dersliste(dersid, DropDownListdrsad);
        }
    }

    protected void Buttonanasayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("anasayfa.aspx");
    }

    protected void Buttonekle_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        SqlCommand cmd = new SqlCommand();

                if (string.IsNullOrWhiteSpace(TextBoxnot.Text))
                {
                    Response.Write("<script lang='JavaScript'> alert (' NOT GİRİNİZ! ');</script>");
                }
                else
                {
                    try
                    {

                        if ((Convert.ToInt32(TextBoxnot.Text) > 0) && (Convert.ToInt32(TextBoxnot.Text) < 100))
                        {

                            cmd.CommandText = "insert into tblOgrenciNot(ogrencino,dersid,ogrencinotu) values ('" + Convert.ToInt32(DropDownListogrno.SelectedValue) + "','" + Convert.ToInt32(DropDownListdrsad.SelectedValue) + "','" + TextBoxnot.Text + "')";
                            // harfnotu();
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;

                            cmd.Connection.Open();

                            int a = cmd.ExecuteNonQuery();

                            Response.Write("<script lang='JavaScript'> alert (' BAŞARIYLA KAYIT OLDUNUZ ');</script>");
                            listele();
                        }
                        else
                        {
                            Response.Write("<script lang='JavaScript'> alert (' NOTUNUZU 0-100 ARALIĞINDA GİRİNİZ!! ');</script>");
                        }
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
     }
 
    protected void Buttonaktar_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
        HttpContext.Current.Response.Charset = "windows-1254";
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=öğrenciEklenenNot.xls");
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridViewnot.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Kontrolün renderlandığı doğrulanıyor */
    }

    protected void GridViewnot_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
            int studentId = Convert.ToInt32(GridViewnot.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from tblOgrenciNot where id='" + studentId + "' ";


            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            cmd.Connection.Open();

            int a = cmd.ExecuteNonQuery();
            Response.Write("<script lang='JavaScript'> alert (' VERİ SİLİNDİ ');</script>");
            listele();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void GridViewnot_DataBound(object sender, EventArgs e)
    {
        try
        {
            var gv = (GridView)sender;

            foreach (GridViewRow row in gv.Rows)
            {
               
                 if ((Convert.ToInt32(row.Cells[5].Text) >86) && (Convert.ToInt32(row.Cells[5].Text) < 101))
                 {
                     row.Cells[6].Text = "AA";
                 }                
                 else if ((Convert.ToInt32(row.Cells[5].Text) > 79) && (Convert.ToInt32(row.Cells[5].Text) < 87))
                 {
                     row.Cells[6].Text = "BA";
                 }
                 else if ((Convert.ToInt32(row.Cells[5].Text) > 73) && (Convert.ToInt32(row.Cells[5].Text) < 80))
                 {
                     row.Cells[6].Text = "BB";
                 }
                 else if ((Convert.ToInt32(row.Cells[5].Text) > 66) && (Convert.ToInt32(row.Cells[5].Text) < 74))
                 {
                     row.Cells[6].Text = "CB";
                 }
                 else if ((Convert.ToInt32(row.Cells[5].Text) > 59) && (Convert.ToInt32(row.Cells[5].Text) < 67))
                 {
                     row.Cells[6].Text = "CC";
                 }
                 else if ((Convert.ToInt32(row.Cells[5].Text) > 52) && (Convert.ToInt32(row.Cells[5].Text) < 60))
                 {
                     row.Cells[6].Text = "DC";
                 }
                else if ((Convert.ToInt32(row.Cells[5].Text) > 45) && (Convert.ToInt32(row.Cells[5].Text) < 53))
                 {
                    row.Cells[6].Text = "DD";
                 }
                else if ((Convert.ToInt32(row.Cells[5].Text) > 39) && (Convert.ToInt32(row.Cells[5].Text) < 46))
                 {
                    row.Cells[6].Text = "FD";
                 }
                else
                 {
                     row.Cells[6].Text = "FF";
                 }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}