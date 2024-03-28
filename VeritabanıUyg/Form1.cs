using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VeritabanıUyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source= Database3.accdb;");
        public DataSet ds = new DataSet();
        private void Form1_Load(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Tablo1", baglan);
            da.Fill(ds, "Tablo1");
            dataGridView1.DataSource = ds.Tables["Tablo1"];
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand kmt = new OleDbCommand("insert into tablo1(ad,soyad,memleket,yas) values('"
           + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')",
           baglan);
            kmt.Connection = baglan;
            kmt.ExecuteNonQuery();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            ds.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from tablo1", baglan);
            da.Fill(ds, "tablo1");
            dataGridView1.DataSource = ds.Tables["tablo1"];
            baglan.Close();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Datagridview'de hücre üzerine tıklandığında Textleri doldurma
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand kmt = new OleDbCommand("update tablo1 set soyad='" + textBox2.Text +
           "',memleket='" + textBox3.Text + "',yas='" + textBox4.Text + "' where ad='" + textBox1.Text + "'",
           baglan);
            kmt.Connection = baglan;
            kmt.ExecuteNonQuery();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            ds.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from tablo1", baglan);
            da.Fill(ds, "tablo1");
            dataGridView1.DataSource = ds.Tables["tablo1"];
            baglan.Close();
        }
        private void button3_Click(object sender, EventArgs e) // Veri Silme
        {
            baglan.Open();
            OleDbCommand kmt = new OleDbCommand("delete from tablo1 where ad='" + textBox1.Text + "'", baglan);
            kmt.Connection = baglan;
            kmt.ExecuteNonQuery();

            textBox1.Clear();
            ds.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from tablo1", baglan);
            da.Fill(ds, "tablo1");
            dataGridView1.DataSource = ds.Tables["tablo1"];
            baglan.Close();

        }
    }
}
