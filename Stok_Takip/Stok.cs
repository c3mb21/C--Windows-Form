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
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=StokDB;Integrated Security=SSPI");
        SqlCommand command;
        SqlDataAdapter da;
        System.Windows.Forms.BindingSource bindingSource = new System.Windows.Forms.BindingSource();
        void DataShow()
        {
            SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=StokDB;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT *FROM Ürünler", baglanti);
            DataTable table = new DataTable();
            da.Fill(table);
            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;
            baglanti.Close();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            DataShow();
            toolStripStatusLabel1.Text = "Ürünler  Listeleniyor !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            string sorgu1 = "INSERT INTO Ürünler(Ad,Fiyat,Ülke,İşlem_Tarihi,Notlar) VALUES (@Ad,@Fiyat,@Ülke,@İşlem_Tarihi,@Notlar)";
            command = new SqlCommand(sorgu1, baglanti);
            command.Parameters.AddWithValue("@Ad", txtad.Text);
            command.Parameters.AddWithValue("@Fiyat", txtfiyat.Text);
            command.Parameters.AddWithValue("@Ülke", txtülke.Text);
            command.Parameters.AddWithValue("@İşlem_Tarihi", dtpduedate.Value);
            command.Parameters.AddWithValue("@Notlar", rtbtask.Text);
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel1.Text = "Ürün Başarılı Bir Şekilde Eklendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void btndüzenle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Ürünler SET Ad = @Ad,Fiyat = @Fiyat,Ülke = @Ülke,İşlem_Tarihi=@İşlem_Tarihi,Notlar = @Notlar  WHERE ID = @ID";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtid.Text));
            command.Parameters.AddWithValue("@Ad", txtad.Text);
            command.Parameters.AddWithValue("@Fiyat", txtfiyat.Text);
            command.Parameters.AddWithValue("@Ülke", txtülke.Text);
            command.Parameters.AddWithValue("@İşlem_Tarihi", dtpduedate.Value);
            command.Parameters.AddWithValue("@Notlar", rtbtask.Text);
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel1.Text = "Ürün Başarılı Bir Şekilde Güncellendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Ürünler WHERE ID=@ID";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtid.Text));
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel1.Text = "Ürün Başarılı Bir Şekilde Silindi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is RichTextBox)
                {
                    item.Text = "";
                }
                if (item is DateTimePicker)
                {
                    item.ResetText();
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                if (item is NumericUpDown)
                {
                    item.Text = "";
                }
            }
            toolStripStatusLabel1.Text = "Bütün Yazılar Temizlendi ! ";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void Stok_Load(object sender, EventArgs e)
        {
            dtpduedate.Format = DateTimePickerFormat.Custom;
            dtpduedate.CustomFormat = "yyyy-MM-dd";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtfiyat.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtülke.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dtpduedate.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            rtbtask.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (bindingSource.DataSource != null)
            {
                bindingSource.Filter = string.Format("Ad LIKE '%{0}%' OR Fiyat LIKE '%{0}%' OR Ülke LIKE '%{0}%' OR Notlar LIKE '%{0}%'", txtArama.Text);
            }
        }
    }
}
