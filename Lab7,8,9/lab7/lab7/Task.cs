using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace lab7
{ 

    public class Task : INotifyPropertyChanged
    {
        public enum PriorityEnum
        {
            Высокий = 1,
            Средний = 2,
            Низкий = 3
        }

        public enum CategoryEnum
        {
            Личное = 1,
            Работа,
            Учёба
        }

        private bool status;

        private string title;

        private string description;

        private DateTime timeOfStart;

        private DateTime timeOfEnd;

        private PriorityEnum priority;

        private CategoryEnum category;



        /// <summary>
        /// Выполненность задачи
        /// </summary>
        public bool Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }


        /// <summary>
        /// Краткое название
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        
        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }


        /// <summary>
        /// Время начала задачи
        /// </summary>
        public DateTime TimeOfStart
        {
            get => timeOfStart;
            set
            {
                if (value < DateTime.Today)
                    MessageBox.Show("Дата начала не м.б меньше сегодняшнего дня");
                else
                    timeOfStart = value;
                    OnPropertyChanged("TimeOfStart");
            }
        }


        /// <summary>
        /// Время конца задачи
        /// </summary>
        public DateTime TimeOfEnd
        {
            get => timeOfEnd;
            set
            {
                if (value < this.timeOfStart)
                    MessageBox.Show("Дата окончания не м.б меньше даты начала");
                else
                    timeOfEnd = value;
                    OnPropertyChanged("TimeOfEnd");
            }
        }



        /// <summary>
        /// Периодичность
        /// </summary>
        public PriorityEnum Priority
        {
            get => priority;
            set
            {
                priority = value;
                OnPropertyChanged("Priority");
            }
        }


        public CategoryEnum Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
