using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class Login : System.Web.UI.Page
{
    getset getsetobj = new getset();
    BLL bobj = new BLL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        errlbl.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int flag = 0;

        getsetobj.Username = TextBox2.Text;
        getsetobj.Password = TextBox3.Text;

        if (flag == 0)
        {
            try
            {

            SqlParameter un = new SqlParameter("username", getsetobj.Username);
            SqlParameter pw = new SqlParameter("password", getsetobj.Password);


            SqlParameter[] ddata = new SqlParameter[2] { un, pw };

           
                int x = bobj.insert("AdminLogin", ddata);

                if (x > 0)
                {
                    flag = 1;
                    errlbl.Visible = true;

                    errlbl.Text = "admin login successfully";
                }
            }
            catch (Exception ex)
            {
                errlbl.Visible = true;
                errlbl.Text = ex.Message.ToString();
            }


        }
        if (flag == 0)
        {
            try
            {

            SqlParameter un = new SqlParameter("username", getsetobj.Username);
            SqlParameter pw = new SqlParameter("password", getsetobj.Password);


            SqlParameter[] ddata = new SqlParameter[2] { un, pw };

           
                int x = bobj.insert("UserLogin", ddata);

                if (x > 0)
                {
                    flag = 1;
                    errlbl.Visible = true;

                    errlbl.Text = "user login successfully";
                    Session["username"] = TextBox2.Text;
                    Response.Redirect("ChangePassword.aspx");
                }
            }
            catch (Exception ex)
            {
                errlbl.Visible = true;
                errlbl.Text = ex.Message.ToString();
            }

        }
        if (flag == 0)
        {
            errlbl.Visible = true;
            errlbl.Text = "Invalid info";
        }
    }

}
              
        
        

