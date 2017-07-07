using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan {
    public class DBConfig {
        private String host, nama, user, pass;
        private int port;

        public String Host { get { return host; } set { host = value; } }
        public String Nama { get { return nama; } set { nama = value; } }
        public String User { get { return user; } set { user = value; } }
        public String Pass { get { return pass; } set { pass = value; } }
        public int Port { get { return port; } set { port = value; } }

        public MySql.Data.MySqlClient.MySqlConnection genConection() {
            String s = "server=" + host + ";database=" + nama + ";uid=" + user + ";port=" + port + ";password=" + pass;
            MySql.Data.MySqlClient.MySqlConnection c = new MySql.Data.MySqlClient.MySqlConnection(s);
            c.Open();
            return c;
        }
    }
}