using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veterinerOtomasyonu
{
    class Hizmet
    {
        int _sid;
        public int Id
        {
            get { return _sid; }
            set { _sid = value; }
        }


        int _sno;
        public int Numara
        {
            get { return _sno; }
            set { _sno = value; }
        }


        string _sname;
        public string Adi
        {
            get { return _sname; }
            set { _sname = value; }
        }
    }
}
