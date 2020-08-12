using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class AllInformationAboutTheCandidateByIDDTO
    {
        public int ID { get; set; }       
        public string TypeOfStage { get; set; }
        public string TypeOfStatus { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string FeedBack { get; set; }
        public string CurseName { get; set; }
        public string GroupName { get; set; }
        public string MaritalStatus { get; set; }
        public string Education { get; set; }
        public string WorkPlace { get; set; }
        public string ITExperience { get; set; }
        public string Hobbies { get; set; }
        public string InfoSourse { get; set; }
        public string Expectations { get; set; }

        public AllInformationAboutTheCandidateByIDDTO()
        {

        }

        public AllInformationAboutTheCandidateByIDDTO(int id, string stage, string status, string city, string phone, string email,string firstName, string lastName, DateTime birthDay, string feedBack,
            string curseName, string groupName, string maritalStatus, string education, string work, string itExperience, string hobbies, string infoSourse, string expectations)
        {
            ID = id;
            TypeOfStage = stage;
            TypeOfStatus = status;
            City = city;
            Phone = phone;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthDay;
            FeedBack = feedBack;
            CurseName = curseName;
            GroupName = groupName;
            MaritalStatus = maritalStatus;
            Education = education;
            WorkPlace = work;
            ITExperience = itExperience;
            Hobbies = hobbies;
            InfoSourse = infoSourse;
            Expectations = expectations;
        }
    }
}
