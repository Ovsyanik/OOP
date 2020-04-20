using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;

namespace lab7
{
    partial class ApplicationViewModel : INotifyPropertyChanged
    {
        private Task selectedTask;

        private Services.FileIOServices fileIOServices= new Services.FileIOServices();

        public ObservableCollection<Task> Tasks { get; set; }

        public ObservableCollection<Task> TasksSort { get; set; }

        public ObservableCollection<Task> Tasks2 { get; set; } = new ObservableCollection<Task>();


        public Task SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }

        public ApplicationViewModel()
        {
            Tasks = new ObservableCollection<Task>();
            try
            {
                Tasks = fileIOServices.LoadTask();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
