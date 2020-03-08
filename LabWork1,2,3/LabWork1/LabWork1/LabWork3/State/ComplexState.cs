using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public class ComplexState : State
    {
        private readonly State state;

        public ComplexState(ICommand command, State state) : base(command)
        {
            this.state = state;
        }

        public override void Handle(string name)
        {
            base.Handle(name);
            this.context.Update(this.state);
            this.state.Handle(name);
        }
    }
}
