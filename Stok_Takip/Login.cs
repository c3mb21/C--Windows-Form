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

namespace Stok_Takip
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=StokDB;Integrated Security=True");

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            long rndnumber = rnd.Next(1000, 9999);
            lblrandom.Text = rndnumber.ToString();
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "Select * From Kullanıcılar where Username=@usernames AND Password=@passwords";
            SqlParameter prm1 = new SqlParameter("usernames", txtusername.Text.Trim());
            SqlParameter prm2 = new SqlParameter("passwords", txtpassword.Text.Trim());
            SqlCommand command = new SqlCommand(sql, baglanti);
            command.Parameters.Add(prm1);
            command.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            baglanti.Close();

            if (dt.Rows.Count > 0)
            {
                if (lblrandom.Text == txtverify.Text)
                {
                    toolStripStatusLabel1.Text = "Kayıt işlemi başarı ile gerçekleşti";
                    statusStrip1.Refresh();
                    Application.DoEvents();
                    Stok stok = new Stok();
                    stok.Show();
                    Close();

                }
                else
                {
                    toolStripStatusLabel1.Text = "Doğrulama Kodunu Kontrol Ediniz ! ";
                    statusStrip1.Refresh();
                    Application.DoEvents();
                }
            }

            else if (lblrandom.Text != txtverify.Text && dt.Rows.Count == 0)
            {
                toolStripStatusLabel1.Text = "Bilgilerinizi Kontrol Edip Tekrar Deneyiniz ! ";
                statusStrip1.Refresh();
                Application.DoEvents();
            }

            else
            {
                toolStripStatusLabel1.Text = "Kullanıcı Adı veya Şifrenizi Kontrol Ediniz ! ";
                statusStrip1.Refresh();
                Application.DoEvents();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
