using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace veterinerOtomasyonu
{
    class CalisanProvider
    {
        OleDbConnection con;
        OleDbCommand cmd;
        public CalisanProvider()
        {
            Baglan();
        }

        public void Baglan()
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= veterinervt1.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = con;
        }

        public List<Calisan> Listele()
        {
            try
            {
                List<Calisan> calisanListesi = new List<Calisan>();
                cmd.CommandText = "Select *From Calisanlar";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Calisan k = new Calisan();
                    k.No = Convert.ToInt32(reader[0].ToString());
                    k.Ad = reader[1].ToString();
                    k.Soyad = reader[2].ToString();
                    k.Telefonu = reader[3].ToString();
                    calisanListesi.Add(k);
                }

                return calisanListesi;
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

        public void Ekle(Calisan k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Calisanlar (cid,cname,csurname,cphone) Values (" + k.No + ",'" + k.Ad + "','" + k.Soyad + "','" + k.Telefonu + "')";
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

        public void Guncelle(Calisan eskiCalisan, Calisan yeniCalisan)
        {
            try
            {
                cmd.CommandText = "Update Calisanlar SET cname='" + yeniCalisan.Ad + "',csurname='" + yeniCalisan.Soyad + "',cphone='" + yeniCalisan.Telefonu + "' Where cid=" + eskiCalisan.No + "";
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

        public void Sil(Calisan k)
        {
            try
            {
                cmd.CommandText = "Delete From Calisanlar Where cid= " + k.No + "";
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
