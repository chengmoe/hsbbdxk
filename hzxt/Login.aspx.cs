using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hzxt
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Click += Button3_Click;
            Button2.Click += Button3_Click;
            if (!IsPostBack)
            {
                Button3_Click(null, EventArgs.Empty);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();  //取出账号
            string password = TextBox2.Text.Trim();         //取出密码
            //string str = "server=.\sqlexpress;database=huzhuxt;uid=用户名;pwd=密码;Trusted_Connection=no";
            string str = "server=(local);database=huzhuxt;Integrated Security=True";
            SqlConnection mycon = new SqlConnection(str);
            mycon.Open();

            SqlCommand mycom = mycon.CreateCommand();         //创建SQL命令执行对象
            //string sql = "select * from userInfo where userName=@userName and password=@password";
            string s1 = "select * from users where username='" + username + "' and password='" + password + "'";
            mycom.CommandText = s1;                           //执行SQL命令
            SqlDataAdapter myDA = new SqlDataAdapter();       //实例化数据适配器
            myDA.SelectCommand = mycom;                       //让适配器执行SELECT命令
            DataSet myDS = new DataSet();                     //实例化结果数据集
            int n = myDA.Fill(myDS, "register");              //将结果放入数据适配器，返回元祖个数

            if (n != 0)
            {
                if (Button3.Text == TextBox3.Text)
                {
                    //Response.Write("<script>alert('欢迎" + Session["userName"] + ",您成功登录!');location.href='../secure/report/test2.aspx';</script>");
                    Response.Write("<script>alert('欢迎使用!')</script>");
                    //MessageBox.Show("欢迎使用！");             //登录成功
                    //Session["name"] = TextBox1.Text;
                    //Response.Redirect("zhujiemian.aspx");
                    string sname = TextBox1.Text;
                    Response.Cookies["un"].Value = sname;
                    //Response.Cookies["un"].Expires = DateTime.Now.AddDays(3);    //持久cookie，设为三天
                    Response.Redirect("zhujiemian.aspx");
                }
                else
                {
                    Response.Write("<script>alert('验证码填写错误')</script>");
                    TextBox3.Text = "";
                }
            }
            else
            {
                Response.Write("<script>alert('用户名或密码有错,请重新输入！')</script>");
                TextBox1.Text = "";   //清空账号
                TextBox2.Text = "";    //清空密码
                TextBox3.Text = "";    //清空验证码
                TextBox1.Focus();     //光标设置在账号上
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int minV = 12345, maxV = 98765;
            Button3.Text = random.Next(minV, maxV).ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //检查是否已经存在
            string username2 = TextBox1.Text.Trim();  //取出账号

            string str = "server=(local);database=huzhuxt;Integrated Security=True";
            SqlConnection mycon = new SqlConnection(str);
            mycon.Open();

            SqlCommand checkCmd = mycon.CreateCommand();         //创建SQL命令执行对象
            //string sql = "select * from userInfo where userName=@userName and password=@password";
            string s2 = "select * from users where username='" + username2 + "'";
            checkCmd.CommandText = s2;                           //执行SQL命令
            SqlDataAdapter check = new SqlDataAdapter();       //实例化数据适配器
            check.SelectCommand = checkCmd;                       //让适配器执行SELECT命令
            DataSet checkData = new DataSet();                     //实例化结果数据集
            int n = check.Fill(checkData, "register");              //将结果放入数据适配器，返回元祖个数


            if (n != 0)
            {
                Response.Write("<script>alert('用户名已存在！')</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
                //nickName.Text = "";//昵称
            }


            //确认密码
            //if (ensurePw.Text != userPw.Text)
            //{
            //    ensurePw.Text = "";
           // }

            //验证码
            else if (TextBox3.Text != Button3.Text)
            {
                Response.Write("<script>alert('验证码错误！')</script>");
                TextBox3.Text = "";
            }


            else if (TextBox1.Text == "" || TextBox2.Text.Length <= 6)
            {
                Response.Write("<script>alert('请将信息填完整！（密码要大于六位）')</script>");
            }
            else
            {
                Response.Write("<script>alert('注册成功！')</script>");
                //插入数据SQL  逻辑
                string s3 = "insert into users(username,password) values ('" + TextBox1.Text + "','" + TextBox2.Text + "')";                            //编写SQL命令
                SqlCommand mycom = new SqlCommand(s3, mycon);          //初始化命令
                mycom.ExecuteNonQuery();             //执行语句
                mycon.Close();                       //关闭连接
                mycom = null;
                mycon.Dispose();                     //释放对象
                //Session["name"] = TextBox1.Text;
                //Response.Redirect("zhujiemian.aspx");
                string sname = TextBox1.Text;
                Response.Cookies["un"].Value = sname;
                //Response.Cookies["un"].Expires = DateTime.Now.AddDays(3);
                Response.Redirect("zhujiemian.aspx");
            }
        }


    }
    
}