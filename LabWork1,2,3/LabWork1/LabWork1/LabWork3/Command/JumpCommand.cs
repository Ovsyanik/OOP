using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    class JumpCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Я прыгаю!!!");
        }
    }
}
