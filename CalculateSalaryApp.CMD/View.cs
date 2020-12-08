using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.CMD
{
    public class View
    {
       
        public static void ShowMenuDirector(string name)
        {
            Console.WriteLine(new String('=', 20));
            Console.WriteLine($"Welcome {name}");
            Console.WriteLine("Menu:");
            Console.WriteLine("1.Add Employee");
            Console.WriteLine("2.Show report for all user");
            Console.WriteLine("3.Show report for specific user");
            Console.WriteLine("4.Add work's hours");
            Console.WriteLine("5.Exit");
        }
        
        public static void SendMessage(string msg)
        {
            Console.WriteLine(msg);
        }


    }
}
