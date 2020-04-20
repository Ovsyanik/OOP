using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab7
{

    partial class ApplicationViewModel
    {
        private RelayCommand addTask { get; set; }
        private RelayCommand save { get; set; }
        private RelayCommand removeTask { get; set; }
        private RelayCommand sortByPrioriry { get; set; }
        private RelayCommand sortByCategory { get; set; }
        public UndoRedoClass UndoRedoClass = new UndoRedoClass();
        private RelayCommand search { get; set; }
        private Task task = new Task();

        private string searchString { get; set; }

        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
                OnPropertyChanged("SearchString");
            }
        }


        /// <summary>
        /// Добавление новых задач
        /// </summary>
        public RelayCommand AddTask => addTask = new RelayCommand(obj =>
        {
            Task task = new Task(){ Priority = Task.PriorityEnum.Низкий , Category = Task.CategoryEnum.Личное};
            Tasks.Insert(0, task);
            SelectedTask = task;
            UndoRedoClass.AddItem(addTask);
        });


        /// <summary>
        /// Сортировка по приоритету по возростанию
        /// </summary>
        public RelayCommand SortByPriorityHight => sortByPrioriry = new RelayCommand(obj =>
        {
            TasksSort = new ObservableCollection<Task>(Tasks.OrderBy(i => i.Priority).ThenBy(i=>i.Priority).ToList());
            AddItemInTasks(TasksSort);
            Tasks2.Clear();
            foreach (var item in Tasks)
            {
                Tasks2.Add(item);
            }
            UndoRedoClass.AddItem(sortByPrioriry);
        });


        public RelayCommand SortByСategoryHight => sortByCategory = new RelayCommand(obj =>
        {
            TasksSort = new ObservableCollection<Task>(Tasks.OrderBy(i => i.Category).ThenBy(i => i.Category).ToList());
            Tasks2.Clear();
            foreach (var item in Tasks)
            {
                Tasks2.Add(item);
            }
            AddItemInTasks(TasksSort);

            UndoRedoClass.AddItem(sortByCategory);
        });


        public RelayCommand SortByСategoryLow => sortByCategory = new RelayCommand(obj =>
        {
            TasksSort = new ObservableCollection<Task>(Tasks.OrderByDescending(i => i.Category).ThenByDescending(i => i.Category).ToList());
            Tasks2.Clear();
            foreach (var item in Tasks)
            {
                Tasks2.Add(item);
            }
            AddItemInTasks(TasksSort);
            UndoRedoClass.AddItem(sortByCategory);
        });


        /// <summary>
        /// Удаляет задачу
        /// </summary>
        public RelayCommand RemoveTask => removeTask = new RelayCommand(obj =>
        {
            Tasks2.Clear();
            foreach (var item in Tasks)
            {
                Tasks2.Add(item);
            }
            task = selectedTask;
            Tasks.Remove(selectedTask);
            UndoRedoClass.AddItem(removeTask);
        });
           

        /// <summary>
        /// Сортировка по приоритету по возростанию
        /// </summary>
        public RelayCommand SortByPriorityLow => sortByPrioriry = new RelayCommand(obj =>
        {
            TasksSort = new ObservableCollection<Task>(Tasks.OrderByDescending(i => i.Priority).ThenByDescending(i => i.Priority).ToList());
            Tasks2.Clear();
            foreach (var item in Tasks)
            {
                Tasks2.Add(item);
            }
            Tasks.Clear();
            AddItemInTasks(TasksSort);
            UndoRedoClass.AddItem(sortByPrioriry);
        });


        private void AddItemInTasks(ObservableCollection<Task> tasks)
        {
            Tasks.Clear();
            foreach (var item in tasks)
            {
                Tasks.Add(item);
            }
        }

        /// <summary>
        /// Сохранение задач
        /// </summary>
        public RelayCommand Save
        {
            get
            {
                return save ??
                    (save = new RelayCommand(obj =>
                    {
                        fileIOServices.SaveTask(Tasks);
                        Tasks2 = Tasks;
                    }));
            }
        }


        /// <summary>
        /// Отменяет последнее действие 
        /// </summary>
        public RelayCommand Undo => new RelayCommand(obj =>
        {
            try
            {
                if (UndoRedoClass.RedoStack != null)
                    UndoRedoClass.Undo();
                if (UndoRedoClass.RedoStack.First() == this.addTask)
                {
                    Tasks2.Clear();
                    foreach (var item in Tasks)
                    {
                        Tasks2.Add(item);
                    }
                    Tasks.Remove(Tasks.First());
                }
                if(UndoRedoClass.RedoStack.First() == this.search)
                {
                    AddItemInTasks(Tasks2);
                }
                if (UndoRedoClass.RedoStack.First() == this.removeTask)
                {
                    AddItemInTasks(Tasks2);
                }
                if (UndoRedoClass.RedoStack.First() == this.sortByPrioriry)
                {
                    AddItemInTasks(Tasks2);
                }
                if (UndoRedoClass.RedoStack.First() == this.sortByCategory)
                {
                    AddItemInTasks(Tasks2);
                }
            }
            catch { }                    
        });


        /// <summary>
        /// Повторяет отмененное действие
        /// </summary>
        public RelayCommand Redo => new RelayCommand(obj =>
        {
            try
            {
                if (UndoRedoClass.UndoStack != null)
                    UndoRedoClass.Redo();
                if (UndoRedoClass.UndoStack.First() == this.addTask)
                {                
                    AddItemInTasks(Tasks2);
                }
                if (UndoRedoClass.UndoStack.First() == this.removeTask)
                {
                    Tasks2.Clear();
                    foreach (var item in Tasks)
                    {
                        Tasks2.Add(item);
                    }
                    Tasks.Remove(task);
                    UndoRedoClass.AddItem(removeTask);
                }
                if (UndoRedoClass.UndoStack.First() == this.sortByPrioriry)
                {
                    AddItemInTasks(Tasks2);
                }
            }
            catch { }
        });

        /// <summary>
        /// поиск
        /// </summary>
        public RelayCommand Search => search = new RelayCommand(obj =>
        {
            try
            {
                var sortByCategory = from item in Tasks
                                     where SearchString != null
                                     where item.Title.Contains(SearchString)
                                     select item;
                
                ObservableCollection<Task> searchTask = new ObservableCollection<Task>(sortByCategory);
                Tasks2.Clear();
                foreach (var item in Tasks)
                {
                    Tasks2.Add(item);
                }
                Tasks.Clear();
                foreach (var item in searchTask)
                {
                    Tasks.Add(item);
                }
                UndoRedoClass.AddItem(search);
            }
            catch { }
        });

        
    }
}
