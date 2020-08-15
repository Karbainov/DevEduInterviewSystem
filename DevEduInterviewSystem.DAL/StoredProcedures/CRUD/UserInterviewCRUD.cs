﻿using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class UserInterviewCRUD : AbstractCRUD<UserInterviewDTO>
    {
        public override int Add(UserInterviewDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddUser_Interview");

            SqlParameter InterviewIDParam = new SqlParameter("@InterviewID", dto.InterviewID);
            command.Parameters.Add(InterviewIDParam);

            SqlParameter userInterviewParam = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(userInterviewParam);

            command.ExecuteNonQuery();

            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[User_Interview]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

       

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteUser_InterviewByID");
            
            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

       
        public override List<UserInterviewDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllUser_Interview");

            SqlDataReader reader = command.ExecuteReader();

            List<UserInterviewDTO> userInterviews = new List<UserInterviewDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserInterviewDTO userInterview = new UserInterviewDTO()
                    {
                        ID = (int)reader["id"],
                        InterviewID = (int)reader["InterviewID"],
                        UserID = (int)reader["UserID"]
                    };
                    userInterviews.Add(userInterview);
                }
            }
            reader.Close();
            Connection.Close();
            return userInterviews;
        }
              

        public override UserInterviewDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectUser_InterviewByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            UserInterviewDTO userinterview = new UserInterviewDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userinterview.ID = (int)reader["id"];
                    userinterview.InterviewID = (int)reader["InterviewID"];
                    userinterview.UserID = (int)reader["UserID"];
                }
            }
            reader.Close();
            Connection.Close();
            return userinterview;
        }

       
        public override int UpdateByID(UserInterviewDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateUser_InterviewByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter InterviewIDParam = new SqlParameter("@InterviewID", dto.InterviewID);
            command.Parameters.Add(InterviewIDParam);

            SqlParameter UserIDParam = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(UserIDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

       

    }
}
