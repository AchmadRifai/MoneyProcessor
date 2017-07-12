using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity {
    public class CicilanOrang {
        private String kode, piutang, ket, lapor;
        private Uang jumlah;
        private DateTime tgl;
        private bool deleted;

        public String Kode { get { return kode; } set { kode = value; } }
        public String Piutang { get { return piutang; } set { piutang = value; } }
        public String Ket { get { return ket; } set { ket = value; } }
        public String Lapor { get { return lapor; } set { lapor = value; } }
        public Uang Jumlah { get { return jumlah; } set { jumlah = value; } }
        public DateTime Tgl { get { return tgl; } set { tgl = value; } }
        public bool Deleted { get { return deleted; } set { deleted = value; } }

        public CicilanOrang() { }

        public CicilanOrang(String k, MySqlConnection c) {
            String sql = "select*from cicilanOrang where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", k));
            MySqlDataReader r = co.ExecuteReader();
            if (r.NextResult()) fillData(r);
            r.Close();
        }

        private void fillData(MySqlDataReader r) {
            kode = r.GetString("kode");
            piutang = r.GetString("piutang");
            ket = r.GetString("ket");
            lapor = r.GetString("lapor");
            jumlah = new Uang(r.GetInt64("jumlah"));
            tgl = r.GetDateTime("tgl");
            deleted = r.GetBoolean("deleted");
        }
    }
}