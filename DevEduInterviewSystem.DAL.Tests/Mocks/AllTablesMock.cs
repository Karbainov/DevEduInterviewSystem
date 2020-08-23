using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures;
using System.Data;

namespace DevEduInterviewSystem.DAL.Tests.Mocks
{
    public class AllTablesMock
    {
        public List<int> RoleID;
        public List<int> UserID;
        public List<int> CityID;
        public List<int> StatusID;
        public List<int> StageID;
        public List<int> StageChangedID;
        public List<int> InterviewStatusID;
        public List<int> InterviewID;
        public List<int> TaskID;
        public List<int> CandidateID;
        public List<int> CourseID;
        public List<int> GroupID;
        public List<int> TestStatusID;
        public List<int> HomeworkStatusID;        

        public void AddData()
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            
            RoleID = new List<int>();
            UserID = new List<int>();
            CityID = new List<int>();
            StatusID = new List<int>();
            StageID = new List<int>();
            InterviewID = new List<int>();
            TaskID = new List<int>();
            CandidateID = new List<int>();
            InterviewStatusID = new List<int>();
            CourseID = new List<int>();
            GroupID = new List<int>();
            StageChangedID = new List<int>();
            TestStatusID = new List<int>();
            HomeworkStatusID = new List<int>();

            try
            {
                RoleCRUD roleCRUD = new RoleCRUD();
                RoleDTOMocks roleDTOMocks = new RoleDTOMocks();
                foreach (RoleDTO dto in roleDTOMocks)
                {
                    RoleID.Add(roleCRUD.Add(dto));
                }

                UserCRUD userCRUD = new UserCRUD();
                UserDTOMock userDTOMock = new UserDTOMock();
                foreach (UserDTO dto in userDTOMock)
                {
                    UserID.Add(userCRUD.Add(dto));
                }

                UserRoleCRUD userRoleCRUD = new UserRoleCRUD();
                for (int i = 0; i < UserID.Count; i++)
                {
                    UserRoleDTO userRole = new UserRoleDTO(1, UserID[i], RoleID[i]);
                    UserRoleDTO userRole2 = new UserRoleDTO(2, UserID[i], RoleID[RoleID.Count - i - 1]);
                    userRoleCRUD.Add(userRole);
                    userRoleCRUD.Add(userRole2);
                }

                CityCRUD cityCRUD = new CityCRUD();
                CityDTOMock cityDTOMock = new CityDTOMock();
                foreach (CityDTO dto in cityDTOMock)
                {
                    CityID.Add(cityCRUD.Add(dto));
                }

                StatusCRUD statusCRUD = new StatusCRUD();
                StatusDTOMock statusDTOMock = new StatusDTOMock();
                foreach (StatusDTO dto in statusDTOMock)
                {
                    StatusID.Add(statusCRUD.Add(dto));
                }

                StageCRUD stageCRUD = new StageCRUD();
                StageDTOMock stageDTOMock = new StageDTOMock();
                foreach (StageDTO dto in stageDTOMock)
                {
                    StageID.Add(stageCRUD.Add(dto));
                }

                InterviewStatusCRUD interviewStatusCRUD = new InterviewStatusCRUD();
                InterviewStatusDTOMock interviewStatusDTOMock = new InterviewStatusDTOMock();
                foreach (InterviewStatusDTO dto in interviewStatusDTOMock)
                {
                    InterviewStatusID.Add(interviewStatusCRUD.Add(dto));
                }

                CandidateCRUD candidateCRUD = new CandidateCRUD();
                CandidateDTOMock candidateDTOMock = new CandidateDTOMock();
                int id = 0;
                foreach (CandidateDTO dto in candidateDTOMock)
                {
                    if (id < StageID.Count)
                    {
                        dto.StageID = StageID[id];
                        dto.StatusID = StatusID[id];
                        dto.CityID = CityID[id];
                    }
                    else
                    {
                        dto.StageID = null;
                        dto.StatusID = null;
                        dto.CityID = null;
                    }
                    id++;

                    CandidateID.Add(candidateCRUD.Add(dto));
                }

                CandidatePersonalInfoCRUD personalInfoCRUD = new CandidatePersonalInfoCRUD();
                CandidatePersonalInfoDTOMock personalInfoDTOMock = new CandidatePersonalInfoDTOMock();
                id = 0;
                foreach (CandidatePersonalInfoDTO dto in personalInfoDTOMock)
                {
                    if (id < CandidateID.Count)
                    {
                        dto.CandidateID = CandidateID[id];
                    }
                    else if (CandidateID.Count != 0)
                    {
                        dto.CandidateID = CandidateID[0];
                    }
                    id++;

                    personalInfoCRUD.Add(dto);
                }

                TaskCRUD taskCRUD = new TaskCRUD();
                for (int i = 0; i < UserID.Count; i++)
                {
                    TaskDTO task1 = new TaskDTO(1, UserID[i], CandidateID[i]);
                    TaskDTO task2 = new TaskDTO(2, UserID[i], CandidateID[CandidateID.Count - i - 1]);
                    taskCRUD.Add(task1);
                    taskCRUD.Add(task2);
                }

                InterviewCRUD interviewCRUD = new InterviewCRUD();
                InterviewDTOMock interviewDTOMock = new InterviewDTOMock();
                id = 0;
                foreach (InterviewDTO dto in interviewDTOMock)
                {
                    if (id < CandidateID.Count && id < InterviewStatusID.Count)
                    {
                        dto.CandidateID = CandidateID[id];
                        dto.InterviewStatusID = InterviewStatusID[id];
                    }
                    else if (CandidateID.Count != 0)
                    {
                        dto.CandidateID = CandidateID[0];
                        dto.InterviewStatusID = InterviewStatusID[0];
                    }
                    InterviewID.Add(interviewCRUD.Add(dto));
                    id++;
                }

                UserInterviewCRUD userInterviewCRUD = new UserInterviewCRUD();
                for (int i = 0; i < UserID.Count; i++)
                {
                    UserInterviewDTO userInterview = new UserInterviewDTO(1, InterviewID[i], UserID[i]);
                    UserInterviewDTO userInterview2 = new UserInterviewDTO(2, InterviewID[UserID.Count - i - 1], UserID[i]);
                    userInterviewCRUD.Add(userInterview);
                    userInterviewCRUD.Add(userInterview2);
                }

                CourseCRUD courseCRUD = new CourseCRUD();
                Course2DTOMock course2DTOMock = new Course2DTOMock();
                foreach (CourseDTO dto in course2DTOMock)
                {
                    CourseID.Add(courseCRUD.Add(dto));
                }

                Course_CandidateCRUD course_CandidateCRUD = new Course_CandidateCRUD();
                for (int i = 0; i < CourseID.Count; i++)
                {
                    Course_CandidateDTO candidateOfCourse = new Course_CandidateDTO(1, CourseID[i], CandidateID[i]);
                    Course_CandidateDTO candidateOfCourse2 = new Course_CandidateDTO(2, CourseID[i], CandidateID[CandidateID.Count - i - 1]);
                    Course_CandidateDTO candidateOfCourse3 = new Course_CandidateDTO(3, CourseID[i], CandidateID[CandidateID.Count / 2]);
                    course_CandidateCRUD.Add(candidateOfCourse);
                    course_CandidateCRUD.Add(candidateOfCourse2);
                    course_CandidateCRUD.Add(candidateOfCourse3);
                }

                GroupCRUD groupCRUD = new GroupCRUD();
                GroupDTOMock groupDTOMock = new GroupDTOMock();
                id = 0;
                foreach (GroupDTO dto in groupDTOMock)
                {
                    if (id < CourseID.Count)
                    {
                        dto.CourseID = CourseID[id];
                    }
                    else if (CandidateID.Count != 0)
                    {
                        dto.CourseID = CourseID[0];
                    }
                    GroupID.Add(groupCRUD.Add(dto));
                    id++;
                }

                GroupCandidateCRUD groupCandidateCRUD = new GroupCandidateCRUD();
                for (int i = 0; i < GroupID.Count; i++)
                {
                    GroupCandidateDTO candidateOfGroup = new GroupCandidateDTO(1, GroupID[i], CandidateID[i]);
                    GroupCandidateDTO candidateOfGroup2 = new GroupCandidateDTO(2, GroupID[i], CandidateID[CandidateID.Count - i - 1]);
                    GroupCandidateDTO candidateOfGroup3 = new GroupCandidateDTO(3, GroupID[i], CandidateID[CandidateID.Count / 2]);
                    groupCandidateCRUD.Add(candidateOfGroup);
                    groupCandidateCRUD.Add(candidateOfGroup2);
                    groupCandidateCRUD.Add(candidateOfGroup3);
                }

                StageChangedCRUD stageChangedCRUD = new StageChangedCRUD();
                for (int i = 0; i < StageID.Count; i++)
                {
                    StageChangedDTO stageChanged = new StageChangedDTO(1, StageID[i], CandidateID[i], new DateTime(2020, 7, 20, 18, 30, 00));
                    StageChangedDTO stageChanged2 = new StageChangedDTO(2, StageID[i], CandidateID[CandidateID.Count - i - 1], new DateTime(2020, 8, 20, 10, 30, 00));
                    StageChangedDTO stageChanged3 = new StageChangedDTO(3, StageID[i], CandidateID[CandidateID.Count / 2], new DateTime(2020, 9, 20, 12, 00, 00));
                    StageChangedID.Add(stageChangedCRUD.Add(stageChanged));
                    StageChangedID.Add(stageChangedCRUD.Add(stageChanged2));
                    StageChangedID.Add(stageChangedCRUD.Add(stageChanged3));
                }

                FeedbackCRUD feedbackCRUD = new FeedbackCRUD();
                for (int i = 0; i < UserID.Count; i++)
                {
                    FeedbackDTO feedback = new FeedbackDTO(1, StageChangedID[i], UserID[i], "fantastic", new DateTime(2020, 7, 20, 18, 30, 00));
                    FeedbackDTO feedback2 = new FeedbackDTO(2, StageChangedID[StageChangedID.Count - i - 1], UserID[i], "genious", new DateTime(2020, 8, 20, 10, 30, 00));
                    FeedbackDTO feedback3 = new FeedbackDTO(3, StageChangedID[StageChangedID.Count / 2], UserID[i], "success", new DateTime(2020, 9, 20, 12, 00, 00));
                    feedbackCRUD.Add(feedback);
                    feedbackCRUD.Add(feedback2);
                    feedbackCRUD.Add(feedback3);
                }

                TestStatusCRUD testStatusCRUD = new TestStatusCRUD();
                TestStatusDTOMock testStatusDTO = new TestStatusDTOMock();
                foreach (TestStatusDTO dto in testStatusDTO)
                {
                    TestStatusID.Add(testStatusCRUD.Add(dto));
                }


                HomeworkStatusCRUD homeworkStatusCRUD = new HomeworkStatusCRUD();
                HomeworkStatusDTOMock homeworkStatusDTO = new HomeworkStatusDTOMock();
                foreach (HomeworkStatusDTO dto in homeworkStatusDTO)
                {
                    HomeworkStatusID.Add(homeworkStatusCRUD.Add(dto));
                }

                HomeworkCRUD homeworkCRUD = new HomeworkCRUD();
                for (int i = 0; i < TestStatusID.Count; i++)
                {
                    HomeworkDTO homework = new HomeworkDTO(1, CandidateID[i], HomeworkStatusID[i], TestStatusID[i], new DateTime(2020, 7, 20, 18, 30, 00));
                    HomeworkDTO homework2 = new HomeworkDTO(2, CandidateID[CandidateID.Count - i - 1], HomeworkStatusID[i], TestStatusID[i], new DateTime(2020, 8, 20, 10, 30, 00));
                    HomeworkDTO homework3 = new HomeworkDTO(3, CandidateID[CandidateID.Count / 2], HomeworkStatusID[i], TestStatusID[i], new DateTime(2020, 9, 20, 12, 00, 00));
                    homeworkCRUD.Add(homework);
                    homeworkCRUD.Add(homework2);
                    homeworkCRUD.Add(homework3);
                }
            }
            catch
            {
                transaction.Rollback();
            }

            connection.Close();
        }
        public void DeleteData()
        {
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

            IDbConnection idbConnection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            idbConnection.Open();
            IDbTransaction transaction = idbConnection.BeginTransaction();
            DeleteStringMock stringMock = new DeleteStringMock();

            try
            {
                foreach (string current in stringMock)
                {
                    connection.Open();
                    SqlCommand deleteDataInCurrentTable = new SqlCommand(current, connection);
                    deleteDataInCurrentTable.ExecuteScalar();
                    connection.Close();
                }
                
            }
            catch
            {
                transaction.Rollback();
            }

            idbConnection.Close();
        }
    }
}
