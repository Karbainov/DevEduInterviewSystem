using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.BLL
{
    class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message)
        : base(message)
        { }
    }
}
