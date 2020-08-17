using DevEduInterviewSystem.DAL.DTO;
using System.Collections;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class TestStatusDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestStatusDTO(1, "Done");
            yield return new TestStatusDTO(2, "Not done");
        }
    }
}
