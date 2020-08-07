using System;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CandidateDTO
    {
        public int ID { get; set; }
        public int StageID { get; set; }
        public  int StatusID { get; set; }
        public int CityID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public CandidateDTO()
        {

        }

        public CandidateDTO(int ID, int StageID, int StatusID, int CityID, string Phone, string Email, string FirstName, string LastName, DateTime BirthDay)
        {
            this.ID = ID;
            this.StageID = StageID;
            this.StatusID = StatusID;
            this.CityID = CityID;
            this.Phone = Phone;
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDay = BirthDay;                    
        }
    }
}
