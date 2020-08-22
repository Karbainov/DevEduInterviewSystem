using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.User
{
    public class GetRolesByUserID
    {
        public List<dynamic> GetRoles(int ID)
        {

            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

            var procedure = "[GetRolesByUserID]";
            var result = connection.Query(procedure, ID, commandType: CommandType.StoredProcedure).ToList();
            return result;

            // DIDN"T WORk
            //IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            //var procedure = "[GetRolesByUserID]";

            //var allInfo = connection.Query<List<string>>(procedure, new { ID },
            //commandType: CommandType.StoredProcedure
            //).SingleOrDefault();

            //return allInfo;

        }
    }
}
