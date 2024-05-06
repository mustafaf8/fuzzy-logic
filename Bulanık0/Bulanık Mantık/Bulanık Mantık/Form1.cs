using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace BulanıkMantık
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        Kural k = new Kural();
        private void Form1_Load(object sender, EventArgs e)//DataGridview e Verileri Çekme
        {
           
            k.DosyadanOku();
            tablo.Columns.Add("No", typeof(int));
            tablo.Columns.Add("Hassaslık", typeof(string));
            tablo.Columns.Add("Miktar", typeof(string));
            tablo.Columns.Add("Kirlilik", typeof(string));
            tablo.Columns.Add("Dönüş Hızı", typeof(string));
            tablo.Columns.Add("Süre", typeof(string));
            tablo.Columns.Add("Deterjan", typeof(string));
            
            for (int i = 0; i < k.L.Count; i++)
            {

                tablo.Rows.Add(k.L[i].Split('-')[0], k.L[i].Split('-')[1], k.L[i].Split('-')[2], k.L[i].Split('-')[3], k.L[i].Split('-')[4], k.L[i].Split('-')[5], k.L[i].Split('-')[6]);
                dataGridView1.DataSource = tablo;
            }
            
            dataGridView1.ClearSelection();
            dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

        }

        Bulanık bn;
        public void renklendir()//Renkleri Seç
        {
            for (int i = 0; i < bn.Renklendir.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                renk.BackColor = Color.LightBlue;
                renk.ForeColor = Color.Black;
                dataGridView1.Rows[bn.Renklendir[i]].DefaultCellStyle = renk;
            }
        }
        public void datagridsıfırla()//Datagrid ilk anına dönder
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }
        private void button1_Click(object sender, EventArgs e)//Bulanıklaştırma Datagridview de Kuralları Gösterme
        {
            
            datagridsıfırla();
         
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            bn = new Bulanık(Convert.ToDouble(numericUpDown1.Value), Convert.ToDouble(numericUpDown2.Value), Convert.ToDouble(numericUpDown3.Value));
            bn.bulanık(bn.Hassaslık,bn.Miktar,bn.Kirlilik);
            label4.Text = bn.Hass;
            label5.Text = bn.Mikk;
            label6.Text = bn.Kirr;
            bn.datarenk(k.L, bn.Hbulanık, bn.Mbulanık, bn.Kbulanık);
            renklendir();

            //mamdani
            Mandani.Items.Clear();
            bn.mandanihesapla(bn.Mandani);
            foreach (var item in bn.Listem)
            {
                Mandani.Items.Add(item);
            }
            //durulama
            Durulaştır d = new Durulaştır();
            
            d.durula(bn.Listem, bn.Duruladhız, bn.Durulasüre, bn.Duruladet);

            textBox1.Text = d.Hesapla(d.Sonuclistdön).ToString();
            d.Dönüshızıcentroid(d.Xicinmax);
            textBox4.Text = d.centroidhesap(d.Gercek).ToString();

            textBox2.Text = d.Hesapla(d.Sonuclistsüre).ToString();
            d.Sürecentroid(d.Xicinmax);
            textBox6.Text = d.centroidhesap(d.Gercek).ToString();

            textBox3.Text = d.Hesapla(d.Sonuclistdet).ToString();
            d.Deterjancentroid(d.Xicinmax);
            textBox5.Text = d.centroidhesap(d.Gercek).ToString();

        }
        
       
       

        private void renk1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Red;
            btn.ForeColor = Color.Red;
        }

        private void renk2(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Red;
            btn.ForeColor = Color.Red;
        }

       

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
