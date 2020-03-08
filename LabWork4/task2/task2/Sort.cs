using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SortCollection
{
    public delegate void Comparator(List<int> vs, TextBox textBox);

    class Sort
    {
        Comparator comparator;
        public void SortCollection(Button button, List<int> vs, TextBox textBox)
        {
            if(button.Text == "Сортировать по возростанию")
                comparator = SortAscending;
            else
                comparator = SortDesscending;
            textBox.Clear();
            comparator(vs, textBox);

        }

        /// <summary>
        /// Сортирует по возрастанию и выводит в TextBox отсортированную коллекцию
        /// </summary>
        private void SortAscending(List<int> vs, TextBox textBox)
        {
            var sortedList = vs.OrderBy(i => i);

            foreach (var item in sortedList)
            {
                textBox.Text += " число = "
                    + item.ToString() + Environment.NewLine;
            }
        }

        /// <summary>
        /// Сортирует по убыванию и выводит в TextBox отсортированную коллекцию
        /// </summary>
        private void SortDesscending(List<int> vs, TextBox textBox)
        {
            var sortedList = vs.OrderByDescending(i => i);

            foreach (var item in sortedList)
            {
                textBox.Text += " число = "
                    + item.ToString() + Environment.NewLine;
            }
        }
    }
}
