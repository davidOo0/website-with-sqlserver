using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){
 
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=mycomputer;Initial Catalog=xywglxt;Integrated Security=True";
            con.Open();
            SqlCommand com = new SqlCommand("Select s.sno as 学号, s.sname as 姓名, s.ssex as 性别 , s.sbirthday as 生日,s.sscore as 分数,c.classname as 班级名 from student s left outer join class c on s.classno = c.classno", con);
            SqlDataAdapter sda = new SqlDataAdapter ();//取数据
            sda.SelectCommand = com;
            DataSet ds = new DataSet ();
            sda.Fill(ds, "t1");
            this.stu_dg1.DataKeyField= "学号";
            this.stu_dg1 .DataSource =ds.Tables ["t1"].DefaultView;
            this.stu_dg1 .DataBind ();
            con.Close();
            this.Panel1.Visible = false  ;
            this.Panel2.Visible = false;

        }
    }
  
    protected void Button1_Click(object sender, EventArgs e)
    {
       this.Panel2.Visible = false; 
        this.Panel1.Visible = true ;
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel2.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=mycomputer;Initial Catalog=xywglxt;Integrated Security=True";
        con.Open();
        SqlCommand com = new SqlCommand("insert into student(sno,sname,ssex,sbirthday,sscore,classno) Values(@sno,@sname,@ssex,@sbirthday,@sscore,@classno)", con);
        SqlParameter sq1 = new SqlParameter("@sno", SqlDbType.VarChar);
        SqlParameter sq2 = new SqlParameter("@sname", SqlDbType.VarChar);
        SqlParameter sq4 = new SqlParameter("@sbirthday", SqlDbType.DateTime);
        SqlParameter sq3 = new SqlParameter("@ssex", SqlDbType.VarChar);
        SqlParameter sq5 = new SqlParameter("@sscore", SqlDbType.Decimal);
        SqlParameter sq6 = new SqlParameter("@classno", SqlDbType.VarChar);
        sq1.Value = this.TextBox1.Text;
        sq2.Value = this.TextBox2.Text;
        sq3.Value = this.TextBox3.Text;
        sq4.Value = this.TextBox4.Text;
        sq5.Value = this.TextBox5.Text;
        sq6.Value = this.TextBox6.Text;
        com.Parameters.Add(sq1);
        com.Parameters.Add(sq2);
        com.Parameters.Add(sq3);
        com.Parameters.Add(sq4);
        com.Parameters.Add(sq5);
        com.Parameters.Add(sq6);
        com.ExecuteNonQuery();
        SqlCommand com1 = new SqlCommand("Select s.sno as 学号, s.sname as 姓名, s.ssex as 性别 , s.sbirthday as 生日,s.sscore as 分数,c.classname as 班级名 from student s left outer join class c on s.classno = c.classno", con);
        SqlDataAdapter sda = new SqlDataAdapter();//取数据
        sda.SelectCommand = com1;
        DataSet ds = new DataSet();
        sda.Fill(ds, "t1");
        this.stu_dg1.DataKeyField = "学号";
        this.stu_dg1.DataSource = ds.Tables["t1"].DefaultView;
        this.stu_dg1.DataBind();
        con.Close();
        this.Panel1.Visible = false;
        this.Panel2.Visible = false;
    }
   
    protected void stu_dg1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }


    protected void stu_dg1_EditCommand(object source, DataGridCommandEventArgs e)
    {
        this.stu_dg1.EditItemIndex = e.Item.ItemIndex;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=mycomputer;Initial Catalog=xywglxt;Integrated Security=True";
        con.Open();
        SqlCommand com = new SqlCommand("Select s.sno as 学号, s.sname as 姓名, s.ssex as 性别 , s.sbirthday as 生日,s.sscore as 分数,c.classname as 班级名 from student s left outer join class c on s.classno = c.classno", con);
        SqlDataAdapter sda = new SqlDataAdapter();//取数据
        sda.SelectCommand = com;
        DataSet ds = new DataSet();
        sda.Fill(ds, "t1");
        this.stu_dg1.DataKeyField = "学号";
        this.stu_dg1.DataSource = ds.Tables["t1"].DefaultView;
        this.stu_dg1.DataBind();
        con.Close();
    }
    protected void stu_dg1_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string key = this.stu_dg1.DataKeys[e.Item.ItemIndex].ToString();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=mycomputer;Initial Catalog=xywglxt;Integrated Security=True";
        con.Open();
        SqlCommand com = new SqlCommand("delete from student where sno = '"+key+"'", con);
        com.ExecuteNonQuery();
        SqlCommand com1 = new SqlCommand("Select s.sno as 学号, s.sname as 姓名, s.ssex as 性别 , s.sbirthday as 生日,s.sscore as 分数,c.classname as 班级名 from student s left outer join class c on s.classno = c.classno", con);
        SqlDataAdapter sda = new SqlDataAdapter();//取数据
        sda.SelectCommand = com1;
        DataSet ds = new DataSet();
        sda.Fill(ds, "t1");
        this.stu_dg1.DataKeyField = "学号";
        this.stu_dg1.DataSource = ds.Tables["t1"].DefaultView;
        this.stu_dg1.DataBind();
        con.Close();
    }
    protected void stu_dg1_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        this.stu_dg1.EditItemIndex = -1;
    }
    protected void stu_dg1_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        string name, sex, bir, score, cla;
        string key = this.stu_dg1.DataKeys[e.Item.ItemIndex].ToString();
        TextBox tb;
        tb = (TextBox)e.Item.Cells[3].Controls[0];
        name = tb.Text.Trim();
        tb = (TextBox)e.Item.Cells[4].Controls[0];
        sex = tb.Text.Trim();
        tb = (TextBox)e.Item.Cells[5].Controls[0];
        bir = tb.Text.Trim();
        tb = (TextBox)e.Item.Cells[6].Controls[0];
        score = tb.Text.Trim();
        tb = (TextBox)e.Item.Cells[7].Controls[0];
        cla = tb.Text.Trim();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=mycomputer;Initial Catalog=xywglxt;Integrated Security=True";
        con.Open();
        SqlCommand com = new SqlCommand("update student set sname='" + name + "' ,ssex= '" + sex + "', sbirthday= '" + bir + "',sscore='" + score + "'where sno ='" + key + "'", con);
        com.ExecuteNonQuery();
        this.stu_dg1.EditItemIndex = -1;
        SqlCommand com1 = new SqlCommand("Select s.sno as 学号, s.sname as 姓名, s.ssex as 性别 , s.sbirthday as 生日,s.sscore as 分数,c.classname as 班级名 from student s left outer join class c on s.classno = c.classno", con);
        SqlDataAdapter sda = new SqlDataAdapter();//取数据
        sda.SelectCommand = com1;
        DataSet ds = new DataSet();
        sda.Fill(ds, "t1");
        this.stu_dg1.DataKeyField = "学号";
        this.stu_dg1.DataSource = ds.Tables["t1"].DefaultView;
        this.stu_dg1.DataBind();
        con.Close();
    }
    protected void stu_dg1_ItemCreated(object sender, DataGridItemEventArgs e)
    {

    }
}