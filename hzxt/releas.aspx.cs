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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.Now;
                string s1 = dt.Month.ToString();
                string s2 = dt.Day.ToString();
                DropDownList2.ClearSelection();
                DropDownList3.ClearSelection();
                DropDownList2.Items.FindByText(s1).Selected = true;
                DropDownList3.Items.FindByText(s2).Selected = true;
                for (int i = 0; i < 10; i++)
                {
                    DropDownList1.Items.Add(dt.AddYears(i).Year.ToString());
                }
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //检查是否已经存在
            //string username2 = TextBox1.Text.Trim();  //取出账号

            //string str = "server=(local);database=huzhuxt;Integrated Security=True";
            //SqlConnection mycon = new SqlConnection(str);
            //mycon.Open();

            //SqlCommand checkCmd = mycon.CreateCommand();         //创建SQL命令执行对象
            //string s = "select * from users where username='" + username2 + "'";
            //checkCmd.CommandText = s2;                           //执行SQL命令
            //SqlDataAdapter check = new SqlDataAdapter();       //实例化数据适配器
            //check.SelectCommand = checkCmd;                       //让适配器执行SELECT命令
            //DataSet checkData = new DataSet();                     //实例化结果数据集
            //int n = check.Fill(checkData, "register");              //将结果放入数据适配器，返回元祖个数
            if (Request.Cookies["un"].Value == "")
            {
                Response.Write("<script>alert('请先登录！')</script>");
            }
            else if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                Response.Write("<script>alert('请将任务信息填完整！')</script>");
            }
            else if (DropDownList2.SelectedValue.ToString() == "4" || DropDownList2.SelectedValue.ToString() == "6" || DropDownList2.SelectedValue.ToString() == "9" || DropDownList2.SelectedValue.ToString() == "11")
            {
                if (DropDownList3.SelectedValue.ToString() == "31")
                {
                    Response.Write("<script>alert('日期错误，请检查！')</script>");
                }
            }
            else if (DropDownList2.SelectedValue.ToString() == "2")
            {
                int y = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
                if (((y % 4 == 0) && (y % 100 != 0)) || (y % 400 == 0))    //闰年
                {
                    if (DropDownList3.SelectedValue.ToString() == "31" || DropDownList3.SelectedValue.ToString() == "30")
                    {
                        Response.Write("<script>alert('日期错误，请检查！')</script>");
                    }
                }
                else
                {
                    if (DropDownList3.SelectedValue.ToString() == "31" || DropDownList3.SelectedValue.ToString() == "30" || DropDownList3.SelectedValue.ToString() == "29")
                    {
                        Response.Write("<script>alert('日期错误，请检查！')</script>");
                    }
                }
            }
            else
            {
                string nowtime = DateTime.Now.ToString();
                string st1 = DropDownList1.SelectedValue.ToString() + "/" + DropDownList2.SelectedValue.ToString() + "/" + DropDownList3.SelectedValue.ToString() + " " + DropDownList4.SelectedValue.ToString() + ":" + DropDownList5.SelectedValue.ToString() + ":" + "00";
                DateTime endtime = Convert.ToDateTime(st1);
                string place = "三校区无限制";
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (this.CheckBoxList1.Items[i].Selected)
                    {
                        place = CheckBoxList1.Items[i].Text ;
                    }
                }
                Response.Write("<script>alert('发布成功！')</script>");
                //插入数据SQL  逻辑
                string str = "server=(local);database=huzhuxt;Integrated Security=True";
                SqlConnection mycon = new SqlConnection(str);
                mycon.Open();
                string s3 = "insert into task(releaser,time,title,content,flag,endtime,place) values ('" + Request.Cookies["un"].Value + "','" + DateTime.Now + "','" + TextBox1.Text + "','" + TextBox2.Text + "','0','" + endtime + "','" + place + "')";                            //编写SQL命令
                SqlCommand mycom = new SqlCommand(s3, mycon);          //初始化命令
                mycom.ExecuteNonQuery();             //执行语句
                mycon.Close();                       //关闭连接
                mycom = null;
                mycon.Dispose();                     //释放对象
                //Response.Redirect("zhujiemian.aspx");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
    }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("zhujiemian.aspx");
        }
    }
}