using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CityCRUD : AbstractCRUD<CityDTO>
    {
        public override int Add(CityDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCity");

            SqlParameter CityNameParam = new SqlParameter("@Name", dto.CityName);
            command.Parameters.Add(CityNameParam);

            int a = (int)(decimal)command.ExecuteScalar();
            Connection.Close();
            return a;

        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@DeleteCityByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override int UpdateByID(CityDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@UpdateCityByID");
            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a; return command.ExecuteNonQuery();
        }

        public override List<CityDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@SelectAllCity");
            SqlDataReader reader = command.ExecuteReader();

            List<CityDTO> citys = new List<CityDTO>();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    CityDTO city = new CityDTO()
                    {
                        ID = (int)reader["id"],
                        CityName = (string)reader["City"],
                    };
                    citys.Add(city);
                }
            }
            reader.Close();
            Connection.Close();
            return citys;
        }

        public override CityDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@SelectCityByID");
            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            CityDTO city = new CityDTO();
            
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    {
                        city.ID = (int)reader["id"];
                        city.CityName = (string)reader["City"];
                    }
                }
            }
            reader.Close();
            Connection.Close();
            return city;
        }
    }
}
