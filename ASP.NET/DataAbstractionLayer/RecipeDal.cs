using System;
using System.Collections.Generic;
using Assignment9.Models;
using MySql.Data.MySqlClient;

namespace Assignment9.DataAbstractionLayer
{
    public class RecipeDal
    {
        private string _connectionString = "server=localhost;uid=root;pwd=;database=food;";
        public List<Recipe> GetAllRecipes()
        {
            MySqlConnection connection;
            List<Recipe> recipes = new List<Recipe>();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = _connectionString;
                connection.Open();
                
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from recipe";
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("id");
                    string author = dataReader.GetString("author");
                    string name = dataReader.GetString("name");
                    string type = dataReader.GetString("type");
                    string description = dataReader.GetString("description");
                    
                    Recipe recipe = new Recipe(id, author, name, type, description);
                    recipes.Add(recipe);
                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return recipes;
        }

        public void SaveRecipe(Recipe recipe)
        {
            MySqlConnection connection;

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = _connectionString;
                connection.Open();
                
                MySqlCommand command = new MySqlCommand();
                string sql = "insert into recipe (author, name, type, description) values (@author, @name, @type, @description)";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@author", recipe.Author);
                command.Parameters.AddWithValue("@name", recipe.Name);
                command.Parameters.AddWithValue("@type", recipe.Type);
                command.Parameters.AddWithValue("@description", recipe.Description);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeleteRecipe(int id)
        {
            MySqlConnection connection;

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = _connectionString;
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                string sql = "delete from recipe where id=@id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateRecipe(Recipe recipe)
        {
            MySqlConnection connection;

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = _connectionString;
                connection.Open();
                
                MySqlCommand command = new MySqlCommand();
                string sql =
                    "UPDATE recipe SET author=@author, name=@name, type=@type, description=@description WHERE id=@id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@author", recipe.Author);
                command.Parameters.AddWithValue("@name", recipe.Name);
                command.Parameters.AddWithValue("@type", recipe.Type);
                command.Parameters.AddWithValue("@description", recipe.Description);
                command.Parameters.AddWithValue("@id", recipe.Id);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Recipe> GetAllRecipesByType(string type)
        {
            MySqlConnection connection;
            List<Recipe> recipes = new List<Recipe>();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = _connectionString;
                connection.Open();

                string sql = "";
                if (type.Equals(""))
                {
                    sql = "select * from recipe";
                }
                else
                {
                    sql = "select * from recipe where type=@type";
                }
                
                MySqlCommand command = new MySqlCommand();
                command.CommandText = sql;
                command.Parameters.AddWithValue("@type", type);
                command.Connection = connection;
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("id");
                    string author = dataReader.GetString("author");
                    string name = dataReader.GetString("name");
                    string typeDB = dataReader.GetString("type");
                    string description = dataReader.GetString("description");
                    
                    Recipe recipe = new Recipe(id, author, name, typeDB, description);
                    recipes.Add(recipe);
                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return recipes;
        }
    }
}