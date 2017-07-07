using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace bantuan {
    public class Uang {
        private BigInteger v;

        public BigInteger V { get { return v; } }

        public Uang(long l) {
            v = new BigInteger(l);
        }

        public override string ToString() {
            String s;
            if (v != BigInteger.Zero) {
                String a = "Rp ", e = ",00";
                BigInteger b = normalKan(ref a);
                proses(ref e, ref b);
                s = a + e;
            } else s = "-";
            return s;
        }

        private void proses(ref string e, ref BigInteger b) {
            int x = 0;
            while (b > 0) {
                if (x == 3) {
                    e = "." + e;
                    x = 0;
                } BigInteger i = b % 10;
                b = b / 10;
                e = "" + i + e;
                x++;
            }
        }

        private BigInteger normalKan(ref string a) {
            if (v < 0) {
                a = "-" + a;
                return v * -1;
            } return v;
        }
    }
}