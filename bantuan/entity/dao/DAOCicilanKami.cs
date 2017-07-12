using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity.dao {
    public class DAOCicilanKami : DAO<CicilanKami> {
        private MySqlConnection c;

        public DAOCicilanKami(MySqlConnection co) {
            c = co;
        }

        public List<CicilanKami> all() {
            List<CicilanKami> l = new List<CicilanKami>();
            String sql = "select*from cicilanKami where not deleted order by tgl desc";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                CicilanKami c = new CicilanKami();
                fillData(ref c, r);
                l.Add(c);
            } r.Close();
            return l;
        }

        private void fillData(ref CicilanKami c, MySqlDataReader r) {
            c.Hutang = r.GetString("hutang");
            c.Struk = r.GetString("struk");
            c.Ket = r.GetString("ket");
            c.Tgl = r.GetDateTime("tgl");
            c.Jumlah = new Uang(r.GetInt64("jumlah"));
            c.Deleted = r.GetBoolean("deleted");
            c.Lapor = r.GetString("lapor");
        }

        public void createTable() {
            Work.jalankan(c, "create table cicilanKami(hutang varchar(40)not null,struk text,ket text not null," +
                "tgl timestamp not null,jumlah bigint not null,deleted boolean not null,lapor varchar(40)not null)");
            Work.jalankan(c, "alter table cicilanKami add foreign key(hutang)references kewajiban(kode)on update cascade " +
                "on delete cascade");
            Work.jalankan(c, "alter table cicilanKami add foreign key(lapor)references pengeluaran(kode)on update cascade " +
                "on delete cascade");
        }

        public void delete(CicilanKami w) {
            String sql = "update cicilanKami set deleted=@deleted where hutang=@hutang1 and struk=@struk1 and ket=@ket1 and tgl=@tgl1 " +
                "jumlah=@jumlah1 and deleted=@deleted1 and lapor=@lapor1";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("deleted", true));
            fillChange(ref co, w, 1);
            co.ExecuteNonQuery();
        }

        private void fillChange(ref MySqlCommand co, CicilanKami v, int x) {
            co.Parameters.Add(new MySqlParameter("hutang" + x, v.Hutang));
            co.Parameters.Add(new MySqlParameter("struk" + x, v.Struk));
            co.Parameters.Add(new MySqlParameter("ket" + x, v.Ket));
            co.Parameters.Add(new MySqlParameter("tgl" + x, v.Tgl));
            co.Parameters.Add(new MySqlParameter("jumlah" + x, v.Jumlah.V));
            co.Parameters.Add(new MySqlParameter("deleted" + x, v.Deleted));
            co.Parameters.Add(new MySqlParameter("lapor" + x, v.Lapor));
        }

        public void insert(CicilanKami v) {
            String sql = "insert into cicilanKami values(@hutang1,@struk1,@ket1,@tgl1,@jumlah1,@deleted1,@lapor1)";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChange(ref co, v, 1);
            co.ExecuteNonQuery();
        }

        public List<CicilanKami> sampah() {
            List<CicilanKami> l = new List<CicilanKami>();
            String sql = "select*from cicilanKami where deleted order by tgl desc";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                CicilanKami c = new CicilanKami();
                fillData(ref c, r);
                l.Add(c);
            } r.Close();
            return l;
        }

        public void trueDelete(CicilanKami w) {
            String sql = "delete from cicilanKami where hutang=@hutang1 and struk=@struk1 and ket=@ket1 and tgl=@tgl1 and jumlah=@jumlah1 and " +
                "deleted=@deleted1 and lapor=@lapor1";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChange(ref co, w, 1);
            co.ExecuteNonQuery();
        }

        public void update(CicilanKami a, CicilanKami b) {
            String sql = "update cicilanKami set hutang=@hutang1,struk=@struk1,ket=@ket1,tgl=@tgl1," +
                "jumlah=@jumlah1,deleted=@deleted1,lapor=@lapor1 where hutang=@hutang2 and struk=@struk2 and ket=@ket2 " +
                "and tgl=@tgl2 jumlah=@jumlah2 and deleted=@deleted2 and lapor=@lapor2";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChange(ref co, a, 1);
            fillChange(ref co, b, 2);
            co.ExecuteNonQuery();
        }
    }
}