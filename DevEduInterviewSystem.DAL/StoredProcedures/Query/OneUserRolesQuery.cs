using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class OneUserRolesQuery
    {
        public OneUserRolesDTO SelectUserWithAllRoles(int ID)
        {
            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            var procedure = "[OneUserRoles]";

            var userRoles = connection.Query<OneUserRolesDTO>(procedure, new { ID },

            commandType: CommandType.StoredProcedure).SingleOrDefault();

            return userRoles;
        }
    }
}
