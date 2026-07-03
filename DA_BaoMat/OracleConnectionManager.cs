using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HR_Management_Security
{
    public static class OracleConnectionManager
    {
        public static string GetConnectionString(string username, string password)
        {
            return $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=FREEPDB1)));User Id={username};Password={password};";
        }

        public static DataTable ExecuteQuery(string connectionString, string sql, OracleParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (OracleCommand setRoleCmd = new OracleCommand("SET ROLE ALL", conn))
                    {
                        setRoleCmd.ExecuteNonQuery();
                    }

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (OracleException ex)
                {
                    HandleOracleSecurityException(ex);
                }
            }
            return dataTable;
        }

        public static int ExecuteNonQuery(string connectionString, string sql, OracleParameter[] parameters = null)
        {
            int rowsAffected = 0;
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (OracleCommand setRoleCmd = new OracleCommand("SET ROLE ALL", conn))
                    {
                        setRoleCmd.ExecuteNonQuery();
                    }

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (OracleException ex)
                {
                    HandleOracleSecurityException(ex);
                }
            }
            return rowsAffected;
        }

        private static void HandleOracleSecurityException(OracleException ex)
        {
            switch (ex.Number)
            {
                case 1017:
                    throw new Exception("LỖI BẢO MẬT: Tên đăng nhập hoặc mật khẩu hệ thống không đúng. Vui lòng thử lại!");
                case 28000:
                    throw new Exception("LỖI TÀI KHOẢN: Tài khoản nhân viên này đã bị khóa do nhập sai nhiều lần hoặc bị quản trị viên chặn.");
                case 1031:
                    throw new Exception("BỊ CHẶN (ROLE): Bạn không có đủ đặc quyền (Insufficient Privileges) để thực thi hành động này trên Database.");
                case 28115:
                    throw new Exception("VI PHẠM CHÍNH SÁCH VPD: Chính sách bảo mật mức hàng (VPD Policy) đã phát hiện và chặn quyền truy cập gói dữ liệu này của bạn.");
                case 4068:
                    throw new Exception("LỖI HỆ THỐNG: Gói bảo mật (Package/Trigger) trên CSDL đã bị thay đổi hoặc không hợp lệ.");
                default:
                    if (ex.Number >= 20000 && ex.Number <= 20999)
                    {
                        throw new Exception($"VI PHẠM QUY TẮC BẢO MẬT: {ex.Message}");
                    }
                    throw new Exception($"Lỗi Cơ sở dữ liệu mã số ({ex.Number}): {ex.Message}");
            }
        }
    }
}