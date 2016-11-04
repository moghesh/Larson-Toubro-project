using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class statemaster : System.Web.UI.Page
{
    BLL bobj = new BLL();
    getset gobj = new getset();
    protected void Page_Load(object sender, EventArgs e)
    {
        errlbl.Visible = false;
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        gobj.Stateid = Convert.ToInt16(TextBox1.Text);
        gobj.Statename = TextBox2.Text;

        SqlParameter sid = new SqlParameter("@stateid", gobj.Stateid);
        SqlParameter sname = new SqlParameter("@statename", gobj.Statename);

        SqlParameter[] ddata = new SqlParameter[2] { sid, sname };

        try
        {
            int x = bobj.insert("StateInsert", ddata);

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