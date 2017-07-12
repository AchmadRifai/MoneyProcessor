using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bantuan.entity
{
    public class Piutang
    {
        private String kode, dari;
        private Uang jumlah;
        private float bunga;
        private DateTime mulai, tempo;
        private bool deleted, lunas;

        public String Kode { get { return kode; } set { kode = value; } }
        public String Dari { get { return dari; } set { dari = value; } }
        public Uang Jumlah { get { return jumlah; } set { jumlah = value; } }
        public float Bunga { get { return bunga; } set { bunga = value; } }
        public DateTime Mulai { get { return mulai; } set { mulai = value; } }
        public DateTime Tempo { get { return tempo; } set { tempo = value; } }
        public bool Deleted { get { return deleted; } set { deleted = value; } }
        public bool Lunas { get { return lunas; } set { lunas = value; } }

        public Piutang() { }

        public Piutang(String k, MySqlConnection c)
        {
            String sql = "select*from piutang where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", k));
            fillData(co.ExecuteReader());
        }

        private void fillData(MySqlDataReader r)
        {
            if (r.NextResult()) {
                kode = r.GetString("kode");
                dari = r.GetString("dari");
                jumlah = new Uang(r.GetInt64("jumlah"));
                bunga = r.GetFloat("bunga");
                mulai = r.GetDateTime("mulai");
                tempo = r.GetDateTime("tempo");
                deleted = r.GetBoolean("deleted");
                lunas = r.GetBoolean("lunas");
            } r.Close();
        }
    }
}