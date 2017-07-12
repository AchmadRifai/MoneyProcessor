using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity.dao {
    public class DAOPemasukan : DAO<Pemasukan> {
        private MySqlConnection c;

        public DAOPemasukan(MySqlConnection co) {
            c = co;
        }

        public List<Pemasukan> all() {
            List<Pemasukan> l = new List<Pemasukan>();
            String sql = "select*from pemasukan where not deleted order by tgl desc";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                Pemasukan p = new Pemasukan();
                fillData(ref p, r);
                l.Add(p);
            } r.Close();
            return l;
        }

        private void fillData(ref Pemasukan p, MySqlDataReader r) {
            p.Deleted = r.GetBoolean("deleted");
            p.Jumlah = new Uang(r.GetInt64("jumlah"));
            p.Tgl = r.GetDateTime("tgl");
            p.Kode = r.GetString("kode");
            p.Ket = r.GetString("ket");
        }

        public void createTable() {
            Work.jalankan(c, "create table pemasukan(kode varchar(34)primary key,ket text not null," +
                "tgl timestamp not null,jumlah bigint not null,deleted boolean not null)");
        }

        public void delete(Pemasukan w) {
            Pemasukan b = new Pemasukan(w.Kode, c);
            b.Deleted = true;
            update(w, b);
        }

        public void insert(Pemasukan v) {
            String sql = "insert into pemasukan values(@kode,@ket1,@tgl1,@jumlah1,@deleted1)";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", v.Kode));
            fillChange(ref co, v, 1);
            co.ExecuteNonQuery();
        }

        private void fillChange(ref MySqlCommand co, Pemasukan p, int x) {
            co.Parameters.Add(new MySqlParameter("ket" + x, p.Ket));
            co.Parameters.Add(new MySqlParameter("tgl" + 1, p.Tgl));
            co.Parameters.Add(new MySqlParameter("jumlah" + x, p.Jumlah.V));
            co.Parameters.Add(new MySqlParameter("deleted" + x, p.Deleted));
        }

        public List<Pemasukan> sampah() {
            List<Pemasukan> l = new List<Pemasukan>();
            String sql = "select*from pemasukan where deleted order by tgl desc";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                Pemasukan p = new Pemasukan();
                fillData(ref p, r);
                l.Add(p);
            } r.Close();
            return l;
        }

        public void trueDelete(Pemasukan w) {
            String sql = "delete from pemasukan where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", w.Kode));
            co.ExecuteNonQuery();
        }

        public void update(Pemasukan a, Pemasukan b) {
            String sql = "update pemasukan set ket=@ket1,tgl=@tgl1,jumlah=@jumlah1," +
                "deleted=@deleted1 where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChange(ref co, b, 1);
            co.Parameters.Add(new MySqlParameter("kode", a.Kode));
            co.ExecuteNonQuery();
        }
    }
}