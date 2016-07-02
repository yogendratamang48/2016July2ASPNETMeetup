using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Demo.Meetup.CustomMembership.App_Code
{
    public class DBConfig
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ExperimentConnection"].ConnectionString;
        }
        public static SqlConnection GetConnection()
        {
            try
            {
                return DBOpenconnection(GetConnectionString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }


        }
        static protected SqlConnection DBOpenconnection(string conStr)
        {
            //SqlConnection Tempconn ;
            try
            {
                SqlConnection Tempconn = new SqlConnection(conStr);
                //if (Tempconn.State == ConnectionState.Open)
                //{
                //    DBCloseconnection(Tempconn);
                //}
                Tempconn.ConnectionString = conStr;
                if (Tempconn.State == ConnectionState.Closed)
                    Tempconn.Open();
                return Tempconn;
            }
            catch (Exception ex)
            {
                //error log
                throw new Exception(ex.ToString());
                //return null;
            }

        }
        //close connection if it is opened
        static public void DBCloseconnection(SqlConnection Tempconn)
        {
            try
            {
                if (Tempconn == null || Tempconn.State == ConnectionState.Open)
                {
                    Tempconn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
                //error log
            }
        }

        public string Encryption(String password)
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

    }
}