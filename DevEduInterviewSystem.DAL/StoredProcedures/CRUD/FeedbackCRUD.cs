using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class FeedbackCRUD : AbstractCRUD<FeedbackDTO>
    {      
        public override int Add(FeedbackDTO dto)
        {
            var procedure = "[AddFeedback]";
            var values = new
            {
                StageChangedID = dto.StageChangedID,
                UserID = dto.UserID,
                Message = dto.Message,
                TimeFeedback = dto.TimeFeedback        
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Feedback]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

   
        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteFeedbackByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override List<FeedbackDTO> SelectAll()
        {

            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllFeedback");

            SqlDataReader reader = command.ExecuteReader();

            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();

            if (reader.HasRows)
            {
               
               
                while (reader.Read())
                {
                    FeedbackDTO feedback = new FeedbackDTO()
                    {

                        ID = (int)reader["id"],
                        StageChangedID = (int)reader["StageChangedID"],
                        UserID = (int)reader["UserID"],
                        Message = (string)reader["Message"],
                        TimeFeedback = (DateTime)reader["TimeFeedback"],

                    };

                    feedbacks.Add(feedback);
                }
            }
            reader.Close();
            Connection.Close();
            return feedbacks;
        }  

        public override FeedbackDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectFeedbackByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            FeedbackDTO feedback = new FeedbackDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    feedback.ID = (int)reader["id"];
                    feedback.StageChangedID = (int)reader["StageChangedID"];
                    feedback.UserID = (int)reader["UserID"];
                    feedback.Message = (string)reader["Message"];
                    feedback.TimeFeedback = (DateTime)reader["TimeFeedback"];

                };
            }
            reader.Close();
            Connection.Close();
            return feedback;
        }

        public override int UpdateByID(FeedbackDTO dto)
        {
            var procedure = "[UpdateFeedbackByID]";
            var values = new
            {
                ID = dto.ID,
                StageChangedID = dto.StageChangedID,
                UserID = dto.UserID,
                Message = dto.Message,
                TimeFeedback = dto.TimeFeedback
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }
    }
}





