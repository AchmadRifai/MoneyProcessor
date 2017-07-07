using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bantuan.entity {
    public class Aset {
        private String kode, nama, tipe;
        private Uang jumlah;
        private bool deleted;

        public Aset() { }

        public Aset(String k, MySqlConnection c) {
            String sql = "select*from aset where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", k));
            MySqlDataReader r = co.ExecuteReader();
            fillWith(r);
            r.Close();
        }

        private void fillWith(MySqlDataReader r) {
            if (r.NextResult()) {
                kode = r.GetString("kode");
                nama = r.GetString("nama");
                tipe = r.GetString("tipe");
                jumlah = new Uang(r.GetInt64("jumlah"));
                deleted = r.GetBoolean("deleted");
            }
        }

        public String Kode { get { return kode; } set { kode = value; } }
        public String Nama { get { return nama; } set { nama = value; } }
        public String Tipe { get { return tipe; } set { tipe = value; } }
        public Uang Jumlah { get { return jumlah; } set { jumlah = value; } }
        public bool Deleted { get { return deleted; } set { deleted = value; } }
    }
}