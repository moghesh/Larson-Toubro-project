using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class registrationpage : System.Web.UI.Page
{
    BLL bobj = new BLL();
    getset gobj = new getset();
    protected void Page_Load(object sender, EventArgs e)
    {
        errlbl.Visible= false;  

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string temp = null;
        if (FileUpload1.HasFile)
        {
            temp = "~/images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(temp));
        }

        gobj.UserId = Convert.ToInt16(TextBox1.Text);
        gobj.Name = TextBox2.Text;
        gobj.Address1 = TextBox3.Text;
        gobj.Address2 = TextBox4.Text;
        gobj.Stateid = Convert.ToInt16(DropDownList1.SelectedValue);
        gobj.Cityid = Convert.ToInt16(DropDownList2.SelectedValue);
        gobj.Pincode = TextBox9.Text;
        gobj.Email = TextBox8.Text;
        gobj.Contact = TextBox7.Text;
        gobj.Qid = Convert.ToInt16(DropDownList3.SelectedValue);
        gobj.Answer = TextBox10.Text;
        gobj.Username = TextBox11.Text;
        gobj.Password = TextBox12.Text;
        gobj.Image = temp;

        SqlParameter uid = new SqlParameter("@id", gobj.UserId);
        SqlParameter name = new SqlParameter("@name", gobj.Name);
        SqlParameter add1 = new SqlParameter("@add1", gobj.Address1);
        SqlParameter add2 = new SqlParameter("@add2", gobj.Address2);
        SqlParameter sid = new SqlParameter("@stateid", gobj.Stateid);
        SqlParameter cid = new SqlParameter("@cityid", gobj.Cityid);
        SqlParameter pin = new SqlParameter("@pincode", gobj.Pincode);
        SqlParameter contact = new SqlParameter("@contact", gobj.Contact);
        SqlParameter email = new SqlParameter("@email", gobj.Email);
        SqlParameter qid = new SqlParameter("@qid", gobj.Qid);
        SqlParameter answer = new SqlParameter("@answer", gobj.Answer);
        SqlParameter username = new SqlParameter("@username", gobj.Username);
        SqlParameter password = new SqlParameter("@password", gobj.Password);
        SqlParameter image = new SqlParameter("@image", gobj.Image);

        SqlParameter[] ddata = new SqlParameter[14] {uid,name,add1,add2,sid,cid,pin,contact,email,qid,answer,username,password,image };

        try
        {
            int x = bobj.insert("RegInsert", ddata);

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

