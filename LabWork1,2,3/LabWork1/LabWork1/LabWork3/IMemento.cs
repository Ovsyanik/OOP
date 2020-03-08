using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public interface IMemento
    {
        /// <summary>
        /// Возвращает состояние объекта
        /// </summary>
        State GetState();

        /// <summary>
        /// Сохраняем состояние объекта
        /// </summary>
        void SetState(State state);
    }
}
