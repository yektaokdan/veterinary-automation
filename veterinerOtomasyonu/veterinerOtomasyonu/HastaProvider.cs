using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace veterinerOtomasyonu
{
    class HastaProvider
    {
        OleDbConnection con;
        OleDbCommand cmd;

        public HastaProvider()
        {
            Baglan();
        }
        public void Baglan()
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= veterinervt1.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = con;
        }
        public List<Hasta> Listele()
        {
            try
            {
                List<Hasta> hastaListesi = new List<Hasta>();
                cmd.CommandText = "Select *From Hastalar";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Hasta h = new Hasta();
                    h.Id = Convert.ToInt32(reader[0].ToString());
                    h.Numara = Convert.ToInt32(reader[1].ToString());
                    h.hAd = reader[2].ToString();
                    h.SahipAdi = reader[3].ToString();
                    h.SahipSoyadi = reader[4].ToString();
                    hastaListesi.Add(h);
                }

                return hastaListesi;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void hastaEkle(Hasta h)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Hastalar (hid,hnumber,hname,hsname,hssurname) Values (" + h.Id + ",'" + h.Numara + "','" + h.hAd + "','" + h.SahipAdi + "'," + h.SahipSoyadi + "')";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void Guncelle(Hasta eskiHasta, Hasta yeniHasta)
        {
            try
            {
                cmd.CommandText = "Update Hastalar SET hname='" + yeniHasta.hAd + "',hnumber='" + yeniHasta.Numara + "',hsname='" + yeniHasta.SahipAdi + "',hssurname='" + yeniHasta.SahipSoyadi + "' Where hid=" + eskiHasta.Id + "";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void Sil(Hasta h)
        {
            try
            {
                cmd.CommandText = "Delete From Hastalar Where hid= " + h.Id + "";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}
