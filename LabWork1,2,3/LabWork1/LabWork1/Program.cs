using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Menu.MainMenu();
                }
                while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
