using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;



namespace LabWork5
{
    public partial class SearchForm : Form
    {
        List<Flat> flats1 = new List<Flat>();

        public SearchForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SerializationList.DeserializeList();
            try
            {
                //Полное соответствие
                if (radioButton1.Checked)
                {
                    //количество комнат
                    if (radioButton3.Checked)
                    {
                        try
                        {
                            var k = SerializationList.GetDeserializeFlats().Where(i => i.CountRooms == int.Parse(textBox1.Text)).ToList();

                            List<Flat> flats = k as List<Flat>;
                            foreach (var item in flats)
                            {
                                flats1.Add(item);
                            }
                            OutputList(flats);
                            if (k.Count() == 0)
                                MessageBox.Show("Совпадений не найдено");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    //район
                    if (radioButton4.Checked)
                    {
                        try
                        {
                            var k = SerializationList.GetDeserializeFlats().Where(i => i.address.District == textBox1.Text).ToList();

                            List<Flat> flats = k as List<Flat>;
                            foreach (var item in flats)
                            {
                                flats1.Add(item);
                            }
                            OutputList(flats);
                            if (k.Count() == 0)
                                MessageBox.Show("Совпадений не найдено");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    //город
                    if (radioButton5.Checked)
                    {
                        try
                        {
                            var k = SerializationList.GetDeserializeFlats().Where(i => i.address.Sity == textBox1.Text).ToList();

                            List<Flat> flats = k as List<Flat>;
                            foreach (var item in flats)
                            {
                                flats1.Add(item);
                            }
                            
                            OutputList(flats);
                            if (k.Count() == 0)
                                MessageBox.Show("Совпадений не найдено");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }


                //Частичное соответствие
                if (radioButton2.Checked)
                {
                    //страна
                    if (radioButton4.Checked)
                    {
                        var k = SerializationList.GetDeserializeFlats().ToList();

                        List<Flat> flats = k as List<Flat>;

                        Regex regex = new Regex(textBox1.Text + @"(\w*)");
                        foreach (Flat item in flats)
                        {
                            MatchCollection matches = regex.Matches(item.address.State);
                            if (matches.Count > 0)
                            {
                                flats1.Add(item);
                            }
                            else
                            {
                                Console.WriteLine("Совпадений не найдено");
                            }
                        }
                        OutputList(flats1);

                    }

                    //город
                    if (radioButton5.Checked)
                    {
                        var k = SerializationList.GetDeserializeFlats().ToList();

                        List<Flat> flats = k as List<Flat>;

                        Regex regex = new Regex(textBox1.Text + @"(\w*)");
                        foreach (Flat item in flats)
                        {
                            MatchCollection matches = regex.Matches(item.address.Sity);
                            if (matches.Count > 0)
                            {
                                flats1.Add(item);
                            }
                            else
                            {
                                Console.WriteLine("Совпадений не найдено");
                            }
                        }
                        OutputList(flats1);
                    }
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }

        }
            

        /// <summary>
        /// Вывод коллекции
        /// </summary>
        /// <param name="outList"></param>        
        public void OutputList(List<Flat> outList)
        {
            textBox3.Clear();
            try
            {
                foreach (var item in outList)
                {
                    textBox3.Text += "Страна - " + Convert.ToString(item.address.State) + "\t\t\t\t\t";
                    textBox3.Text += "Город - " + Convert.ToString(item.address.Sity) + "\t\t\t\t\t";
                    textBox3.Text += "Район - " + Convert.ToString(item.address.District) + Environment.NewLine;
                    textBox3.Text += "Улица - " + Convert.ToString(item.address.Street) + "\t\t\t\t\t";
                    textBox3.Text += "Номер дома - " + Convert.ToString(item.address.Home) + "\t\t\t\t\t";
                    textBox3.Text += "Подъезд - " + Convert.ToString(item.address.Housing) + Environment.NewLine;
                    textBox3.Text += "Номер квартиры - " + Convert.ToString(item.address.NumberFlat) + "\t\t\t\t\t";
                    textBox3.Text += "Площадь квартиры - " + Convert.ToString(item.AreaFlat) + "\t\t\t\t\t";
                    textBox3.Text += "Тип постройки - " + Convert.ToString(item.TypeBuilding) + Environment.NewLine;
                    textBox3.Text += "Этаж - " + Convert.ToString(item.Floor) + Environment.NewLine;
                    textBox3.Text += "Количество комнат квартиры - " + Convert.ToString(item.CountRooms) + Environment.NewLine;
                    textBox3.Text += "------------------------------------------------------------------------------------" + Environment.NewLine;
                    foreach (var item2 in item.rooms)
                    {
                        textBox3.Text += "Площадь комнаты - " + Convert.ToString(item2.AreaRoom) + Environment.NewLine;
                        textBox3.Text += "Количество окон - " + Convert.ToString(item2.CountWindow) + Environment.NewLine;
                    }
                    textBox3.Text += "------------------------------------------------------------------------------------" + Environment.NewLine;
                    textBox3.Text += "Цена - " + Convert.ToString(item.GetPrice()) + "$" + Environment.NewLine;
                    textBox3.Text += "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton3.Visible = false;
            }
            else
            {
                radioButton3.Visible = true;
            }
        }

    }
}
