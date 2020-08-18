using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class CourseDTOMock
    {
        public IEnumerator GetEnumerator()
        {
            yield return new CourseDTO(1, "Base course");
            yield return new CourseDTO(2, "Mobile Xamarin");
            yield return new CourseDTO(3, "FrontEnd");
        }
    }
}
