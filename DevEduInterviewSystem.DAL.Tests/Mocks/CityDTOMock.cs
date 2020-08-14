using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests
{
    public class CityDTOMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new CityDTO(1, "SaintP");
            yield return new CityDTO(2, "Minsk");
            yield return new CityDTO(3, "Kazan'");
        }
    }
}
