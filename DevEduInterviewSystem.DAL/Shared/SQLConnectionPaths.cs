using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Shared
{
    public struct SQLConnectionPaths
    {
        public const string MainConnectionString = @"Data Source=localhost;Initial Catalog=DevEduInterviewSystem.DataBase;;Integrated Security=True; ";
        public const string TestConnectionString = @"Data Source=DESKTOP-HRBRQKP;Initial Catalog=DevEduInterviewSystem.DataBaseTest3;Integrated Security=True; Data Source=(local)";
    }
}
