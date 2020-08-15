using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.BLL
{
    abstract public class ARoleLogic
    {
        public SqlConnection Connection { get; set; }
        public ARoleLogic()
        {
            Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
        }
        protected SqlCommand ReferenceToProcedure(string sqlExpression)
        {

            SqlCommand command = new SqlCommand(sqlExpression, Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
