using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity {
    public class Pemasukan {
        private String kode, ket;
        private DateTime tgl;
        private Uang jumlah;
        private bool deleted;

        public String Kode { get { return kode; } set { kode = value; } }
        public String Ket { get { return ket; } set { ket = value; } }
        public DateTime Tgl { get { return tgl; } set { tgl = value; } }
        public Uang Jumlah { get { return jumlah; } set { jumlah = value; } }
        public bool Deleted { get { return deleted; } set { deleted = value; } }

        public Pemasukan() { }

        public Pemasukan(String k, MySqlConnection c) {
            String sql = "select*from pemasukan where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", k));
            MySqlDataReader r = co.ExecuteReader();
            if (r.NextResult()) fillData(r);
            r.Close();
        }

        private void fillData(MySqlDataReader r) {
            kode = r.GetString("kode");
            ket = r.GetString("ket");
            tgl = r.GetDateTime("tgl");
            jumlah = new Uang(r.GetInt64("jumlah"));
            deleted = r.GetBoolean("deleted");
        }
    }
}