using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
using DevEduInterviewSystem.DAL.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DevEduInterviewSystem.DAL.Tests
{
    public class OneUserRolesTest
    {
    //    UserDTO userDTO;
    //    RoleDTO roleDTO;
    //    RoleDTO role2DTO;
    //    UserRoleDTO userRoleDTO;
    //    OneUserRolesDTO oneUserRolesDTO;

    //    UserCRUD user = new UserCRUD();
    //    RoleCRUD role = new RoleCRUD();
    //    RoleCRUD role2 = new RoleCRUD();
    //    UserRoleCRUD userRole = new UserRoleCRUD();

    //    int userID;
    //    int roleID;
    //    int role2ID;
    //    int userRoleID;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

    //        userDTO = new UserDTO(1, "Login", "Pass", "Polina", "Polikarpovna", false);
    //        userID = user.Add(userDTO);

    //        roleDTO = new RoleDTO(1, "Teacher");
    //        roleID = role.Add(roleDTO);
    //        role2DTO = new RoleDTO(2, "Manager");
    //        role2ID = role.Add(role2DTO);

    //        List<RoleDTO> roles = new List<RoleDTO>();
    //        roles.Add(roleDTO);
    //        roles.Add(role2DTO);

    //        userRoleDTO = new UserRoleDTO(userID, roleID);
    //        userRoleID = userRole.Add(userRoleDTO);

    //        oneUserRolesDTO = new OneUserRolesDTO("Login", "Polina", "Polikarpovna", roles);
    //    }
    //    public void TearDown()
    //    {
    //        user.DeleteByID(userID);
    //    }

    //    [TestCase(true)]
    //    public void Test1(bool expected)
    //    {
    //        OneUserRolesQuery query = new OneUserRolesQuery();

    //        bool actual = oneUserRolesDTO.Equals(query.SelectUserWithAllRoles(userID));

    //        Assert.AreEqual(expected, actual);

      // }

    }
}
