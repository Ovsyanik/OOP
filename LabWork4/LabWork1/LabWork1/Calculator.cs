using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    class Calculator : ICalculate
    {
        /// <summary>
        /// Возвращает суммирование 2 чисел
        /// </summary>
        public long Sum(long number1, long number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Возвращает разность 2 чисел
        /// </summary>
        public long Subtraction(long number1, long number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Возвращает умножение 2 чисел
        /// </summary>
        public long Multiplication(long number1, long number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Возвращает деление 2 чисел
        /// </summary>
        public long Division(long number1, long number2)
        {
            return number1 / number2;
        }

        /// <summary>
        /// Возвращает остаток от деления
        /// </summary>
        public long RemainderOfDivision(long number1, long number2)
        {
            return number1 % number2;
        }

    }
}
