﻿using DevEduInterviewSystem.DAL.DTO;
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
			yield return new UserDTO(1, "Login", "***", "Sergey", "Timofeev", false);
			yield return new UserDTO(2, "Terminator", "***", "Polina", "Matveevna", false);
			yield return new UserDTO(3, "Qwery", "***", "Svetlana", "Fokina", false);
			yield return new UserDTO(4, "Ringer", "***", "Ekaterina", "Petrova", false);
		}
    }
}
