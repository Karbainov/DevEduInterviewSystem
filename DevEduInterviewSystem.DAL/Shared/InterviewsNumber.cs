using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DevEduInterviewSystem.BLL
{
    public class InterviewsNumber
    {
        public int InterviewsLimit { get { return _interviewsLimit; } set { _interviewsLimit = value; } }

        public InterviewsNumber(int interviewsLimit)
        {
            _interviewsLimit = interviewsLimit;
        }
        public static InterviewsNumber GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InterviewsNumber();
            }
            return _instance;
        }

        private static InterviewsNumber _instance;

        private int _interviewsLimit = 3;
        private InterviewsNumber() { }



        //public int _interviewsLimit = 3;

        //public InterviewsNumber(int interviewsLimit)
        //{
        //    _interviewsLimit = interviewsLimit;
        //}

        //public int GetNumber()
        //{
        //    return _interviewsLimit;
        //}




    }
}
