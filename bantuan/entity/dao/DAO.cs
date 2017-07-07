using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bantuan.entity.dao {
    public interface DAO<T> {
        void insert(T v);
        void delete(T w);
        void trueDelete(T w);
        void createTable();
        void update(T a, T b);
        List<T> all();
        List<T> sampah();
    }
}