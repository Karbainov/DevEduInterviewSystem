using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CandidateCRUD:AbstractCRUD<CandidateDTO>
    {
        public override int Add(CandidateDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCandidate");

            SqlParameter StageParam = new SqlParameter("@StageID", dto.StageID);
            command.Parameters.Add(StageParam);

            SqlParameter StatusParam = new SqlParameter("@StatusID", dto.StatusID);
            command.Parameters.Add(StatusParam);

            SqlParameter CityParam = new SqlParameter("@CityID", dto.CityID);
            command.Parameters.Add(CityParam);

            SqlParameter PhoneParam = new SqlParameter("@Phone", dto.Phone);
            command.Parameters.Add(PhoneParam);

            SqlParameter EmailParam = new SqlParameter("@Email", dto.Email);
            command.Parameters.Add(EmailParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", dto.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", dto.LastName);
            command.Parameters.Add(LastNameParam);

            SqlParameter BDParam = new SqlParameter("@BirthDay", dto.BirthDay);
            command.Parameters.Add(BDParam);


            int a = (int)(decimal)command.ExecuteScalar();
            Connection.Close();
            return a;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            string sqlExpression = "DeleteCandidateByID";
            SqlCommand command = ReferenceToProcedure("DeleteCandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);
            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override List<CandidateDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCandidate");


            List<CandidateDTO> candidates = new List<CandidateDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CandidateDTO candidate = new CandidateDTO()
                    {
                        ID = (int)reader["id"],
                        StageID = (int)reader["StageID"],
                        StatusID = (int)reader["StatusID"],
                        CityID = (int)reader["CityID"],
                        Phone = (string)reader["Phone"],
                        Email = (string)reader["Email"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        BirthDay = (DateTime)reader["Birthday"]
                    };

                    candidates.Add(candidate);
                }
            }
            reader.Close();

            return candidates;
        }

        public override CandidateDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            CandidateDTO candidate = new CandidateDTO();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    candidate.ID = (int)reader["id"];
                    candidate.StageID = (int)reader["StageID"];
                    candidate.StatusID = (int)reader["StatusID"];
                    candidate.CityID = (int)reader["CityID"];
                    candidate.Phone = (string)reader["Phone"];
                    candidate.Email = (string)reader["Email"];
                    candidate.FirstName = (string)reader["FirstName"];
                    candidate.LastName = (string)reader["LastName"];
                    candidate.BirthDay = (DateTime)reader["Birthday"];

                }
            }
            reader.Close();

            return candidate;
        }

        public override int UpdateByID(CandidateDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter StageParam = new SqlParameter("@StageID", dto.StageID);
            command.Parameters.Add(StageParam);

            SqlParameter StatusParam = new SqlParameter("@StatusID", dto.StatusID);
            command.Parameters.Add(StatusParam);

            SqlParameter CityParam = new SqlParameter("@CityID", dto.CityID);
            command.Parameters.Add(CityParam);

            SqlParameter PhoneParam = new SqlParameter("@Phone", dto.Phone);
            command.Parameters.Add(PhoneParam);

            SqlParameter EmailParam = new SqlParameter("@Email", dto.Email);
            command.Parameters.Add(EmailParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", dto.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", dto.LastName);
            command.Parameters.Add(LastNameParam);

            SqlParameter BDParam = new SqlParameter("@BirthDay", dto.BirthDay);
            command.Parameters.Add(BDParam);

            return command.ExecuteNonQuery();
        }    
    }
}
