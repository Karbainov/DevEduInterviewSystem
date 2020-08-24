using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllFeedbackByUserQuery
    {
        public List<AllFeedbackByUserDTO> AllFeedbackByUser(int ID)
        {
            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            var procedure = "[AllFeedbackByUser]";

            List<AllFeedbackByUserDTO> result = new List<AllFeedbackByUserDTO>();
         
            AllFeedbackByUserDTO allFeedbackByUserDTO = new AllFeedbackByUserDTO();
            result = connection.Query<AllFeedbackByUserDTO>(procedure, new { UserID = ID }, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}
