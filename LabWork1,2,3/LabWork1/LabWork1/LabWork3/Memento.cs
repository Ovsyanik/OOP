using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public class Memento : IMemento
    {

        private State state;

        public Memento(State state)
        {
            this.state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public State GetState()
        {
            return this.state;
        }

        public void SetState(State state)
        {
            if (state != null)
            {
                this.state = state;
            }
        }
    }
}