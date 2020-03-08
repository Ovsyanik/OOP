﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
       // private delegate void Comparator();

        List<int> vs = new List<int>();
        int SizeCollection { get; set; }
        
        Random rand = new Random();

        SortCollection.Sort sort = new SortCollection.Sort();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SizeCollection = Convert.ToInt32(textBox1.Text);
            }
            catch
            {

            }
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            vs.Clear();

            if (SizeCollection != 0)
            {
                for (int i = 0; i < SizeCollection; i++)
                {
                    vs.Add(rand.Next(-50, 50));
                }
            }
            else
            {
                MessageBox.Show("Размер коллекции не может быть равен нулю!!!");
            }

            foreach (var item in vs)
            {
                textBox3.Text += " число = "
                    +  item.ToString() + Environment.NewLine;
            } 
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int minElInVs = vs.Min();
            
            textBox2.Text = "минимальное число коллекции = "
                + minElInVs.ToString() + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sort.SortCollection((Button)sender, vs, textBox2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int maxElInVs = vs.Max();

            textBox2.Text = "максимальное число коллекции = "
                + maxElInVs.ToString() + Environment.NewLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double aveElInVs = vs.Average();

            textBox2.Text = "среднее значение коллекции = "
                + aveElInVs.ToString() + Environment.NewLine;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sort.SortCollection((Button)sender, vs, textBox2);
        }
    }
}