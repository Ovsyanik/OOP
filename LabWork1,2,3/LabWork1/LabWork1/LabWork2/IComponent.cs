using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public interface IComponent
    {
        string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        void Draw();

        /// <summary>
        /// Находит героя по имени. Возвращает героя.
        /// </summary>
        IComponent Find(string title);
    }
}
