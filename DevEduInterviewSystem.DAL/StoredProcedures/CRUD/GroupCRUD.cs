using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class GroupCRUD : AbstractCRUD<GroupDTO>
    {
        public override int Add(GroupDTO dto)
        {         
            var procedure = "[AddGroup]";
            var values = new
            {
                CourseID = dto.CourseID,
                Name = dto.Name,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            Connection.Open();

            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Group]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteGroupByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override List<GroupDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllGroup");

            SqlDataReader reader = command.ExecuteReader();

            List<GroupDTO> groups = new List<GroupDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    GroupDTO group = new GroupDTO()
                    {
                        ID = (int)reader["id"],
                        CourseID = (int)reader["CourseID"],
                        Name = (string)reader["Name"],
                        StartDate = (DateTime)reader["StartDate"],
                        EndDate = (DateTime)reader["EndDate"]
                    };

                    groups.Add(group);                   
                }
            }
            reader.Close();
            Connection.Close();
            return groups;
        }

        public override GroupDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectGroupByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            GroupDTO groups = new GroupDTO();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    groups.ID = (int)reader["id"];
                    groups.CourseID = (int)reader["CourseID"];
                    groups.Name = (string)reader["Name"];
                    groups.StartDate = (DateTime)reader["StartDate"];
                    groups.EndDate = (DateTime)reader["EndDate"];
                }
            }
            reader.Close();
            Connection.Close();
            return groups;
        }

        public override int UpdateByID(GroupDTO dto)
        {
            var procedure = "[UpdateGroupByID]";
            var values = new
            {
                ID = dto.ID,
                CourseID = dto.CourseID,
                Name = dto.Name,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }
    }
}
