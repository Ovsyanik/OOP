using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    class NPCSingleton
    {
        private static NPCSingleton instance;
        public string _name;

        private NPCSingleton() { }

        protected NPCSingleton(string name)
        {
            this._name = name;
        }
        public static NPCSingleton GetInstance(string name)
        {
            if (instance == null)
            {
                instance = new NPCSingleton(name);
            }
            return instance;
        }

        public override string ToString()
        {
            return $"My names {_name.ToString()}";
        }

    }
}
