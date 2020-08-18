using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.Shared
{
    public struct SQLConnectionPaths
    {
        public const string MainConnectionString = @"Data Source = localhost;Initial Catalog=DevEduInterviewSystem.DataBase;Integrated Security=True;";
        public const string TestConnectionString = @"Data Source=DESKTOP-K0KPC3E;Initial Catalog=DevEduInterviewSystem.DataBaseTest;Integrated Security=True; Data Source=(local)";
    }
}
