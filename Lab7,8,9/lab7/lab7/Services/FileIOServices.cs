using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace lab7.Services
{
    public class FileIOServices
    {
        XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Task>));

        public ObservableCollection<Task> LoadTask()
        {
            var fileExists = File.Exists("Task.xml");
            if(!fileExists)
            {
                File.CreateText("Task.xml").Dispose();
                return new ObservableCollection<Task>();
            }
            else 
            {
                using (FileStream fs = new FileStream("Task.xml", FileMode.Open, FileAccess.Read))
                {
                    var tas = xml.Deserialize(fs);
                    ObservableCollection<Task> tasks = tas as ObservableCollection<Task>;
                    return tasks;
                }
            }
        }

        public void SaveTask(ObservableCollection<Task> taskList)
        {
            
            using (FileStream fs = new FileStream("Task.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                xml.Serialize(fs, taskList);
            }
        }
    }
}
