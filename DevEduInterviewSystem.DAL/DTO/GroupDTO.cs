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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDeleted { get; set; }
        public GroupDTO()
        {

        }

        public GroupDTO(int id, int courseID, string name, DateTime startDate, DateTime endDate, bool isDeleted=false)
        {
            this.ID = id;
            this.CourseID = courseID;
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.IsDeleted = isDeleted;
        }

    }
}
