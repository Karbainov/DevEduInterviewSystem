using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class GroupCandidateCRUD : AbstractCRUD<GroupCandidateDTO>
    {
        public override int Add(GroupCandidateDTO dto)
        {
            var procedure = "[AddCandidate]";
            var values = new
            {
                GroupID = dto.GroupID,
                CandidateID = dto.CandidateID     
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Group_Candidate]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteGroup_CandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override List<GroupCandidateDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllGroup_Candidate");

            SqlDataReader reader = command.ExecuteReader();

            List<GroupCandidateDTO> groupsCandidates = new List<GroupCandidateDTO>();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    GroupCandidateDTO groupCandidate = new GroupCandidateDTO()
                    {
                        ID = (int)reader["id"],
                        GroupID = (int)reader["GroupID"],
                        CandidateID = (int)reader["CandidateID"]
                    };

                    groupsCandidates.Add(groupCandidate);
                }
            }
            reader.Close();
            Connection.Close();
            return groupsCandidates;
        }

        public override GroupCandidateDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectGroup_СandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            GroupCandidateDTO groupCandidate = new GroupCandidateDTO();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    groupCandidate.ID = (int)reader["id"];
                    groupCandidate.GroupID = (int)reader["GroupID"];
                    groupCandidate.CandidateID = (int)reader["CandidateID"];

                }
            }
            reader.Close();
            Connection.Close();
            return groupCandidate;
        }

        public override int UpdateByID(GroupCandidateDTO dto)
        {
            var procedure = "[UpdateGroup_CandidateByID]";
            var values = new
            {
                ID = dto.ID,
                GroupID = dto.GroupID,
                CandidateID = dto.CandidateID
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }
    }
}
