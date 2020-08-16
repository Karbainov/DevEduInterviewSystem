﻿using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
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
            SqlCommand command = ReferenceToProcedure("@AddCity");
            SqlParameter CityNameParam = new SqlParameter("@Name", dto.CityName);
            command.Parameters.Add(CityNameParam);
            
            command.ExecuteNonQuery();

            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[City]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@DeleteCityByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();
            return rows;
        }

        public override int UpdateByID(CityDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@UpdateCityByID");
            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();
            return rows;
        }

        public override List<CityDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@SelectAllCity");
            SqlDataReader reader = command.ExecuteReader();

            List<CityDTO> cities = new List<CityDTO>();
            if (reader.HasRows) // если есть данные
            {
                // Построчно считываем данные
                while (reader.Read()) 
                {
                    CityDTO city = new CityDTO()
                    {
                        ID = (int)reader["id"],
                        CityName = (string)reader["City"],
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
            SqlCommand command = ReferenceToProcedure("@SelectCityByID");
            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            CityDTO city = new CityDTO();
            
            if (reader.HasRows)
            {
                while (reader.Read())
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
