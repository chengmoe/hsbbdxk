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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nowtime = DateTime.Now.ToString();
                string str = "server=(local);database=huzhuxt;Integrated Security=True";
                SqlConnection conntype = new SqlConnection(str); //实例化SQLconnection类。连接数据库   
                conntype.Open();

                string s1 = "select num, title, releaser, endtime, place, [content] FROM task where flag = '0' AND datediff(n,cast('" + nowtime +"' as datetime),endtime) >0 " ;
                SqlCommand cmd = new SqlCommand(s1, conntype);
                SqlDataReader dr = cmd.ExecuteReader();
                dlData.DataSource = dr;
                dlData.DataBind();
                dr.Close();
                conntype.Close();
                
            }
        }

        //protected void dlData_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void dlData_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                string num = dlData.DataKeys[e.Item.ItemIndex].ToString();
                //Label1.Text = num;
                //Response.Cookies["num"].Value = num;
                int nn = Convert.ToInt32(num);

                string connstring = "server=(local);database=huzhuxt;Integrated Security=True";
                //1.构建数据库查询语句，X为你所查询的值所在的列名，table 为你保存数据的表名。根据某列的值等于Y查询出X；
                string sql = "select releaser,flag,endtime from task where num = " + nn;
                //2.投递数据库查询 _connstring 为数据库连接字符串
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                //3.执行数据库查询获取返回值
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                Boolean flag = (Boolean)dataReader["flag"];
                DateTime endtime = Convert.ToDateTime(dataReader["endtime"]);
                string releaser = Convert.ToString(dataReader["releaser"]);
                Label1.Text = releaser;
                string username = Request.Cookies["un"].Value;
                Label2.Text = username;
                conn.Close();
                DateTime dt3 = DateTime.Now;
                if (flag == true)
                {
                    Response.Write("<script>alert('您来晚了！任务已被接取')</script>");
                    Button2_Click(null, EventArgs.Empty);
                }
                
                else if (releaser.Equals(username, StringComparison.OrdinalIgnoreCase) == true)
                {
                    Response.Write("<script>alert('您不能接受自己发布的任务！')</script>");
                    Button2_Click(null, EventArgs.Empty);
                }
                else if (DateTime.Compare(dt3, endtime) > 0)
                {
                    Response.Write("<script>alert('任务截止日期已过！')</script>");
                    Button2_Click(null, EventArgs.Empty);
                }
                else
                {
                    string str1 = "server=(local);database=huzhuxt;Integrated Security=True";
                    SqlConnection mycon = new SqlConnection(str1);
                    string myupd = "UPDATE [huzhuxt].[dbo].[task] SET [accepter] ='" + Request.Cookies["un"].Value + "',flag = '1' where num = " + nn;
                    SqlCommand mycom = new SqlCommand(myupd, mycon);
                    try
                    {
                        mycon.Open();
                        mycom.ExecuteNonQuery();
                        mycon.Close();
                        Response.Write("<script>alert('接单成功！')</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('接单失败！')</script>");
                    }
                    Button2_Click(null, EventArgs.Empty);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string nowtime = DateTime.Now.ToString();
            string str = "server=(local);database=huzhuxt;Integrated Security=True";
            SqlConnection conntype = new SqlConnection(str); //实例化SQLconnection类。连接数据库   
            conntype.Open();

            string s1 = "select num, title, releaser, endtime, place, [content] FROM task where flag = '0' AND datediff(n,cast('" + nowtime + "' as datetime),endtime) >0 ";
            SqlCommand cmd = new SqlCommand(s1, conntype);
            SqlDataReader dr = cmd.ExecuteReader();
            dlData.DataSource = dr;
            dlData.DataBind();
            dr.Close();
            conntype.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("zhujiemian.aspx");
        }
    }
}