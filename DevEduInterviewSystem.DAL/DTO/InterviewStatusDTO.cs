using System;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class InterviewStatusDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public InterviewStatusDTO()
        {

        }

        public InterviewStatusDTO(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
