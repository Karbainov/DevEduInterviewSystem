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
        public List<string> GetRoles(int ID)
        {
            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            var procedure = "[GetRolesByUserID]";

            var allInfo = connection.Query<List<string>>(procedure, new { ID },
            commandType: CommandType.StoredProcedure
            ).SingleOrDefault();

            return allInfo;

            //IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

            //var procedure = "[GetRolesByUserID]";
            ////var result = connection.Query(procedure, id, commandType: CommandType.StoredProcedure).ToList();
            ////return result;

            //List<string> result = new List<string>();

            //using (connection)
            //{
            //    connection.Open();

            //    var roles = connection.Query<string, int, string>(
            //           procedure,  (role, id) =>
            //            {
            //                result.Add(role);
            //                return role;
            //            },
            //            splitOn: "TypeOfRole",
            //            commandType: CommandType.StoredProcedure);
            //        //.ToList();
            //}
            //return result;
        }
    }
}
