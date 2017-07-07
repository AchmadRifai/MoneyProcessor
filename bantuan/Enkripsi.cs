using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan {
    class Enkripsi {
        private System.IO.FileInfo pri, pub;

        public String encrypt(String v) {
            System.Security.Cryptography.RSACryptoServiceProvider r = new System.Security.
                Cryptography.RSACryptoServiceProvider();
            String k = loadPub();
            r.FromXmlString(k);
            byte[] b = r.Encrypt(Encoding.Default.GetBytes(v), false);
            return Convert.ToBase64String(b);
        }

        public String decrypt(String e) {
            System.Security.Cryptography.RSACryptoServiceProvider r = new System.Security.
                Cryptography.RSACryptoServiceProvider();
            String k = loadPri();
            r.FromXmlString(k);
            byte[] b = Convert.FromBase64String(e);
            byte[] d = r.Decrypt(b, false);
            return Encoding.Default.GetString(d);
        }

        private string loadPub() {
            System.IO.StreamReader r = new System.IO.StreamReader(pub.OpenRead());
            String s = r.ReadToEnd();
            r.Close();
            return s;
        }

        private string loadPri() {
            System.IO.StreamReader r = new System.IO.StreamReader(pri.OpenRead());
            String s = r.ReadToEnd();
            r.Close();
            return s;
        }

        public Enkripsi(String spri, String spub) {
            pri = new System.IO.FileInfo(spri);
            pub = new System.IO.FileInfo(spub);
            if (!pri.Exists || !pub.Exists) initBerkas();
        }

        private void initBerkas() {
            System.Security.Cryptography.RSACryptoServiceProvider r = new System.Security.
                Cryptography.RSACryptoServiceProvider(2048);
            simpanPri(r.ToXmlString(true));
            simpanPub(r.ToXmlString(false));
        }

        private void simpanPub(string v) {
            if (!pub.Directory.Exists) Work.createDir(pub.Directory);
            if (pub.Exists) pub.Delete();
            System.IO.StreamWriter w = new System.IO.StreamWriter(pub.Create());
            w.WriteLine(v);
            w.Close();
        }

        private void simpanPri(string s) {
            if (!pri.Directory.Exists) Work.createDir(pri.Directory);
            if (pri.Exists) pri.Delete();
            System.IO.StreamWriter w = new System.IO.StreamWriter(pri.Create());
            w.WriteLine(s);
            w.Close();
        }
    }
}