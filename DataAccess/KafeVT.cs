using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KafeOtomasyon.DataAccess
{
    public class KafeVT
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-JKNOO9P\SQLEXPRESS;Initial Catalog=KafeOtomosyon;Integrated Security=True;");

        public SqlConnection BaglantiAl() {
            if (baglanti.State==System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }
            return baglanti;
        }
    }
}
