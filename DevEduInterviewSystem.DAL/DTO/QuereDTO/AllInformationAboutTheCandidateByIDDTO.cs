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
        public string CityName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string FeedBack { get; set; }
        public string CourseName { get; set; }
        public string GroupName { get; set; }
        public bool MaritalStatus { get; set; }
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
            string curseName, string groupName, bool maritalStatus, string education, string work, string itExperience, string hobbies, string infoSourse, string expectations)
        {
            ID = id;
            TypeOfStage = stage;
            TypeOfStatus = status;
            CityName = city;
            Phone = phone;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthDay;
            FeedBack = feedBack;
            CourseName = curseName;
            GroupName = groupName;
            MaritalStatus = maritalStatus;
            Education = education;
            WorkPlace = work;
            ITExperience = itExperience;
            Hobbies = hobbies;
            InfoSourse = infoSourse;
            Expectations = expectations;
        }

        //public override bool Equals(object obj)
        //{
        //    var tmp = (AllInformationAboutTheCandidateByIDDTO)obj;
        //    if(tmp.ID == ID && 
        //        tmp.)
        //}
    }
}
