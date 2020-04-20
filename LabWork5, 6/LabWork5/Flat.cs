using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabWork5
{
    [Serializable]
    public class Flat
    {
        public List<Room> rooms = new List<Room>();


        public Address address = new Address();


        /// <summary>
        /// Площадь квартиры
        /// </summary>
        public float AreaFlat { get; set; }

        /// <summary>
        /// Количество комнат
        /// </summary>

        public int CountRooms { get; set; }




        /// <summary>
        /// Тип постройки
        /// </summary>

        public string TypeBuilding { get; set; }


        /// <summary>
        /// Этаж
        /// </summary>
        [RegularExpression(@"[0-9]{0,2}", ErrorMessage ="Не верно введены данные поля --этаж--")]
        public int Floor { get; set; }


        public int GetPrice()
        {
            return (this.CountRooms * (int)this.AreaFlat);
        }


    }
}
