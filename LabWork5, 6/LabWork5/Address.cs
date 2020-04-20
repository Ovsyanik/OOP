using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LabWork5
{
    [Serializable]
    public class Address
    {
        private int numberFlat;


        /// <summary>
        /// Гусударство
        /// </summary>
        [RegularExpression(@"[a-zа-яA-ZА-Я]{0,15}", ErrorMessage = "Не верно введены данные поля --страна--")]
        public string State { get; set; }


        /// <summary>
        /// Город
        /// </summary>
        [RegularExpression(@"[a-zа-яA-ZА-Я]{0,15}", ErrorMessage = "Не верно введены данные поля --город--")]
        public string Sity { get; set; }


        /// <summary>
        /// Район 
        /// </summary>
        [RegularExpression(@"[a-zа-яA-ZА-Я]{0,15}", ErrorMessage = "Не верно введены данные поля --район--")]
        public string District { get; set; }


        /// <summary>
        /// Улица
        /// </summary>
        [RegularExpression(@"[a-zа-яA-ZА-Я]{0,15}", ErrorMessage = "Не верно введены данные поля --улица--")]
        public string Street { get; set; }


        /// <summary>
        /// Дом
        /// </summary>
        [RegularExpression(@"\d{0,3}", ErrorMessage = "Не верно введены данные поля --дом--")]
        public int Home { get; set; }


        /// <summary>
        /// Корпус
        /// </summary>
        [RegularExpression(@"\d{0,1}", ErrorMessage = "Не верно введены данные поля --подьезд--")]
        public int Housing { get; set; }


        /// <summary>
        /// Номер квартиры
        /// </summary>
        [RegularExpression(@"\d{0,3}", ErrorMessage = "Не верно введены данные поля --номер квартиры--")]
        public int NumberFlat
        {
            get => numberFlat;
            set
            {
                if (value < 0)
                    throw new LessThanZeroException("Номер квартиры не может быть меньше нуля");
                else
                    numberFlat = value;
            }
        }
    }
}
