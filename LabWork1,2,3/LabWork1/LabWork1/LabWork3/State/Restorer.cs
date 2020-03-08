using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public class Restorer
    {
        private Stack<IMemento> mementos = new Stack<IMemento>();
        private readonly Context context;

        public Restorer(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Сохраняем состояние
        /// </summary>
        public void BackUp()
        {
            this.mementos.Push(this.context.GetMemento());
        }

        /// <summary>
        /// Возвращаем состояние
        /// </summary>
        public void Undo()
        {
            if (!this.mementos.Count.Equals(0))
            {
                this.context.Update(this.mementos.Pop().GetState());
            }
        }
    }

}
