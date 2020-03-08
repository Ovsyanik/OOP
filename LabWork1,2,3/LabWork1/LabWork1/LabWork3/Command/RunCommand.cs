using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    class RunCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Я бегу!!!");
        }
    }
}
