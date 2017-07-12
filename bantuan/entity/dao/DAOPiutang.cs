using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity.dao
{
    public class DAOPiutang : DAO<Piutang>
    {
        private MySqlConnection c;

        public DAOPiutang(MySqlConnection co) {
            c = co;
        }

        public List<Piutang> all() {
            List<Piutang> l = new List<Piutang>();
            String sql = "select*from piutang where not deleted and not lunas order by mulai desc";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                Piutang p = new Piutang();
                fillData(ref p, r);
                l.Add(p);
            } r.Close();
            return l;
        }

        private void fillData(ref Piutang p, MySqlDataReader r) {
            p.Bunga = r.GetFloat("bunga");
            p.Dari = r.GetString("dari");
            p.Deleted = r.GetBoolean("deleted");
            p.Jumlah = new Uang(r.GetInt64("jumlah"));
            p.Kode = r.GetString("kode");
            p.Lunas = r.GetBoolean("lunas");
            p.Mulai = r.GetDateTime("mulai");
            p.Tempo = r.GetDateTime("tempo");
        }

        public void createTable() {
            Work.jalankan(c, "create table piutang(kode varchar(30)primary key,dari text not null," +
                "jumlah bigint not null,bunga float not null,mulai timestamp not null,tempo timestamp," +
                "lunas boolean not null,deleted boolean not null)");
        }

        public void delete(Piutang w) {
            Piutang b = new Piutang(w.Kode, c);
            b.Deleted = true;
            update(w, b);
        }

        public void insert(Piutang v) {
            String sql = "insert into piutang values(@kode,@dari1,@jumlah1,@bunga1," +
                "@mulai1,@tempo1,@lunas1,@deleted1)";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", v.Kode));
            fillChange(ref co, v, 1);
            co.ExecuteNonQuery();
        }

        private void fillChange(ref MySqlCommand co, Piutang p, int x) {
            co.Parameters.Add(new MySqlParameter("dari" + x, p.Dari));
            co.Parameters.Add(new MySqlParameter("jumlah" + x, p.Jumlah.V));
            co.Parameters.Add(new MySqlParameter("bunga" + x, p.Bunga));
            co.Parameters.Add(new MySqlParameter("mulai" + x, p.Mulai));
            co.Parameters.Add(new MySqlParameter("tempo" + x, p.Tempo));
            co.Parameters.Add(new MySqlParameter("lunas" + x, p.Lunas));
            co.Parameters.Add(new MySqlParameter("deleted" + x, p.Deleted));
        }

        public List<Piutang> sampah() {
            List<Piutang> l = new List<Piutang>();
            String sql = "select*from piutang where deleted and lunas order by mulai desc";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                Piutang p = new Piutang();
                fillData(ref p, r);
                l.Add(p);
            } r.Close();
            return l;
        }

        public void trueDelete(Piutang w) {
            String sql = "delete from piutang where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", w.Kode));
            co.ExecuteNonQuery();
        }

        public void update(Piutang a, Piutang b) {
            String sql = "update piutang set dari=@dari1,jumlah=@jumlah1,bunga=@bunga1,mulai=@mulai1," +
                "tempo=@tempo1,lunas=@lunas1,deleted=@deleted1 where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChange(ref co, b, 1);
            co.Parameters.Add(new MySqlParameter("kode", a.Kode));
            co.ExecuteNonQuery();
        }
    }
}
