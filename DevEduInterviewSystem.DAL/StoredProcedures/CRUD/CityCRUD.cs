using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CityCRUD : AbstractCRUD<CityDTO>
    {
        public override int Add(CityDTO dto)
        {
            var procedure = "[AddCity]";
            var values = new
            {
                Name = dto.Name
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[City]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCityByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();
            return rows;
        }

        public override int UpdateByID(CityDTO dto)
        {
            var procedure = "[UpdateCityByID]";
            var values = new
            {
                dto.ID,
                dto.Name
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }

        public override List<CityDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCity");
            SqlDataReader reader = command.ExecuteReader();

            List<CityDTO> cities = new List<CityDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CityDTO city = new CityDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["Name"],
                    };
                    cities.Add(city);
                }
            }
            reader.Close();
            Connection.Close();
            return cities;
        }

        public override CityDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCityByID");
            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            CityDTO city = null;
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    city = new CityDTO();
                    city.ID = (int)reader["id"];
                    city.Name = (string)reader["Name"]; 
                }
            }
            reader.Close();
            Connection.Close();
            return city;
        }
    }
}
