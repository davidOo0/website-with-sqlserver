using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=mycomputer;Initial Catalog=xywglxt;Integrated Security=True";
        con.Open();
        if (this.DropDownList1.SelectedItem.Value.Equals("students"))
        {
            SqlCommand com = new SqlCommand("select count(*) from student where sname = '" + this.TextBox1.Text + "' And sno= '" + this.TextBox2.Text + "'", con);
            
            int n = Convert.ToInt32(com.ExecuteScalar());

            if (n > 0)
            {
               Response.Redirect("student.aspx");
            }
            else
            {
                this.Label1.Text = "输入学生用户名或密码错误"; 
            }
        }
       else {
            SqlCommand com = new SqlCommand("select count(*) from teacher where tname = '" + this.TextBox1.Text + "' And tno= '" + this.TextBox2.Text + "'", con);
             int n = Convert.ToInt32(com.ExecuteScalar());

            if (n > 0)
            {
                Response.Redirect("teacher.aspx");
            }
            else
            {
                this.Label1.Text = "输入管理员用户名或密码错误";
            }
        }
        
    }
}