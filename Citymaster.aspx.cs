using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Citymaster : System.Web.UI.Page
{
    BLL bobj = new BLL();
    getset gobj = new getset();
    protected void Page_Load(object sender, EventArgs e)
    {
        errlbl.Visible = false;
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        gobj.Cityid = Convert.ToInt16(TextBox1.Text);
        gobj.Cityname = TextBox2.Text;
        gobj.Stateid = Convert.ToInt16(DropDownList1.SelectedValue);

        SqlParameter cid = new SqlParameter("@cityid", gobj.Cityid);
        SqlParameter cname = new SqlParameter("@cityname", gobj.Cityname);
        SqlParameter sid = new SqlParameter("@stateid", gobj.Stateid);

        SqlParameter[] ddata = new SqlParameter[3] { cid, cname,sid };

        try
        {
            int x = bobj.insert("CityInsert", ddata);

            if (x > 0)
            {
                errlbl.Visible = true;

                errlbl.Text = "Successfully Inserted";
            }
        }
        catch (Exception ex)
        {
            errlbl.Visible = true;
            errlbl.Text = ex.Message.ToString();
        }

     
    }
}