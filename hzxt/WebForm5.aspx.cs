using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hzxt
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        //protected string btname = "撤销任务";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "点击“选择”按钮撤销发布的任务";
                string str = "server=(local);database=huzhuxt;Integrated Security=True";
                SqlConnection conntype = new SqlConnection(str); //实例化SQLconnection类。连接数据库   
                conntype.Open();

                string s1 = "select num, title, releaser, accepter, endtime, place, [content] FROM task where releaser = '" + Request.Cookies["un"].Value + "'";
                SqlCommand cmd = new SqlCommand(s1, conntype);
                SqlDataReader dr = cmd.ExecuteReader();
                dlData2.DataSource = dr;
                dlData2.DataBind();
                dr.Close();
                conntype.Close();

            }

            
        }


        protected void dlData_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                string num = dlData2.DataKeys[e.Item.ItemIndex].ToString();
                //Label1.Text = num;
                //Response.Cookies["num"].Value = num;
                int nn = Convert.ToInt32(num);

                if (DropDownList1.SelectedValue.ToString() == "我发布的任务")
                {
                    string str1 = "server=(local);database=huzhuxt;Integrated Security=True";
                    SqlConnection mycon = new SqlConnection(str1);
                    string myupd = "DELETE FROM [huzhuxt].[dbo].[task] where num = " + nn;
                    SqlCommand mycom = new SqlCommand(myupd, mycon);
                    try
                    {
                        mycon.Open();
                        mycom.ExecuteNonQuery();
                        mycon.Close();
                        Response.Write("<script>alert('撤销成功！')</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('撤销失败！')</script>");
                    }
                    Button2_Click(null, EventArgs.Empty);
                }

                if (DropDownList1.SelectedValue.ToString() == "我接受的任务")
                {
                    string quxiao = null ;
                    string str1 = "server=(local);database=huzhuxt;Integrated Security=True";
                    SqlConnection mycon = new SqlConnection(str1);
                    string myupd = "UPDATE [huzhuxt].[dbo].[task] SET [accepter] ='" + quxiao + "',flag = '0' where num = " + nn;
                    SqlCommand mycom = new SqlCommand(myupd, mycon);
                    try
                    {
                        mycon.Open();
                        mycom.ExecuteNonQuery();
                        mycon.Close();
                        Response.Write("<script>alert('退单成功！')</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('退单失败！')</script>");
                    }
                    Button2_Click(null, EventArgs.Empty);
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.ToString() == "我发布的任务")
            {
                Label1.Text = "点击“选择”按钮撤销发布的任务";
                string str = "server=(local);database=huzhuxt;Integrated Security=True";
                SqlConnection conntype = new SqlConnection(str); //实例化SQLconnection类。连接数据库   
                conntype.Open();

                string s1 = "select num, title, releaser, accepter, endtime, place, [content] FROM task where releaser = '" + Request.Cookies["un"].Value + "'";
                SqlCommand cmd = new SqlCommand(s1, conntype);
                SqlDataReader dr = cmd.ExecuteReader();
                dlData2.DataSource = dr;
                dlData2.DataBind();
                dr.Close();
                conntype.Close();
            }
            if (DropDownList1.SelectedValue.ToString() == "我接受的任务")
            {
                Label1.Text = "点击“选择”按钮取消接受的任务";
                string str = "server=(local);database=huzhuxt;Integrated Security=True";
                SqlConnection conntype2 = new SqlConnection(str); //实例化SQLconnection类。连接数据库   
                conntype2.Open();

                string s2 = "select num, title, releaser, accepter, endtime, place, [content] FROM task where accepter = '" + Request.Cookies["un"].Value + "'";
                SqlCommand cmd2 = new SqlCommand(s2, conntype2);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dlData2.DataSource = dr2;
                dlData2.DataBind();
                dr2.Close();
                conntype2.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button2_Click(null, EventArgs.Empty);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("zhujiemian.aspx");
        }
    }
}