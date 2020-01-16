using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KinectCoordinateMapping.DOAs
{
    interface DOA
    {
        MySqlDataReader ExecuteQuery(String sqlStat);
        String CreateSQLQuery(int exerciseID);        
    }
}
