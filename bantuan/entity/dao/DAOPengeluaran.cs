using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity.dao {
    public class DAOPengeluaran : DAO<Pengeluaran> {
        private MySqlConnection c;

        public DAOPengeluaran(MySqlConnection co) {
            c = co;
        }

        public List<Pengeluaran> all() {
            List<Pengeluaran> l = new List<Pengeluaran>();
            String sql = "select*from pengeluaran where not deleted order by tgl desc";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                Pengeluaran p = new Pengeluaran();
                fillData(ref p, r);
                l.Add(p);
            } r.Close();
            return l;
        }

        private void fillData(ref Pengeluaran p, MySqlDataReader r) {
            p.AsetAsal = r.GetString("asetAsal");
            p.Ket = r.GetString("ket");
            p.Kode = r.GetString("kode");
            p.AsetTujuan = r.GetString("asetTujuan");
            p.Jumlah = new Uang(r.GetInt64("jumlah"));
            p.Tgl = r.GetDateTime("tgl");
            p.Deleted = r.GetBoolean("deleted");
        }

        public void createTable() {
            Work.jalankan(c, "create table pengeluaran(kode varchar(40)primary key," +
                "asetAsal varchar(20)not null,asetTujuan varchar(20)not null,ket text not null," +
                "jumlah bigint not null,tgl timestamp not null,deleted boolean not null)");
            Work.jalankan(c, "alter table pengeluaran add foreign key(asetAsal)references aset(kode)" +
                "on update cascade on delete cascade");
            Work.jalankan(c, "alter table pengeluaran add foreign key(asetTujuan)" +
                "references aset(kode)on update cascade on delete cascade");
        }

        public void delete(Pengeluaran w) {
            Pengeluaran b = new Pengeluaran(w.Kode, c);
            b.Deleted = true;
            update(w, b);
        }

        public void insert(Pengeluaran v) {
            String sql = "insert into pengeluaran values(@kode,@asetAsal1,@asetTujuan1,@ket1,@jumlah1," +
                "@tgl1,@deleted1)";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", v.Kode));
            fillChange(ref co, v, 1);
            co.ExecuteNonQuery();
        }

        private void fillChange(ref MySqlCommand co, Pengeluaran p, int x) {
            co.Parameters.Add(new MySqlParameter("asetAsal" + x, p.AsetAsal));
            co.Parameters.Add(new MySqlParameter("asetTujuan" + x, p.AsetTujuan));
            co.Parameters.Add(new MySqlParameter("ket" + x, p.Ket));
            co.Parameters.Add(new MySqlParameter("jumlah" + x, p.Jumlah.V));
            co.Parameters.Add(new MySqlParameter("tgl" + x, p.Tgl));
            co.Parameters.Add(new MySqlParameter("deleted" + x, p.Deleted));
        }

        public List<Pengeluaran> sampah() {
            List<Pengeluaran> l = new List<Pengeluaran>();
            String sql = "select*from pengeluaran where deleted order by tgl desc";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                Pengeluaran p = new Pengeluaran();
                fillData(ref p, r);
                l.Add(p);
            } r.Close();
            return l;
        }

        public void trueDelete(Pengeluaran w) {
            String sql = "delete from pengeluaran where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", w.Kode));
            co.ExecuteNonQuery();
        }

        public void update(Pengeluaran a, Pengeluaran b) {
            String sql = "update pengeluaran set asetAsal=@asetAsal1,asetTujuan=@asetTujuan1,ket=@ket1," +
                "jumlah=@jumlah1,tgl=@tgl1,deleted=@deleted1 where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChange(ref co, b, 1);
            co.Parameters.Add(new MySqlParameter("kode", a.Kode));
            co.ExecuteNonQuery();
        }
    }
}