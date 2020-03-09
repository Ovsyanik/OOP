using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWork1
{
    public partial class Form1 : Form
    {
        Calculator calculator = new Calculator();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text +=  9;
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            textBox1.Text += '+';
        }

        private void buttonSubtraction_Click(object sender, EventArgs e)
        {
            textBox1.Text += '-';
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            textBox1.Text += '/';
        }


        private void buttonMultiplication_Click(object sender, EventArgs e)
        {
            textBox1.Text += '*';
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += '%';
        }


        //=
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                char[] signs = { '+', '-', '*', '/', '%' };
                string[] numbers = textBox1.Text.Split(signs);
                long number1 = 0;
                long number2 = 0;
                try
                {
                    number1 = long.Parse(numbers[0]);
                    number2 = long.Parse(numbers[1]);
                }
                catch (IndexOutOfRangeException m)
                {
                    MessageBox.Show(m.Message);
                }
                char sign = '+';
                foreach (char item in signs)
                {
                    if (textBox1.Text.IndexOf(item) >= 0)
                    {
                        sign = item;
                        break;
                    }
                }

                switch (sign)
                {
                    case '+':
                        textBox1.Text = calculator.Sum(number1, number2).ToString();
                        break;
                    case '-':
                        textBox1.Text = calculator.Subtraction(number1, number2).ToString();
                        break;
                    case '*':
                        textBox1.Text = calculator.Multiplication(number1, number2).ToString();
                        break;
                    case '/':
                        try
                        {
                            float f = calculator.Division(number1, number2);
                            textBox1.Text = f.ToString();
                        }
                        catch (DivideByZeroException f)
                        {
                            MessageBox.Show(f.Message);
                        }
                        break;
                    case '%':
                        textBox1.Text = calculator.RemainderOfDivision(number1, number2).ToString();
                        break;
                }
            }
            catch(Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }


        //Удаление символа
        private void button18_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            int length = str.Length;
            textBox1.Clear();
            for(int i = 0; i < length - 1; i++)
            {
                textBox1.Text += str[i];
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

     
    }

   
}
