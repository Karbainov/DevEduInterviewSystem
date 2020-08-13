using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CandidatePersonalInfoCRUD : AbstractCRUD<CandidatePersonalInfoDTO>
    {
        public override int Add(CandidatePersonalInfoDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCandidatePersonalInfo");

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            SqlParameter MaritalStatusParam = new SqlParameter("MaritalStatus", dto.MaritalStatus);
            command.Parameters.Add(MaritalStatusParam);

            SqlParameter EducationParam = new SqlParameter("@Education", dto.Education);
            command.Parameters.Add(EducationParam);

            SqlParameter WorkPlaceParam = new SqlParameter("@WorkPlace", dto.WorkPlace);
            command.Parameters.Add(WorkPlaceParam);

            SqlParameter ITExperienceParam = new SqlParameter("@ITExperience", dto.ITExperience);
            command.Parameters.Add(ITExperienceParam);

            SqlParameter HobbiesParam = new SqlParameter("@Hobbies", dto.Hobbies);
            command.Parameters.Add(HobbiesParam);

            SqlParameter InfoSourseParam = new SqlParameter("@InfoSourse", dto.InfoSourse);
            command.Parameters.Add(InfoSourseParam);

            SqlParameter ExpectationsParam = new SqlParameter("@Expectations", dto.Expectations);
            command.Parameters.Add(ExpectationsParam);

            int a = (int)(decimal)command.ExecuteScalar();
            Connection.Close();
            return a;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCandidatePersonalInfoByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override List<CandidatePersonalInfoDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCandidatePersonalInfo");

            SqlDataReader reader = command.ExecuteReader();

            List<CandidatePersonalInfoDTO> candidates = new List<CandidatePersonalInfoDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CandidatePersonalInfoDTO candidate = new CandidatePersonalInfoDTO()
                    {
                        ID = (int)reader["id"],
                        CandidateID = (int)reader["CandidateID"],
                        MaritalStatus = (bool)reader["MaritalStatus"],
                        Education = (string)reader["Education"],
                        WorkPlace = (string)reader["WorkPlace"],
                        ITExperience = (string)reader["ITExperience"],
                        Hobbies = (string)reader["Hobbies"],
                        InfoSourse = (string)reader["InfoSourse"],
                        Expectations = (string)reader["Expectations"]
                    };

                    candidates.Add(candidate);
                }
            }

            reader.Close();
            Connection.Close();
            return candidates;
        }

        public override CandidatePersonalInfoDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCandidatePersonalInfoByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            CandidatePersonalInfoDTO candidate = new CandidatePersonalInfoDTO();

            if (reader.HasRows) 
            {

                while (reader.Read()) 
                {
                    candidate.ID = (int)reader["id"];
                    candidate.CandidateID = (int)reader["CandidateID"];
                    candidate.MaritalStatus = (bool)reader["MaritalStatus"];
                    candidate.Education = (string)reader["Education"];
                    candidate.WorkPlace = (string)reader["WorkPlace"];
                    candidate.ITExperience = (string)reader["ITExperience"];
                    candidate.Hobbies = (string)reader["Hobbies"];
                    candidate.InfoSourse = (string)reader["InfoSourse"];
                    candidate.Expectations = (string)reader["Expectations"];

                }
            }
            reader.Close();
            Connection.Close();
            return candidate;
        }

        public override int UpdateByID(CandidatePersonalInfoDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCandidatePersonalInfoByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            SqlParameter MaritalStatusParam = new SqlParameter("MaritalStatus", dto.MaritalStatus);
            command.Parameters.Add(MaritalStatusParam);

            SqlParameter EducationParam = new SqlParameter("@Education", dto.Education);
            command.Parameters.Add(EducationParam);

            SqlParameter WorkPlaceParam = new SqlParameter("@WorkPlace", dto.WorkPlace);
            command.Parameters.Add(WorkPlaceParam);

            SqlParameter ITExperienceParam = new SqlParameter("@ITExperience", dto.ITExperience);
            command.Parameters.Add(ITExperienceParam);

            SqlParameter HobbiesParam = new SqlParameter("@Hobbies", dto.Hobbies);
            command.Parameters.Add(HobbiesParam);

            SqlParameter InfoSourseParam = new SqlParameter("@InfoSourse", dto.InfoSourse);
            command.Parameters.Add(InfoSourseParam);

            SqlParameter ExpectationsParam = new SqlParameter("@Expectations", dto.Expectations);
            command.Parameters.Add(ExpectationsParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }       
       
    }
}
