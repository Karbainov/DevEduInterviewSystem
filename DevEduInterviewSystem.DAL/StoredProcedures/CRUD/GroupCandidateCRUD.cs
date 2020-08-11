using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class GroupCandidateCRUD : AbstractCRUD<GroupCandidateDTO>
    {
        public override int Add(GroupCandidateDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddGroup_Candidate", Connection);

            SqlParameter GroupParam = new SqlParameter("@GroupID", dto.GroupID);
            command.Parameters.Add(GroupParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            string sqlExpression = "DeleteGroup_CandidateByID";
            SqlCommand command = new SqlCommand(sqlExpression, Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<GroupCandidateDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllGroup_Candidate", Connection);

            SqlDataReader reader = command.ExecuteReader();

            List<GroupCandidateDTO> groupsCandidates = new List<GroupCandidateDTO>();

            if (reader.HasRows) // Eсли есть данные.
            {
                // Выводим названия столбцов.
                // Console.WriteLine($"id \t GroupID \t CandidateID");
                while (reader.Read()) // Построчно считываем данные.
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

            return groupsCandidates;
        }

        public override GroupCandidateDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectGroup_СandidateByID", Connection);

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

                    //Console.WriteLine($"{id} \t{GroupID} \t{CandidateID} ");
                }
            }
            reader.Close();

            return groupCandidate;
        }

        public override int UpdateByID(GroupCandidateDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateGroup_CandidateByID", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter GroupParam = new SqlParameter("@InterviewID", dto.GroupID);
            command.Parameters.Add(GroupParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            return command.ExecuteNonQuery();
        }
    }
}
