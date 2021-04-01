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

namespace veterinerOtomasyonu
{
    public partial class Form2 : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter da;

        CalisanProvider kp = new CalisanProvider();
        HastaProvider hp = new HastaProvider();
        HizmetProvider h2p = new HizmetProvider();
        public Form2()
        {
            InitializeComponent();
        }
        //TabControl üzerinde birden fazla sekme var. Bunlardaki her bir datagrid nesnesi için ona özel yazmış olduğum classın methodunda istenen select sorgusu ile verileri listeliyorum.
        void Listele()
        {
            dataGridView1.DataSource = kp.Listele();//Calisanlarin listelendiği sınıf içerisindeki method.
        }
        void hastaListele()
        {
            dataGridView2.DataSource = hp.Listele();//Hastaların llistelendiği sınıf içerisindeki method.
        }
        void hizmetListele()
        {
            dataGridView3.DataSource = h2p.Listele();//Hizmetlerin listelendiği sınıf içerisindeki method.
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Listele();//Yukarıda tanımlanan methodları formun açılışına yerleştiriyorum. Böylece program çalışır çalışmaz her sekmede oraya özel olan veriler datagrid üzerinde gözüküyor.
            hastaListele();
            hizmetListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EKLE BUTONU.
            Calisan yenikisi = new Calisan();//Calisan sınıfından bir varlık üretiyorum.
            yenikisi.No = Convert.ToInt32(textBox1.Text);//Özelliklerini form üzerindeki textboxların text özelliği olarak tanımlıyorum.
            yenikisi.Ad = textBox2.Text;
            yenikisi.Soyad = textBox3.Text;
            yenikisi.Telefonu = textBox4.Text;
            kp.Ekle(yenikisi);//Provide isimli sınıf içerisindeki Ekle methodunu kullanarak girilen bilgileri veritabanında belirlenen tabloya ekliyorum.
            Listele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SİL BUTONU
            Calisan silinecekCalisan = new Calisan();//Calisan sınıfından yeni bir varlık üretiyorum.
            silinecekCalisan = (Calisan)dataGridView1.CurrentRow.DataBoundItem;//Secilen kisinin datagrid üzerindeki yeri belirlendi.
            kp.Sil(silinecekCalisan);//Provider içerisindeki Sil methodu ile veritabanı üzerinden seçilen kişiyi kaldırıyorum.
            Listele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GUNCELLE BUTONU
            Calisan eskikisi = new Calisan();//Calisan sınıfından bir varlık üretiyorum.
            eskikisi = (Calisan)dataGridView1.CurrentRow.DataBoundItem;//Secilen kisinin datagrid üzerindeki yeri belirlendi.
            Calisan yenikisi = new Calisan();//Calisan sınıfından bir varlık üretiyorum.
            yenikisi.Ad = textBox2.Text;//Özelliklerini form üzerindeki textboxların text özelliği olarak tanımlıyorum.
            yenikisi.Soyad = textBox3.Text;
            yenikisi.Telefonu = textBox4.Text;
            kp.Guncelle(eskikisi, yenikisi);//Proiver içerisindeki Guncelle methodunu cagirarak varolan verinin içerigini değiştiriyorum.
            Listele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Datagrid üzerindeki veriye tıklandığında o tıklanan satır ve sütunun value değerinin textboxlara yazılmasını sağlıyorum. Böylece okunurluk artıyor.
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hasta yenihasta = new Hasta();
            yenihasta.Id = Convert.ToInt32(txt_hid.Text);//Özelliklerini form üzerindeki textboxların text özelliği olarak tanımlıyorum.
            yenihasta.Numara = Convert.ToInt32(txt_hno.Text);
            yenihasta.hAd = txt_hadi.Text;
            yenihasta.SahipAdi = txt_hsadi.Text;
            yenihasta.SahipSoyadi = txt_hssoyadi.Text;
            hp.hastaEkle(yenihasta);//Provider isimli sınıf içerisindeki Ekle methodunu kullanarak girilen bilgileri veritabanında belirlenen tabloya ekliyorum.
            hastaListele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hasta silinecekHasta = new Hasta();//Hasta sınıfından bir varlık üretiyorum.
            silinecekHasta = (Hasta)dataGridView2.CurrentRow.DataBoundItem; //Secilen kisinin datagrid üzerindeki yeri belirlendi.
            hp.Sil(silinecekHasta);//Provider içerisindeki Sil methodu ile veritabanı üzerinden seçilen kişiyi kaldırıyorum.
            hastaListele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hasta eskihasta = new Hasta();//Hasta sınıfından bir varlık üretiyorum.
            eskihasta = (Hasta)dataGridView2.CurrentRow.DataBoundItem;//Secilen kisinin datagrid üzerindeki yeri belirlendi.
            Hasta yenihasta = new Hasta();//Hasta sınıfından bir varlık üretiyorum.
            yenihasta.Numara = Convert.ToInt32(txt_hno.Text);//Özelliklerini form üzerindeki textboxların text özelliği olarak tanımlıyorum.
            yenihasta.hAd = txt_hadi.Text;
            yenihasta.SahipAdi = txt_hsadi.Text;
            yenihasta.SahipSoyadi = txt_hssoyadi.Text;
            hp.Guncelle(eskihasta, yenihasta);//Proiver içerisindeki Guncelle methodunu cagirarak varolan verinin içerigini değiştiriyorum.
            hastaListele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Datagrid üzerindeki veriye tıklandığında o tıklanan satır ve sütunun value değerinin textboxlara yazılmasını sağlıyorum. Böylece okunurluk artıyor.
            txt_hid.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txt_hno.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_hadi.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_hsadi.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txt_hssoyadi.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hizmet yenihizmet = new Hizmet();//Hizmet sınıfından bir varlık üretiyorum.
            yenihizmet.Id = Convert.ToInt32(txt_sid.Text);//Özelliklerini form üzerindeki textboxların text özelliği olarak tanımlıyorum.
            yenihizmet.Numara = Convert.ToInt32(txt_sno.Text);
            yenihizmet.Adi = txt_sadi.Text;
            h2p.hizmetEkle(yenihizmet);//Provider isimli sınıf içerisindeki Ekle methodunu kullanarak girilen bilgileri veritabanında belirlenen tabloya ekliyorum.
            hizmetListele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hizmet silinecekHizmet = new Hizmet();//Hizmet sınıfından bir varlık üretiyorum.
            silinecekHizmet = (Hizmet)dataGridView3.CurrentRow.DataBoundItem;//Secilen kisinin datagrid üzerindeki yeri belirlendi.
            h2p.Sil(silinecekHizmet);//Provider içerisindeki Sil methodu ile veritabanı üzerinden seçilen kişiyi kaldırıyorum.
            hizmetListele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hizmet eskihizmet = new Hizmet();//Hizmet sınıfından bir varlık üretiyorum.
            eskihizmet = (Hizmet)dataGridView3.CurrentRow.DataBoundItem;//Secilen kisinin datagrid üzerindeki yeri belirlendi.
            Hizmet yenihizmet = new Hizmet();//Hizmet sınıfından bir varlık üretiyorum.
            yenihizmet.Numara = Convert.ToInt32(txt_sno.Text);//Özelliklerini form üzerindeki textboxların text özelliği olarak tanımlıyorum.
            yenihizmet.Adi = txt_sadi.Text;
            h2p.Guncelle(eskihizmet, yenihizmet);//Proiver içerisindeki Guncelle methodunu cagirarak varolan verinin içerigini değiştiriyorum.
            hizmetListele();//Tekrar listele methodunu çağırarak güncel verileri datagrid üzerine yazdırıyorum.
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Datagrid üzerindeki veriye tıklandığında o tıklanan satır ve sütunun value değerinin textboxlara yazılmasını sağlıyorum. Böylece okunurluk artıyor.
            txt_sid.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            txt_sno.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            txt_sadi.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();//Tab penceresindeki çıkış butonunun programı kapatmasını sağlıyorum.
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();//Tab penceresindeki çıkış butonunun programı kapatmasını sağlıyorum.
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();//Tab penceresindeki çıkış butonunun programı kapatmasını sağlıyorum.
        }

        public OleDbConnection openConnection()
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=veterinervt1.accdb");//Veritabanına bağlandığım komut.
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı");//Herhangi bir aksi durumda uyarı veriyor.
            }
            finally
            {
                //conn.close();
            }
            return conn;
        }
        public DataTable executeSelectQuery(string _query, OleDbParameter[] oledbparameter)
        {
            OleDbCommand myCmd = new OleDbCommand();//Datanın Command özelliğini kendi belirttiğim nyCmd ye atıyorum.
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();//Adaptör oluşturuyorum.
            DataTable dt = new DataTable();//Yeni bir data tablosu oluşturuyorum.
            dt = null;
            DataSet ds = new DataSet();
            try
            {
                myCmd.Connection = openConnection();//connyi aciyorum.
                myCmd.CommandText = _query;
                if (oledbparameter != null)
                {
                    myCmd.Parameters.AddRange(oledbparameter);
                }
                myCmd.ExecuteNonQuery();
                myAdapter.SelectCommand = myCmd;
                myAdapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Hata - Connection.executeSelectQuery -  Sorgu : " + _query + "\nİstisna: " + e.StackTrace.ToString());//Aksi bir durum olursa hatayı ekrana yazdırıyorum.
            }
            finally
            {
            }
            return dt;
        }
        void calisanlariListele()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=veterinervt1.accdb");
            conn.Open();//Bağlantı olarak belirlediğim connection açıldı.
            da = new OleDbDataAdapter("SELECT *FROM Calisanlar", conn); //Access teki öğrenci tablosunun tamamını çektiğim kısım.
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView4.DataSource = tablo;
            conn.Close();//Connection kapandı.
        }
        void hastalariListele()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=veterinervt1.accdb");
            conn.Open();//Bağlantı olarak belirlediğim connection açıldı.
            da = new OleDbDataAdapter("SELECT *FROM Hastalar", conn); //Access teki öğrenci tablosunun tamamını çektiğim kısım.
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView4.DataSource = tablo;
            conn.Close();//Connection kapandı.
        }
        void hizmetleriListele()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=veterinervt1.accdb");
            conn.Open();//Bağlantı olarak belirlediğim connection açıldı.
            da = new OleDbDataAdapter("SELECT *FROM Hizmetler", conn); //Access teki öğrenci tablosunun tamamını çektiğim kısım.
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView4.DataSource = tablo;
            conn.Close();//Connection kapandı.
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Verileri getirmek için kullanacağımız sorgu
            //INNER JOIN ile bağlandı ve LIKE %% ile getirildi.
            string query = @"SELECT Calisanlar.cid, Calisanlar.cname,Calisanlar.csurname, 
                                    Hastalar.hid, Hastalar.hname, Hastalar.hsname,Hizmetler.sno,Hizmetler.sname
                            FROM (((Calisanlar INNER JOIN HCH ON Calisanlar.cid = HCH.cid) INNER JOIN
                      Hastalar ON HCH.hid = Hastalar.hid) INNER JOIN Hizmetler ON HCH.sid = Hizmetler.sid)
                        WHERE Calisanlar.cid LIKE '%" + txtcid.Text + "%'" +
                         "AND Calisanlar.cname LIKE '%" + txtcadi.Text + "%'" +
                         "AND Calisanlar.csurname LIKE '%" + txtcsoyadi.Text + "%'" +
                         "AND Hastalar.hnumber LIKE '%" + txthid.Text + "%'" +
                         "AND Hastalar.hname LIKE '%" + txthadi.Text + "%'" +
                         "AND Hastalar.hsname LIKE '%" + txthsoyadi.Text + "%'" +
                         "AND Hizmetler.sid LIKE '%" + txthizmetid.Text + "%'" +
                         "AND Hizmetler.sname LIKE '%" + txthizmetadi.Text + "%'";

            txtSorguKlinik.Text = query;

            //Yazdığımız fonc ile verileri çekip tablomuza atıyoruz
            dataGridView4.DataSource = executeSelectQuery(query, null);

            //Olurda bağlantı açık kalmışsa kapatalım
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Ne olur ne olmaz bağlantı açık kalmışsa kapatalım
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            Application.Exit();//Uygulamadan çıkış yapıyorum.
        }

        private void button15_Click(object sender, EventArgs e)
        {
            calisanlariListele();//Belli tablodaki tüm veriyi listelemek için yazmış olduğum metodu çağırdığım yer.
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hastalariListele();//Belli tablodaki tüm veriyi listelemek için yazmış olduğum metodu çağırdığım yer.
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hizmetleriListele();//Belli tablodaki tüm veriyi listelemek için yazmış olduğum metodu çağırdığım yer.
        }
    }
}
