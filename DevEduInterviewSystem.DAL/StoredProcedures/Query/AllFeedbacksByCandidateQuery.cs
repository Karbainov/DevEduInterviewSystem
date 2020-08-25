using Dapper;
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
    public class AllFeedbacksByCandidateQuery
    {
        public List<AllFeedbackByCandidateDTO> AllFeedbacksByCandidate(int ID)
        {
            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            var procedure = "[AllFeedbacksByCandidate]";

            List<AllFeedbackByCandidateDTO> result = new List<AllFeedbackByCandidateDTO>();

            AllFeedbackByCandidateDTO allFeedbackByCandidateDTO = new AllFeedbackByCandidateDTO();
            result = connection.Query<AllFeedbackByCandidateDTO>(procedure, new { CandidateID = ID }, commandType: CommandType.StoredProcedure).ToList();
            return result;

        }
    }
}