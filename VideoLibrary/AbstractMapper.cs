using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary
{
    abstract class AbstractMapper<T>
    {
        protected SqlConnection cn = new SqlConnection(global::VideoLibrary.Properties.Settings.Default.Database1ConnectionString);
        protected SqlConnection cn2 = new SqlConnection(global::VideoLibrary.Properties.Settings.Default.Database1ConnectionString);

        public abstract HashSet<T> GetData();
        public abstract void InsertOrUpdate(T data);
        public abstract void deleteData(T data);
    }
}
