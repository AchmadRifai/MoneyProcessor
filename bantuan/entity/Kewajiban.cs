using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bantuan.entity
{
    public class Kewajiban
    {
        private String nama, kepada, kode, struk;
        private DateTime mulai, tempo;
        private Uang jumlah;
        private float bunga;
        private bool deleted, lunas;

        public String Kode { get { return kode; } set { kode = value; } }
        public String Struk { get { return struk; } set { struk = value; } }
        public String Nama { get { return nama; } set { nama = value; } }
        public String Kepada { get { return kepada; } set { kepada = value; } }
        public DateTime Mulai { get { return mulai; } set { mulai = value; } }
        public DateTime Tempo { get { return tempo; } set { tempo = value; } }
        public Uang Jumlah { get { return jumlah; } set { jumlah = value; } }
        public float Bunga { get { return bunga; } set { bunga = value; } }
        public bool Deleted { get { return deleted; } set { deleted = value; } }
        public bool Lunas { get { return lunas; } set { lunas = value; } }

        public Kewajiban() { }

        public Kewajiban(String k,MySql.Data.MySqlClient.MySqlConnection c)
        {
            String sql = "select*from kewajiban where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", k));
            MySqlDataReader r = co.ExecuteReader();
            fillWith(r);
            r.Close();
        }

        private void fillWith(MySqlDataReader r)
        {
            if (r.NextResult())
            {
                nama = r.GetString("nama");
                kepada = r.GetString("kepada");
                kode = r.GetString("kode");
                struk = r.GetString("struk");
                mulai = r.GetDateTime("mulai");
                tempo = r.GetDateTime("tempo");
                jumlah = new Uang(r.GetInt64("jumlah"));
                bunga = r.GetFloat("bunga");
                lunas = r.GetBoolean("lunas");
                deleted = r.GetBoolean("deleted");
            }
        }
    }
}