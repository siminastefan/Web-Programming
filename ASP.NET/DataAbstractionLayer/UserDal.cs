using System;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Assignment9.Models;

using MySql.Data.MySqlClient;

namespace Assignment9.DataAbstractionLayer
{
    public class UserDal
    {
        public List<User> GetAllUsers()
        {
            MySqlConnection connection;
            string connectionString = "server=localhost;uid=root;pwd=;database=food;";
            List<User> users = new List<User>();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from users";
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("id");
                    string username = dataReader["username"].ToString();
                    string password = dataReader["password"].ToString();
                    
                    User user = new User(id, username, password);
                    users.Add(user);
                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return users;
        }

        public User GetUser(string username, string password)
        {
            MySqlConnection connection;
            string connectionString = "server=localhost;uid=root;pwd=;database=food;";
            
            connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText =
                "select * from users where username='" + username + "' and password='" + password + "'";
            MySqlDataReader dataReader = command.ExecuteReader();

            User user = null;
            
            if (dataReader.Read())
            {
                user = new User(dataReader.GetInt32("id"), dataReader.GetString("username"), dataReader.GetString("password"));
                
            }
            dataReader.Close();
            return user;
        }
    }
}