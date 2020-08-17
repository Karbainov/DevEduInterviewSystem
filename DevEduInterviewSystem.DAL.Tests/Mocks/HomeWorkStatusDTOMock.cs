using DevEduInterviewSystem.DAL.DTO;
using System.Collections;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class HomeWorkStatusDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new HomeworkStatusDTO(1, "Done");
            yield return new HomeworkStatusDTO(2, "Not done");
        }
    }
}
