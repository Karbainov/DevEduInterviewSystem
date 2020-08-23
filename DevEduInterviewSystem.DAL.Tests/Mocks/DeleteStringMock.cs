using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class DeleteStringMock
    {
        public IEnumerator GetEnumerator()
        {   
            yield return new string("DELETE FROM dbo.[Homework]");
            yield return new string("DELETE FROM dbo.[HomeworkStatus]");
            yield return new string("DELETE FROM dbo.[TestStatus]");
            yield return new string("DELETE FROM dbo.[Feedback]");
            yield return new string("DELETE FROM dbo.[StageChanged]");
            yield return new string("DELETE FROM dbo.[Group_Candidate]");
            yield return new string("DELETE FROM dbo.[Group]");
            yield return new string("DELETE FROM dbo.[Course_Candidate]");
            yield return new string("DELETE FROM dbo.[Course]");
            yield return new string("DELETE FROM dbo.[User_Interview]");
            yield return new string("DELETE FROM dbo.[Interview]");
            yield return new string("DELETE FROM dbo.[Task]");
            yield return new string("DELETE FROM dbo.[CandidatePersonalInfo]");
            yield return new string("DELETE FROM dbo.[Candidate]");
            yield return new string("DELETE FROM dbo.[InterviewStatus]");
            yield return new string("DELETE FROM dbo.[Stage]");
            yield return new string("DELETE FROM dbo.[Status]");
            yield return new string("DELETE FROM dbo.[City]");
            yield return new string("DELETE FROM dbo.[User_role]");
            yield return new string("DELETE FROM dbo.[User]");
            yield return new string("DELETE FROM dbo.[Role]");
        }
    }
}
