using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.Shared
{
    public class ConnectionSingleTone
    {
        private ConnectionSingleTone() { }

        private static ConnectionSingleTone _instance;

        public const string ConnectionString = @"Data Source=.\HP;Initial Catalog=DevEduInterviewSystem.DataBase;Integrated Security=True; Data Source=(local)";

        public SqlConnection connection = new SqlConnection(ConnectionString);

        public static ConnectionSingleTone GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConnectionSingleTone();
            }
            return _instance;
        }

    }
}
