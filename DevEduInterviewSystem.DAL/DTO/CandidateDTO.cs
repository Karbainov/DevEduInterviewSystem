using System;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CandidateDTO:IDTO
    {
        public int? ID { get; set; }
        public int? StageID { get; set; }
        public  int? StatusID { get; set; }
        public int? CityID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }

        public CandidateDTO()
        {

        }

        public CandidateDTO(int ID, int? stageID, int? statusID, int? cityID, string phone, string email, string firstName, string lastName, DateTime? birthDay)
        {
            this.ID = ID;
            this.StageID = stageID;
            this.StatusID = statusID;
            this.CityID = cityID;
            this.Phone = phone;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;                    
        }
    }
}
