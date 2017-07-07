using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity.dao {
    public class DAOAset : DAO<Aset>{
        private MySql.Data.MySqlClient.MySqlConnection c;

        public DAOAset(MySql.Data.MySqlClient.MySqlConnection co) {
            c = co;
        }

        public List<Aset> all() {
            List<Aset> l = new List<Aset>();
            MySql.Data.MySqlClient.MySqlCommand co = new MySql.Data.MySqlClient.
                MySqlCommand("select*from aset where deleted order by kode", c);
            MySql.Data.MySqlClient.MySqlDataReader r = co.ExecuteReader();
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
            throw new NotImplementedException();
        }

        public List<Aset> sampah() {
            List<Aset> l = new List<Aset>();
            MySql.Data.MySqlClient.MySqlCommand co = new MySql.Data.MySqlClient.
                MySqlCommand("select*from aset where not deleted order by kode", c);
            MySql.Data.MySqlClient.MySqlDataReader r = co.ExecuteReader();
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
            throw new NotImplementedException();
        }

        public void update(Aset a, Aset b)
        {
            throw new NotImplementedException();
        }
    }
}