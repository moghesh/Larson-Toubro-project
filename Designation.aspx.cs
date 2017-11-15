using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Designation : System.Web.UI.Page
{
    BLL bobj = new BLL();
    getset gobj = new getset();
    protected void Page_Load(object sender, EventArgs e)
    {
        errlbl.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        gobj.Desid = Convert.ToInt16(TextBox1.Text);
        gobj.Desname = TextBox2.Text;

        SqlParameter desid = new SqlParameter("@desid", gobj.Desid);
        SqlParameter desname = new SqlParameter("@desname", gobj.Desname);

        SqlParameter[] ddata = new SqlParameter[2] { desid, desname };

        try
        {
            int x = bobj.insert("DesInsert", ddata);

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