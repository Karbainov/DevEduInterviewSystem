﻿using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CandidatePersonalInfoCRUD : AbstractCRUD<CandidatePersonalInfoDTO>
    {
        public override int Add(CandidatePersonalInfoDTO dto)
        {
            var procedure = "[AddCandidatePersonalInfo]";
            var values = new
            {
                dto.CandidateID,
                dto.MaritalStatus,
                dto.Education,
                dto.WorkPlace,
                dto.ITExperience,
                dto.Hobbies,
                dto.InfoSourse,
                dto.Expectations
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[CandidatePersonalInfo]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCandidatePersonalInfoByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
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
            var procedure = "[UpdateCandidatePersonalInfoByID]";
            var values = new
            {
                dto.ID,
                dto.CandidateID,
                dto.MaritalStatus,
                dto.Education,
                dto.WorkPlace,
                dto.ITExperience,
                dto.Hobbies,
                dto.InfoSourse,
                dto.Expectations
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);           

            return (int)dto.ID;
        }       
       
    }
}
