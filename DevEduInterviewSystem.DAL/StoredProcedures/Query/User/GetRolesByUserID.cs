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
        public List<string> GetListOfRoles(int ID)
        {
            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            var procedure = "[GetRolesByUserID]";
            List<string> list = new List<string>();
            var allInfo = connection.Query<UserRoleDTO ,RoleDTO,List<string>>(procedure,(userrole, role) => 
            {
                if(userrole.UserID == ID && role.ID == userrole.RoleID )
                {
                    if (!list.Contains(role.TypeOfRole))
                    {
                        list.Add(role.TypeOfRole);
                    }
                }
                return list;
            },new { ID },
            splitOn: "UserID, TypeOfRole",
            commandType: CommandType.StoredProcedure
            ).FirstOrDefault();

            return allInfo;

            // DIDN'T WORK
            //IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

            //var procedure = "[GetRolesByUserID]";
            //var result = connection.Query(procedure, ID, commandType: CommandType.StoredProcedure).ToList();
            //return result;
        }
    }
}
