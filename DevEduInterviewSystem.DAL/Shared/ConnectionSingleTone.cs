using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.Shared
{
    public class ConnectionSingleTone
    {

        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }               

        private ConnectionSingleTone() { }

        private static ConnectionSingleTone _instance;

        private string _connectionString = SQLConnectionPaths.MainConnectionString;        

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
