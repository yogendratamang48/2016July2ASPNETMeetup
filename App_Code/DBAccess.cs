using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Demo.Meetup.CustomMembership.App_Code
{
    public class DBAccess
    {
       
        public static string Encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
        public static bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection con = DBConfig.GetConnection())
            {
                //con.Open();
                string SQL = "sp_Authenticate_User";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@fldUsername", username);
                CMD.Parameters.AddWithValue("@fldPassword", password);
                int ReturnCode = Convert.ToInt32(CMD.ExecuteScalar());
                CMD.Connection.Close();
                CMD = null;
                return ReturnCode == 1;
            }

        }
        public static bool DoesUsernameAlreadyExists(string username)
        {
            using (SqlConnection con = DBConfig.GetConnection())
            {
                //con.Open();
                string SQL = "sp_Check_User";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@fldUsername", username);
                int ReturnCode = Convert.ToInt32(CMD.ExecuteScalar());
                CMD.Connection.Close();
                CMD = null;
                return ReturnCode == -1;
            }
            
        }
        public static int CreateUser(tblUser employee)
        {
            int result = 0;
            
            using (SqlConnection con =DBConfig.GetConnection())
            {
                //con.Open();
                string SQL = "sp_insert_User";
                SqlCommand CMD = new SqlCommand(SQL, con);
                string password = Encryption(employee.fldPassword);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@fldUsername", employee.fldUsername);
                CMD.Parameters.AddWithValue("@fldPassword", password);
                CMD.Parameters.AddWithValue("@fldRole", employee.fldRole);

                result = CMD.ExecuteNonQuery();
                
                CMD.Connection.Close();
                CMD = null;
                return result;
            }
        }
        public static string GetRoleForUser(string username)

        { 
             string result = "";
            
            using (SqlConnection con = DBConfig.GetConnection())
            {
                //con.Open();
                string SQL = "sp_GetRoleForUser";
                SqlCommand CMD = new SqlCommand(SQL, con);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@fldUsername", username);

                result = Convert.ToString(CMD.ExecuteScalar());
                
                CMD.Connection.Close();
                return result;
            }

        }
    }
}