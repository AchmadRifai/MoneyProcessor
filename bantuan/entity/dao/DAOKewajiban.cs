using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity.dao
{
    public class DAOKewajiban : DAO<Kewajiban>
    {
        private MySqlConnection c;

        public DAOKewajiban(MySqlConnection co)
        {
            c = co;
        }

        public List<Kewajiban> all()
        {
            List<Kewajiban> l = new List<Kewajiban>();
            String sql = "select*from kewajiban where not deleted and not lunas order by tempo";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult()) {
                Kewajiban k = new Kewajiban();
                fillData(ref k, r);
                l.Add(k);
            } r.Close();
            return l;
        }

        private void fillData(ref Kewajiban k, MySqlDataReader r)
        {
            k.Kode = r.GetString("kode");
            k.Struk = r.GetString("struk");
            k.Nama = r.GetString("nama");
            k.Kepada = r.GetString("kepada");
            k.Bunga = r.GetFloat("bunga");
            k.Mulai = r.GetDateTime("mulai");
            k.Tempo = r.GetDateTime("tempo");
            k.Jumlah = new Uang(r.GetInt64("jumlah"));
            k.Lunas = r.GetBoolean("lunas");
            k.Deleted = r.GetBoolean("deleted");
        }

        public void createTable()
        {
            Work.jalankan(c, "create table kewajiban(kode varchar(40)primary key,struk text not null," +
                "nama varchar(30)not null,kepada varchar(20)not null,bunga float not null," +
                "mulai timestamp not null,tempo timestamp,jumlah bigint not null," +
                "lunas boolean not null,deleted boolean not null)");
        }

        public void delete(Kewajiban w)
        {
            Kewajiban b = new Kewajiban(w.Kode, c);
            b.Deleted = true;
            update(w, b);
        }

        public void insert(Kewajiban v)
        {
            String sql = "insert into kewajiban values(@kode,@struk1,@nama1,@kepada1,@bunga1,@mulai1" +
                ",@tempo1,@jumlah1,@lunas1,@deleted1)";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", v.Kode));
            fillChange(ref co, v, 1);
            co.ExecuteNonQuery();
        }

        private void fillChange(ref MySqlCommand co, Kewajiban k, int v)
        {
            co.Parameters.Add(new MySqlParameter("struk" + v, k.Struk));
            co.Parameters.Add(new MySqlParameter("nama" + v, k.Nama));
            co.Parameters.Add(new MySqlParameter("kepada" + v, k.Kepada));
            co.Parameters.Add(new MySqlParameter("bunga" + v, k.Bunga));
            co.Parameters.Add(new MySqlParameter("mulai" + v, k.Mulai));
            co.Parameters.Add(new MySqlParameter("tempo" + v, k.Tempo));
            co.Parameters.Add(new MySqlParameter("jumlah" + v, k.Jumlah.V));
            co.Parameters.Add(new MySqlParameter("lunas" + v, k.Lunas));
            co.Parameters.Add(new MySqlParameter("deleted" + v, k.Deleted));
        }

        public List<Kewajiban> sampah()
        {
            List<Kewajiban> l = new List<Kewajiban>();
            String sql = "select*from kewajiban where deleted and not lunas order by tempo";
            MySqlCommand co = new MySqlCommand(sql, c);
            MySqlDataReader r = co.ExecuteReader();
            while (r.NextResult())
            {
                Kewajiban k = new Kewajiban();
                fillData(ref k, r);
                l.Add(k);
            }
            r.Close();
            return l;
        }

        public void trueDelete(Kewajiban w)
        {
            String sql = "delete from kewajiban where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            co.Parameters.Add(new MySqlParameter("kode", w.Kode));
            co.ExecuteNonQuery();
        }

        public void update(Kewajiban a, Kewajiban b)
        {
            String sql = "update kewajiban set struk=@struk2,nama=@nama2,kepada=@kepada2," +
                "bunga=@bunga2,mulai=@mulai2,tempo=@tempo2,jumlah=@jumlah2,lunas=@lunas2," +
                "deleted=@deleted2 where kode=@kode";
            MySqlCommand co = new MySqlCommand(sql, c);
            fillChange(ref co, b, 2);
            co.Parameters.Add(new MySqlParameter("kode", a.Kode));
            co.ExecuteNonQuery();
        }
    }
}
