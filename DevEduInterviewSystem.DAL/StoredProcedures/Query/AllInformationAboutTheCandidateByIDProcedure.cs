using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllInformationAboutTheCandidateByIDProcedure
    {
        SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

        public AllInformationAboutTheCandidateByIDDTO AllInformationAboutTheCandidateByID(int ID)
        {           
            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            var procedure = "[AllInformationAboutTheCandidateByID]";
        
            var allInfo = connection.Query<AllInformationAboutTheCandidateByIDDTO>(procedure,new {ID},
            commandType: CommandType.StoredProcedure
            ).SingleOrDefault();

            return allInfo;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
