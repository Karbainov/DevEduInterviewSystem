using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class RoleDTOMocks : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new RoleDTO(1, "Admin");
            yield return new RoleDTO(2, "Manager");
            yield return new RoleDTO(3, "Teacher");
            yield return new RoleDTO(4, "Phone Operator");
            yield return new RoleDTO(5, "CandidateTMP");
        }
    }
}
