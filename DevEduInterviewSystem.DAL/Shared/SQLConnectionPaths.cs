using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Shared
{
    public struct SQLConnectionPaths
    {
        public const string MainConnectionString = @"Data Source=DESKTOP-S3IPV2G;Initial Catalog=DevEduInterviewSystem.DataBase;Integrated Security=True; Data Source=(local)";
        public const string TestConnectionString = @"Data Source=DESKTOP-S3IPV2G;Initial Catalog=DevEduInterviewSystem.DataBaseTest;Integrated Security=True; Data Source=(local)";
    }
}
