using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CsharpMysql
{
    class UserModel
    {
        public MySqlConnection conn;
        public MySqlCommand command;

        public UserModel()
        {
            String connectionString = "Server=localhost;Database=demo;Port=3306;User ID = root;Password = root";
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }

        public void addUser(User user)
        {
            command = conn.CreateCommand();
            command.CommandText = "insert into users (name,password,phone) values ('" + user.Name + "', '" + user.Password + "', '" + user.Phone + "')";
            command.ExecuteNonQuery();
            Console.WriteLine("Add cuscces.");
        }
        public void getList()
        {
            command = conn.CreateCommand();
            command.CommandText = "SELECT * From users";
            command.ExecuteNonQuery();
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["name"]);
                Console.WriteLine(reader["password"]);
                Console.WriteLine(reader["phone"]);
            }
        }

        public void deleteUser()
        {
            command = conn.CreateCommand();
            command.CommandText = "Delete From users where name = 'hung'";
            command.ExecuteNonQuery();
            Console.WriteLine("Delete success.");
        }
        public User getUserByName(string name)
        {
            command = conn.CreateCommand();
            command.CommandText = "select * from users WHERE name = '" + name + "'";
            MySqlDataReader reader = command.ExecuteReader();
            User u = new User();
            if (reader.Read())
            {
                u.Name = Convert.ToString(reader["name"]);
                u.Password = Convert.ToString(reader["password"]);
                u.Phone = Convert.ToString(reader["phone"]);
            }
            else
            {
                u = null;
            }
            conn.Close();
            return u;
        }

        public void updateUser(User u)
        {
            command = conn.CreateCommand();
            command.CommandText = "UPDATE users SET password='" + u.Password + "', phone='" + u.Phone + "' WHERE name='" + u.Name + "'";
            command.ExecuteNonQuery();
            Console.WriteLine("Update success.");
        }
    }
}
