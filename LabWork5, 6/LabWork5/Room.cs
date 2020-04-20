using System;

namespace LabWork5
{
    [Serializable]
    public class Room
    {
        private float area;

        /// <summary>
        /// Площадь комнаты
        /// </summary>
       
        public float AreaRoom
        {
            get { return area; }
            set
            {
                if (area < 0)
                    throw new LessThanZeroException("Площадь не может быть меньше нуля");
                else
                    area = value;
            }
        }

        /// <summary>
        /// Количество комнат
        /// </summary>
        public int CountWindow { get; set; }


    }
}
