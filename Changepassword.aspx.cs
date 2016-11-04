using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Changepassword : System.Web.UI.Page
{
    getset getsetobj = new getset();
    BLL bobj = new BLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Label5.Visible = false;
            TextBox1.Text = Session["usernaeme"].ToString();
            TextBox1.Enabled = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        SqlParameter un = new SqlParameter("@username", TextBox1.Text);
        SqlParameter opw = new SqlParameter("@oldpassword", TextBox2.Text);
        SqlParameter npw = new SqlParameter("@newpassword", TextBox3.Text);

        SqlParameter[] ddata = new SqlParameter[3] { un, opw, npw };

        try
        {
            int x = bobj.insert("ChangePassword", ddata);

            if (x > 0)
            {
                Label5.Visible = true;

                Label5.Text = "Successfully Inserted";
            }
        }
        catch (Exception ex)
        {
            Label5.Visible = true;
            Label5.Text = ex.Message.ToString();
        }


    }
}