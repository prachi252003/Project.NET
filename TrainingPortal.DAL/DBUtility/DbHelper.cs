using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TrainingPortal.DAL.DBUtility
{
    public class DbHelper
    {
        private readonly string connectionString = @"server=(localdb)\MSSQLLocalDB; database=SynechronTrainingDB; integrated security=true";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
