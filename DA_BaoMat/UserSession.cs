using System;

namespace HR_Management_Security
{
    public static class UserSession
    {
        public static string ConnectionString { get; set; }
        public static string OracleUser { get; set; }
        public static string FullName { get; set; }
        public static string Position { get; set; }
        public static int DepartmentID { get; set; }

        public static void Clear()
        {
            ConnectionString = null;
            OracleUser = null;
            FullName = null;
            Position = null;
            DepartmentID = 0;
        }
    }
}