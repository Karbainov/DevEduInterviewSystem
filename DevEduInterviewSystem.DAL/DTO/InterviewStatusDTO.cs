using System;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class InterviewStatusDTO : IDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public InterviewStatusDTO()
        {

        }

        public InterviewStatusDTO(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
}
