using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Department : System.Web.UI.Page
{

    BLL bobj = new BLL();
    getset gobj = new getset();

    protected void Page_Load(object sender, EventArgs e)
    {
        errlbl.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        gobj.Deptid = Convert.ToInt16(TextBox1.Text);
        gobj.Deptname = TextBox2.Text;

        SqlParameter depid = new SqlParameter("@deptid", gobj.Deptid);
        SqlParameter depname = new SqlParameter("@deptname", gobj.Deptname);

        SqlParameter[] ddata = new SqlParameter[2] { depid, depname };

        try
        {
            int x = bobj.insert("DeptInsert", ddata);

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