using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class UserDTOMock : IEnumerable
	{
        public IEnumerator GetEnumerator()
        {
			yield return new UserDTO(1, "Login", "***", "Sergey", "Timofeev");
			yield return new UserDTO(2, "Terminator", "***", "Polina", "Matveevna");
			yield return new UserDTO(3, "Admin", "***", "Svetlana", "Fokina");

			//yield return new object[] { new UserDTO(1, "Login", "***", "Sergey", "Timofeev") };
			//yield return new object[] { new UserDTO(2, "Terminator", "***", "Polina", "Matveevna") };
			//yield return new object[] { new UserDTO(3, "Admin", "***", "Svetlana", "Fokina") };
		}
    }
}
