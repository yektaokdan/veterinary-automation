using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veterinerOtomasyonu
{
    class Hasta
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        int _number;
        public int Numara
        {
            get { return _number; }
            set { _number = value; }
        }

        string _hadi;
        public string hAd
        {
            get { return _hadi; }
            set { _hadi = value; }
        }


        string _sahipadi;
        public string SahipAdi
        {
            get { return _sahipadi; }
            set { _sahipadi = value; }
        }


        string _sahipsoyadi;
        public string SahipSoyadi
        {
            get { return _sahipsoyadi; }
            set { _sahipsoyadi = value; }
        }
    }
}
