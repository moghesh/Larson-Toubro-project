using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Questionpage : System.Web.UI.Page
{
    BLL bobj = new BLL();
    getset gobj = new getset();
    protected void Page_Load(object sender, EventArgs e)
    {
        errlbl.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        gobj.Qid = Convert.ToInt16(TextBox2.Text);
        gobj.Qname = TextBox1.Text;

        SqlParameter qid = new SqlParameter("@qid", gobj.Qid);
        SqlParameter qname = new SqlParameter("@qname", gobj.Qname);

        SqlParameter[] ddata = new SqlParameter[2] { qid, qname };

        try
        {
            int x = bobj.insert("QueInsert", ddata);

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