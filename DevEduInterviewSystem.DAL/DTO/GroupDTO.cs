using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class GroupDTO : IDTO
    {
        public int? ID { get; set; }
        public int? CourseID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public GroupDTO()
        {

        }

        public GroupDTO(int ID, int CourseID, string Name, DateTime StartDate, DateTime EndDate)
        {
            this.ID = ID;
            this.CourseID = CourseID;
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
    }
}
