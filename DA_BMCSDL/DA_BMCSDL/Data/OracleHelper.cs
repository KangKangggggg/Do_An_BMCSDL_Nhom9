using Oracle.ManagedDataAccess.Client;

namespace DA_BMCSDL.Data
{
    public class OracleHelper
    {
        private static string BuildConnStr(string user, string pass)
            => $"User Id={user};Password={pass};Data Source=localhost:1521/FREEPDB1;";

        public static OracleConnection GetConnection(string user, string pass)
            => new OracleConnection(BuildConnStr(user, pass));

        public static bool TestLogin(string user, string pass)
        {
            try
            {
                using var conn = GetConnection(user, pass);
                conn.Open();
                return true;
            }
            catch { return false; }
        }
    }
}
