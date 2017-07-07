using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MySql.Data.MySqlClient;

namespace bantuan {
    public class Work {
        public static FileInfo f = new FileInfo(Environment.
            GetFolderPath(Environment.SpecialFolder.Personal) + "/.fulus/konfig");

        public static MySqlConnection getConection() {
            return null;
        }

        public static void hindar(Exception ex) {
            DateTime t = new DateTime();
            FileInfo b = new FileInfo(f.DirectoryName + "/error/" +
                t.Date + "-" + t.Month + "-" + t.Year + "/" + t.Hour + "-" + t.Minute + "-" + t.Second + ".log");
            XmlDocument d = new XmlDocument();
            XmlElement e = d.CreateElement("Error");
            d.AppendChild(e);
            e.AppendChild(genXMLString(d, ex.Message, "pesan"));
            e.AppendChild(genXMLString(d, ex.Source, "sumber"));
            e.AppendChild(genXMLString(d, ex.StackTrace, "stack"));
            tulisXML(d, b);
        }

        private static XmlNode genXMLString(XmlDocument d, string s, string nama) {
            XmlElement e = d.CreateElement(nama);
            e.InnerText = s;
            return e;
        }

        private static void tulisXML(XmlDocument d, FileInfo b) {
            if (!b.Directory.Exists) createDir(b.Directory);
            XmlWriterSettings s = new XmlWriterSettings();
            s.WriteEndDocumentOnClose = true;
            s.OmitXmlDeclaration = false;
            s.NewLineOnAttributes = true;
            s.IndentChars = "  ";
            s.Indent = true;
            s.Encoding = Encoding.UTF8;
            s.CloseOutput = true;
            XmlWriter w;
            if (b.Exists) w = XmlWriter.Create(b.OpenWrite(), s);
            else w = XmlWriter.Create(b.Create(), s);
            d.WriteTo(w);
            w.Close();
        }

        public static void createDir(DirectoryInfo d) {
            if (!d.Parent.Exists) createDir(d.Parent);
            d.Create();
        }

        public static void createDB(string host, string nama, decimal port, string user, string pass) {
            DBConfig c = new DBConfig();
            c.Host = host;
            c.Nama = "mysql";
            c.Pass = pass;
            c.Port = Int32.Parse("" + port);
            c.User = user;
            MySqlConnection con = c.genConection();
            jalankan(con, "create database " + nama);
            c.Nama = nama;
            con.Close();
            con = c.genConection();
            nextDB(ref con);
        }

        private static void nextDB(ref MySqlConnection c) {
            c.Close();
        }

        public static void jalankan(MySqlConnection c, string s) {
            MySqlCommand co = new MySqlCommand("s", c);
            co.ExecuteNonQuery();
        }

        public static void simpan(DBConfig c) {
            Enkripsi enc = loadEnk();
            XmlDocument d = new XmlDocument();
            XmlElement e = d.CreateElement("dbconfig");
            d.AppendChild(e);
            e.AppendChild(genXMLString(d, enc.encrypt(c.Host), "server"));
            e.AppendChild(genXMLString(d, enc.encrypt(c.Nama), "Database"));
            e.AppendChild(genXMLString(d, enc.encrypt(c.Pass), "password"));
            e.AppendChild(genXMLString(d, enc.encrypt(c.User), "uid"));
            e.AppendChild(genXMLString(d, enc.encrypt("" + c.Port), "port"));
            tulisXML(d, f);
        }

        private static Enkripsi loadEnk() {
            return new Enkripsi(f.DirectoryName + "/pri", f.DirectoryName + "/pub");
        }
    }
}
