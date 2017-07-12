using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bantuan.entity.dao {
    public class DAOAset : DAO<Aset>{
        private MySqlConnection c;

        public DAOAset(MySqlConnection co) {
            c = co;
        }

        public List<Aset> all() {
            List<Aset> l = new List<Aset>();
            MySqlCommand co = new MySqlCommand("select*from aset where deleted order by kode", c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult())
            {
                Aset a = new Aset();
                a.Deleted = r.GetBoolean("deleted");
                a.Jumlah = new Uang(r.GetInt64("jumlah"));
                a.Kode = r.GetString("kode");
                a.Nama = r.GetString("nama");
                a.Tipe = r.GetString("tipe");
                l.Add(a);
            }
            r.Close();
            return l;
        }

        public void createTable() {
            Work.jalankan(c, "create table aset(kode varchar(20)primary key," +
                "nama varchar(40)not null,tipe varchar(20)not null," +
                "jumlah bigint not null,deleted boolean not null)");
        }

        public void delete(Aset w)
        {
            Aset b = new Aset(w.Kode, c);
            b.Deleted = true;
            update(w, b);
        }

        public void insert(Aset v)
        {
            String sql = "insert into aset values(@kode,@nama1,@tipe1,@jumlah1,@deleted1)";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", v.Kode));
            fillChanger(ref co, v, 1);
            co.ExecuteNonQuery();
        }

        public List<Aset> sampah() {
            List<Aset> l = new List<Aset>();
            MySqlCommand co = new MySqlCommand("select*from aset where deleted order by kode", c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult())
            {
                Aset a = new Aset();
                a.Deleted = r.GetBoolean("deleted");
                a.Jumlah = new Uang(r.GetInt64("jumlah"));
                a.Kode = r.GetString("kode");
                a.Nama = r.GetString("nama");
                a.Tipe = r.GetString("tipe");
                l.Add(a);
            }
            r.Close();
            return l;
        }

        public void trueDelete(Aset w)
        {
            String sql = "delete from aset where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", w.Kode));
            co.ExecuteNonQuery();
        }

        public void update(Aset a, Aset b)
        {
            String sql = "update aset set nama=@nama2,tipe=@tipe2,jumlah=@jumlah2," +
                "deleted=@deleted2 where kode=@kode1";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChanger(ref co, b, 2);
            co.Parameters.Add(new MySqlParameter("kode1", a.Kode));
            co.ExecuteNonQuery();
        }

        private void fillChanger(ref MySqlCommand co, Aset b, int v)
        {
            co.Parameters.Add(new MySqlParameter("nama" + v, b.Nama));
            co.Parameters.Add(new MySqlParameter("tipe" + v, b.Tipe));
            co.Parameters.Add(new MySqlParameter("jumlah" + v, b.Jumlah.V));
            co.Parameters.Add(new MySqlParameter("deleted" + v, b.Deleted));
        }
    }
}