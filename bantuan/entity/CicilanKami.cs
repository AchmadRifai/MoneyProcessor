using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity {
    public class CicilanKami {
        private String hutang, struk, ket, lapor;
        private DateTime tgl;
        private Uang jumlah;
        private bool deleted;

        public CicilanKami() { }

        public String Hutang { get { return hutang; } set { hutang = value; } }
        public String Struk { get { return struk; } set { struk = value; } }
        public String Ket { get { return ket; } set { ket = value; } }
        public DateTime Tgl { get { return tgl; } set { tgl = value; } }
        public Uang Jumlah { get { return jumlah; } set { jumlah = value; } }
        public bool Deleted { get { return deleted; } set { deleted = value; } }
        public String Lapor { get { return lapor; } set { lapor = value; } }
    }
}