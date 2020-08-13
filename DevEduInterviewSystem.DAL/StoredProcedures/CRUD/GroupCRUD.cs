using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class GroupCRUD : AbstractCRUD<GroupDTO>
    {
        public override int Add(GroupDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddGroup");

            SqlParameter CourseParam = new SqlParameter("@CourceID", dto.CourseID);
            command.Parameters.Add(CourseParam);

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            SqlParameter StartDateParam = new SqlParameter("@StartDate", dto.StartDate);
            command.Parameters.Add(StartDateParam);

            SqlParameter EndDateParam = new SqlParameter("@EndDate", dto.EndDate);
            command.Parameters.Add(EndDateParam);

            int a = (int)(decimal)command.ExecuteScalar();
            Connection.Close();
            return a;
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
                        StartDate = (DateTime)reader["StartName"],
                        EndDate = (DateTime)reader["EndName"]
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

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t CourseID \t Name \t StartDate \t EndDate");

                while (reader.Read()) // построчно считываем данные
                {
                    groups.ID = (int)reader["id"];
                    groups.CourseID = (int)reader["CourseID"];
                    groups.Name = (string)reader["Name"];
                    groups.StartDate = (DateTime)reader["StartDate"];
                    groups.EndDate = (DateTime)reader["EndDate"];

                    //Console.WriteLine($"{id} \t {CourseID} \t{Name} \t{StartDate} \t{EndDate}");
                }
            }
            reader.Close();
            Connection.Close();
            return groups;
        }

        public override int UpdateByID(GroupDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateGroupByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter CourseParam = new SqlParameter("@CourseID", dto.CourseID);
            command.Parameters.Add(CourseParam);

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            SqlParameter StartDateParam = new SqlParameter("@StartDate", dto.StartDate);
            command.Parameters.Add(StartDateParam);

            SqlParameter EndDateParam = new SqlParameter("@EndDate", dto.EndDate);
            command.Parameters.Add(EndDateParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }
    }
}
