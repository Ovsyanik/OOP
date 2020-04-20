using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using System.Linq;
using System.IO;
using System.Xml.Serialization;


namespace LabWork5
{
    partial class Form1 : Form
    {  
        List<Flat> flats;
        List<Flat> flats2;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        ToolStripLabel lastAction;

        public Form1()
        {
            InitializeComponent();

            flats = new List<Flat>();

            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            lastAction = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add(lastAction);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
            flat.rooms.Add(new Room());
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label23.Text = String.Format($"Текущее значение: {trackBar1.Value}");
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label24.Text = String.Format($"Текущее значение: {trackBar2.Value}");
        }


        // сериализация
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SerializationList.SerializeList(flats));
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(SerializationList.DeserializeList());
        }

        Flat flat = new Flat();

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                flat.address.State = textBox1.Text;
                flat.address.Sity = textBox2.Text;
                flat.address.District = textBox3.Text;
                flat.address.Street = textBox4.Text;


                try
                {
                    if (!String.IsNullOrEmpty(textBox5.Text))
                        flat.address.Home = int.Parse(textBox5.Text);
                }
                catch { }

                try
                {
                    if (!String.IsNullOrEmpty(textBox6.Text))
                        flat.address.Housing = int.Parse(textBox6.Text);
                }
                catch { }

                try
                {
                    if (!String.IsNullOrEmpty(textBox8.Text))
                        flat.Floor = int.Parse(textBox8.Text);
                }
                catch { }

                if (!String.IsNullOrEmpty(textBox7.Text))
                    flat.address.NumberFlat = int.Parse(textBox7.Text);

                flat.AreaFlat = trackBar1.Value;


                if (radioButton1.Checked)
                    flat.TypeBuilding = radioButton1.Text;
                if (radioButton2.Checked)
                    flat.TypeBuilding = radioButton2.Text;

                try
                {
                    if (ValidationFlat(flat) && ValidationAddress(flat.address))
                    {
                        flats.Add(new Flat());
                        flats[flats.Count - 1].rooms.Add(new Room());
                        flats[flats.Count - 1].address.State = flat.address.State;
                        flats[flats.Count - 1].address.Sity = flat.address.Sity;
                        flats[flats.Count - 1].address.District = flat.address.District;
                        flats[flats.Count - 1].address.Street = flat.address.Street;
                        flats[flats.Count - 1].address.Home = flat.address.Home;
                        flats[flats.Count - 1].address.Housing = flat.address.Housing;
                        flats[flats.Count - 1].Floor = flat.Floor;
                        flats[flats.Count - 1].address.NumberFlat = flat.address.NumberFlat;
                        flats[flats.Count - 1].AreaFlat = flat.AreaFlat;
                        flats[flats.Count - 1].TypeBuilding = flat.TypeBuilding;
                        flats[flats.Count - 1].CountRooms = flat.CountRooms;
                        flats[flats.Count - 1].rooms = flat.rooms;
                        MessageBox.Show("Объект успешно добавлен:)");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
                OutputList(flats);
        }


        //добавление комнаты
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                flat.CountRooms = Convert.ToInt32(comboBox2.SelectedItem);


                flat.rooms[flat.rooms.Count - 1].AreaRoom = trackBar2.Value;
                if (!String.IsNullOrEmpty(comboBox1.Text))
                    flat.rooms[flat.rooms.Count - 1].CountWindow = Convert.ToInt32(comboBox1.SelectedItem);
                if (flat.rooms.Count - 1 < flat.CountRooms)
                {
                    flat.rooms.Add(new Room());
                    MessageBox.Show("Вы добавили комнату");
                }
                else
                    MessageBox.Show("Вы уже заполнили все комнаты" + flat.rooms.Count.ToString() );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        /// <summary>
        /// Валидация квартиры
        /// </summary>
        /// <param name="flatsValidate"></param>
        /// <returns></returns>
        private static bool ValidationFlat(Flat flatsValidate)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(flatsValidate);
            if (!Validator.TryValidateObject(flatsValidate, context, results, true))
            {
                StringBuilder builder = new StringBuilder("Ошибки: \n");
                foreach (var error in results)
                {
                    builder.Append(error + "\n");
                }
                MessageBox.Show(builder.ToString());
                return false;
            }
            else return true;
        }


        /// <summary>
        /// Валидация адреса
        /// </summary>
        /// <param name="AddressValidate"></param>
        /// <returns></returns>
        private static bool ValidationAddress(Address AddressValidate)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(AddressValidate);
            if (!Validator.TryValidateObject(AddressValidate, context, results, true))
            {
                StringBuilder builder = new StringBuilder("Ошибки: \n");
                foreach (var error in results)
                {
                    builder.Append(error + "\n");
                }
                MessageBox.Show(builder.ToString());
                return false;
            }
            else return true;
        }


        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Version 1.0 \n Овсяник Роман Андреевич");
        }

        private void textBox7_TextChanged(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }



        /// <summary>
        /// Cортировка по количеству комнат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortByCountRooms(object sender, EventArgs e)
        {
            var SortCountRoomsList = flats.OrderBy(i => i.CountRooms).ToList();
            flats2 = SortCountRoomsList as List<Flat>;
            OutputList(flats2);
        }


        /// <summary>
        /// Сортировка по площади
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortByArea(object sender, EventArgs e)
        {
            var SortAreaList = flats.OrderBy(i=>i.AreaFlat).ToList();
            flats2 = SortAreaList as List<Flat>;
            OutputList(flats2);
        }


        /// <summary>
        /// Сортировка по цене
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortByPrice(object sender, EventArgs e)
        {
            var SortPriceList = flats.OrderBy(i => i.GetPrice()).ToList();
            flats2 = SortPriceList as List<Flat>;
            OutputList(flats2);
        }


        /// <summary>
        /// Вывод Листа
        /// </summary>
        /// <param name="outList"></param>
        public void OutputList(List<Flat> outList)
        {
            textBox9.Clear();
            try
            {
                foreach (var item in outList)
                {
                    textBox9.Text += "Страна - " + Convert.ToString(item.address.State) + "\t\t\t\t\t";
                    textBox9.Text += "Город - " + Convert.ToString(item.address.Sity) + "\t\t\t\t\t";
                    textBox9.Text += "Район - " + Convert.ToString(item.address.District) + Environment.NewLine;
                    textBox9.Text += "Улица - " + Convert.ToString(item.address.Street) + "\t\t\t\t\t";
                    textBox9.Text += "Номер дома - " + Convert.ToString(item.address.Home) + "\t\t\t\t\t";
                    textBox9.Text += "Подъезд - " + Convert.ToString(item.address.Housing) + Environment.NewLine;
                    textBox9.Text += "Номер квартиры - " + Convert.ToString(item.address.NumberFlat) + "\t\t\t\t\t";
                    textBox9.Text += "Площадь квартиры - " + Convert.ToString(item.AreaFlat) + "\t\t\t\t\t";
                    textBox9.Text += "Тип постройки - " + Convert.ToString(item.TypeBuilding) + Environment.NewLine;
                    textBox9.Text += "Этаж - " + Convert.ToString(item.Floor) + Environment.NewLine;
                    textBox9.Text += "Количество комнат квартиры - " + Convert.ToString(item.CountRooms) + Environment.NewLine;
                    textBox9.Text += "------------------------------------------------------------------------------------" + Environment.NewLine;
                    foreach (var item2 in item.rooms)
                    {
                        textBox9.Text += "Площадь комнаты - " + Convert.ToString(item2.AreaRoom) + Environment.NewLine;
                        textBox9.Text += "Количество окон - " + Convert.ToString(item2.CountWindow) + Environment.NewLine;
                    }
                    textBox9.Text += "------------------------------------------------------------------------------------" + Environment.NewLine;
                    textBox9.Text += "Цена - " + Convert.ToString(item.GetPrice()) + "$" + Environment.NewLine;
                    textBox9.Text += "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + Environment.NewLine;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            FileStream fs = new FileStream("Flat.xml", FileMode.Open);
            if (fs.Length != 0)
                searchForm.Show();
            else
                MessageBox.Show("Сериализуйте объект");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Flat>));
            try
            {
                using (FileStream fs = new FileStream("Save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    serializer.Serialize(fs, flats2);
                }
                MessageBox.Show("Объект сохранён");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Flat>));
            try
            {
                using (FileStream fs = new FileStream("Save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    serializer.Serialize(fs, flats2);
                }
                MessageBox.Show("Объект сохранён");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox5_TextChanged(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox8_TextChanged(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}

