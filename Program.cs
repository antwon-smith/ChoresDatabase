using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ChoresDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var da = new DataAccess();
            da.Run();
        }
    }
}
