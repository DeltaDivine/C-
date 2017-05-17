using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpMysql
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            do
            {
                UserModel model = new UserModel();
                Console.WriteLine("------Menu-------");
                Console.WriteLine("1. - Add User.");
                Console.WriteLine("2. - List User.");
                Console.WriteLine("3. - Delete User.");
                Console.WriteLine("4. - Edit User.");
                Console.WriteLine("5. - Exit.");
                Console.WriteLine("Input selected : ");
                x = Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        User u = new User();
                        Console.WriteLine("Input Name :");
                        u.Name = Console.ReadLine();
                        Console.WriteLine("Input Password : ");
                        u.Password = Console.ReadLine();
                        Console.WriteLine("Input Phone : ");
                        u.Phone = Console.ReadLine();
                        model.addUser(u);
                        break;
                    case 2:
                        model.getList();
                        break;
                    case 3:
                        model.deleteUser();
                        break;
                    case 4:
                        Console.WriteLine("Input name to fix :");
                        string name = Console.ReadLine();
                        User existUser = model.getUserByName(name);
                        Console.WriteLine("Existed user with info bellow :");
                        Console.WriteLine("name: " + existUser.Name);
                        Console.WriteLine("password: " + existUser.Password);
                        Console.WriteLine("phone: " + existUser.Phone);
                        Console.WriteLine("----------");

                        Console.WriteLine("Input new password :");
                        existUser.Password = Console.ReadLine();
                        Console.WriteLine("Input new phone number :");
                        existUser.Phone = Console.ReadLine();
                        model.conn.Open();
                        model.updateUser(existUser);
                        break;
                    case 5:
                        Console.WriteLine("Exit.");
                        break;


                }
            }
            while (x != 5);
        }
    }
}
