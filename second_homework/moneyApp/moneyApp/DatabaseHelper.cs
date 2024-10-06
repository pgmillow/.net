using MySql.Data.MySqlClient;
using System;

namespace moneyApp
{
    public static class DatabaseHelper
    {
        private static string connectionString;

        // 静态构造函数，初始化数据库连接字符串


        static DatabaseHelper()
        {
            // 在这里设置连接字符串
            connectionString = "server=127.0.0.1;user=root;database=accountapp;port=3306;password=284257"; // 示例连接字符串
        }

        // 检查用户是否存在，返回密码
        public static bool UserExists(string username, out string password)
        {
            password = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open(); // 打开数据库连接
                string checkUserSql = "SELECT * FROM accounts WHERE username = @username"; // SQL 查询
                MySqlCommand checkUserCmd = new MySqlCommand(checkUserSql, conn);
                checkUserCmd.Parameters.AddWithValue("@username", username); // 添加参数
                MySqlDataReader rdr = checkUserCmd.ExecuteReader();

                if (rdr.HasRows) // 检查是否有记录
                {
                    rdr.Read();
                    password = rdr["password"].ToString(); // 获取密码
                    rdr.Close();
                    return true; // 用户存在
                }
                rdr.Close();
                return false; // 用户不存在
            }
        }

        // 创建新用户
        public static void CreateUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open(); // 打开数据库连接
                string createUserSql = "INSERT INTO accounts (username, password, balance, credit_limit) VALUES (@username, @password, 0.00, 1000.00)"; // SQL 插入语句
                MySqlCommand createUserCmd = new MySqlCommand(createUserSql, conn);
                createUserCmd.Parameters.AddWithValue("@username", username); // 添加用户名参数
                createUserCmd.Parameters.AddWithValue("@password", password); // 添加密码参数
                createUserCmd.ExecuteNonQuery(); // 执行插入操作
            }
        }

        // 删除用户
        public static void DeleteUser(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open(); // 打开数据库连接
                string deleteUserSql = "DELETE FROM accounts WHERE username = @username"; // SQL 删除语句
                MySqlCommand deleteUserCmd = new MySqlCommand(deleteUserSql, conn);
                deleteUserCmd.Parameters.AddWithValue("@username", username); // 添加用户名参数
                deleteUserCmd.ExecuteNonQuery(); // 执行删除操作
            }
        }

        // 获取用户账户信息
        public static Account GetAccountByUsername(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string getAccountSql = "SELECT * FROM accounts WHERE username = @username";
                MySqlCommand getAccountCmd = new MySqlCommand(getAccountSql, conn);
                getAccountCmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader rdr = getAccountCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                    string password = rdr["password"].ToString();
                    decimal balance = Convert.ToDecimal(rdr["balance"]);
                    double creditLimit = Convert.ToDouble(rdr["credit_limit"]);
                    rdr.Close();
                    return new Account(username, password, balance, creditLimit);
                }
                rdr.Close();
                return null; // 如果用户不存在，返回 null
            }
        }

        public static void UpdateAccount(Account account)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string updateAccountSql = "UPDATE accounts SET balance = @balance WHERE username = @username";
                MySqlCommand updateAccountCmd = new MySqlCommand(updateAccountSql, conn);
                updateAccountCmd.Parameters.AddWithValue("@balance", account.Balance);
                updateAccountCmd.Parameters.AddWithValue("@username", account.Username);
                updateAccountCmd.ExecuteNonQuery();
            }
        }

    }
}
