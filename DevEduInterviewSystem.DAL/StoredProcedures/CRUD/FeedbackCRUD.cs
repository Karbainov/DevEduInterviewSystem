using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class FeedbackCRUD : AbstractCRUD<FeedbackDTO>
    {
      
        public override int Add(FeedbackDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddFeedback", Connection);

            SqlParameter StageChangedIDParam = new SqlParameter("@StageChangedID", dto.StageChangedID);
            command.Parameters.Add(StageChangedIDParam);


            SqlParameter UserParam = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(UserParam);

            SqlParameter MessageParam = new SqlParameter("@Message", dto.Message);
            command.Parameters.Add(MessageParam);

            SqlParameter TimeFeedbackParam = new SqlParameter("@TimeFeedback", dto.TimeFeedback);
            command.Parameters.Add(TimeFeedbackParam);

            return command.ExecuteNonQuery();
        }

   
        public override int DeleteByID(int id)
        {
            Connection.Open();
            string sqlExpression = "DeleteFeedbackByID";
            SqlCommand command = new SqlCommand(sqlExpression, Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<FeedbackDTO> SelectAll()
        {

            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllFeedback", Connection);

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
            return feedbacks;
        }  

        public override FeedbackDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllFeedbackByID", Connection);

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
            return feedback;
        }

        public override int UpdateByID(FeedbackDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectFeedbackByID", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter StageChangedParam = new SqlParameter("@StageChangedID", dto.StageChangedID);
            command.Parameters.Add(StageChangedParam);


            SqlParameter UserParam = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(UserParam);

            SqlParameter MessageParam = new SqlParameter("@Message", dto.Message);
            command.Parameters.Add(MessageParam);

            SqlParameter TimeFeedbackParam = new SqlParameter("@TimeFeedback", dto.Message);
            command.Parameters.Add(TimeFeedbackParam);

            return command.ExecuteNonQuery();
        }
    }
}





