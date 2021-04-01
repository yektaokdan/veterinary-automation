using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace veterinerOtomasyonu
{
    class HizmetProvider
    {
        OleDbConnection con;
        OleDbCommand cmd;
        public HizmetProvider()
        {
            Baglan();
        }
        public void Baglan()
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= veterinervt1.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = con;
        }
        public List<Hizmet> Listele()
        {
            try
            {
                List<Hizmet> hizmetListesi = new List<Hizmet>();
                cmd.CommandText = "Select *From Hizmetler";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Hizmet h2 = new Hizmet();
                    h2.Id = Convert.ToInt32(reader[0].ToString());
                    h2.Numara = Convert.ToInt32(reader[1].ToString());
                    h2.Adi = reader[2].ToString();
                    hizmetListesi.Add(h2);
                }

                return hizmetListesi;
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

        public void hizmetEkle(Hizmet h2)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Hizmetler (sid,sno,sname) Values (" + h2.Id + ",'" + h2.Numara + "','" + h2.Adi + "')";
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

        public void Guncelle(Hizmet eskiHizmet, Hizmet yeniHizmet)
        {
            try
            {
                cmd.CommandText = "Update Hizmetler SET sname='" + yeniHizmet.Adi + "',sno='" + yeniHizmet.Numara + "'Where sid=" + eskiHizmet.Id + "";
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

        public void Sil(Hizmet h2)
        {
            try
            {
                cmd.CommandText = "Delete From Hizmetler Where sid= " + h2.Id + "";
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
