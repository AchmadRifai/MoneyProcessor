using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity {
    public class Pengeluaran {
        private String kode, asetTujuan, asetAsal, ket;
        private Uang jumlah;
        private DateTime tgl;
        private bool deleted;

        public String Kode { get { return kode; } set { kode = value; } }
        public String AsetTujuan { get { return asetTujuan; } set { asetTujuan = value; } }
        public String AsetAsal { get { return asetAsal; } set { asetAsal = value; } }
        public String Ket { get { return ket; } set { ket = value; } }
        public Uang Jumlah { get { return jumlah; } set { jumlah = value; } }
        public DateTime Tgl { get { return tgl; } set { tgl = value; } }
        public bool Deleted { get { return deleted; } set { deleted = value; } }

        public Pengeluaran() { }

        public Pengeluaran(String k, MySqlConnection c) {
            String sql = "select*from pengeluaran where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", k));
            MySqlDataReader r = co.ExecuteReader();
            if (r.NextResult()) fillData(r);
            r.Close();
        }

        private void fillData(MySqlDataReader r) {
            kode = r.GetString("kode");
            asetTujuan = r.GetString("asetTujuan");
            asetAsal = r.GetString("asetAsal");
            ket = r.GetString("ket");
            jumlah = new Uang(r.GetInt64("jumlah"));
            tgl = r.GetDateTime("tgl");
            deleted = r.GetBoolean("deleted");
        }
    }
}