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
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@AddCity");
            SqlParameter CityNameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(CityNameParam);
            Connection.Close();
            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@DeleteCityByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override int UpdateByID(CityDTO dto)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@UpdateCityByID");
            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);

            command.Parameters.Add(IDParam);
            return command.ExecuteNonQuery();
        }

        public override List<CityDTO> SelectAll()
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@SelectAllCity");
            SqlDataReader reader = command.ExecuteReader();

            List<CityDTO> citys = new List<CityDTO>();
            // Если есть данные
            if (reader.HasRows) 
            {
                // Построчно считываем данные
                while (reader.Read()) 
                {
                    CityDTO city = new CityDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["name"],
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
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@SelectCityByID");
            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            CityDTO city = new CityDTO();
            // Если есть данные
            if (reader.HasRows)
            {
                // Построчно считываем данные
                while (reader.Read())
                {
                    {
                        city.ID = (int)reader["id"];
                        city.Name = (string)reader["name"];
                    }
                }
            }
            reader.Close();
            Connection.Close();
            return city;
        }
    }
}
