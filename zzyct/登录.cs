using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zzyct
{
    public partial class 登录 : Form
    {

        public 登录()
        {
            InitializeComponent();
            Random random = new Random();
            int minV = 12345, maxV = 98765;
            button3.Text = random.Next(minV, maxV).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();  //取出账号
            string password = textBox2.Text.Trim();         //取出密码
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
                if (button3.Text == textBox3.Text)
                {
                    MessageBox.Show("欢迎使用！");             //登录成功
                    this.Close();

                }
                else
                {
                    MessageBox.Show("验证码填写错误");
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("用户名或密码有错,请重新输入！");
                textBox1.Text = "";   //清空账号
                textBox2.Text = "";    //清空密码
                textBox3.Text = "";    //清空验证码
                button3.PerformClick();
                textBox1.Focus();     //光标设置在账号上
            }

        }


        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int minV = 12345, maxV = 98765;
            button3.Text = random.Next(minV, maxV).ToString();
        }
    }
}
