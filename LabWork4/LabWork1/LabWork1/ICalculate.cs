using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public interface ICalculate
    {
        long Sum(long number1, long number2);

        long Subtraction(long number1, long number2);

        long Multiplication(long number1, long number2);

        long Division(long number1, long number2);

        long RemainderOfDivision(long number1, long number2);
    }
}
