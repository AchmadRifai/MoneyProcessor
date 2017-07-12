using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity.dao {
    public class DAOCicilanOrang : DAO<CicilanOrang> {
        private MySqlConnection c;

        public DAOCicilanOrang(MySqlConnection co) {
            c = co;
        }

        public List<CicilanOrang> all() {
            String sql = "select*from cicilanOrang where not deleted order by tgl desc";
            List<CicilanOrang> l = new List<CicilanOrang>();
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                CicilanOrang ci = new CicilanOrang();
                fillData(ref ci, r);
                l.Add(ci);
            } r.Close();
            return l;
        }

        private void fillData(ref CicilanOrang ci, MySqlDataReader r) {
            ci.Kode = r.GetString("kode");
            ci.Piutang = r.GetString("piutang");
            ci.Lapor = r.GetString("lapor");
            ci.Ket = r.GetString("ket");
            ci.Jumlah = new Uang(r.GetInt64("jumlah"));
            ci.Tgl = r.GetDateTime("tgl");
            ci.Deleted = r.GetBoolean("deleted");
        }

        public void createTable() {
            Work.jalankan(c, "create table cicilanOrang(kode varchar(40)primary key,piutang varchar(30)not null," +
                "ket text not null,lapor varchar(34)not null,jumlah bigint not null,tgl timestamp not null," +
                "deleted boolean not null)");
            Work.jalankan(c, "alter table cicilanOrang add foreign key(piutang)references piutang(kode)on update " +
                "cascade on delete cascade");
            Work.jalankan(c, "alter table cicilanOrang add foreign key(lapor)references pemasukan(kode)on update " +
                "cascade on delete cascade");
        }

        public void delete(CicilanOrang w) {
            CicilanOrang b = new CicilanOrang(w.Kode, c);
            b.Deleted = true;
            update(w, b);
        }

        public void insert(CicilanOrang v) {
            String sql = "insert into cicilanOrang values(@kode,@piutang1,@ket1,@lapor1,@jumlah1,@tgl1,@deleted1)";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", v.Kode));
            fillChange(ref co, v, 1);
        }

        private void fillChange(ref MySqlCommand co, CicilanOrang v, int x) {
            co.Parameters.Add(new MySqlParameter("piutang" + x, v.Piutang));
            co.Parameters.Add(new MySqlParameter("ket" + x, v.Ket));
            co.Parameters.Add(new MySqlParameter("lapor" + x, v.Lapor));
            co.Parameters.Add(new MySqlParameter("jumlah" + x, v.Jumlah.V));
            co.Parameters.Add(new MySqlParameter("tgl" + x, v.Tgl));
            co.Parameters.Add(new MySqlParameter("deleted" + x, v.Deleted));
        }

        public List<CicilanOrang> sampah() {
            String sql = "select*from cicilanOrang where deleted order by tgl desc";
            List<CicilanOrang> l = new List<CicilanOrang>();
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                CicilanOrang ci = new CicilanOrang();
                fillData(ref ci, r);
                l.Add(ci);
            } r.Close();
            return l;
        }

        public void trueDelete(CicilanOrang w) {
            String sql = "delete from cicilanOrang where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", w.Kode));
            co.ExecuteNonQuery();
        }

        public void update(CicilanOrang a, CicilanOrang b) {
            String sql = "update cicilanOrang set piutang=@piutang1,ket=@ket1,lapor=@lapor1,jumlah=@jumlah1,tgl=@tgl1," +
                "deleted=@deleted11 where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChange(ref co, b, 1);
            co.Parameters.Add(new MySqlParameter("kode", a.Kode));
            co.ExecuteNonQuery();
        }
    }
}