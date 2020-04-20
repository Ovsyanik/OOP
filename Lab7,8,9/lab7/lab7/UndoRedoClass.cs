using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab7
{
    class UndoRedoClass
    {
        public Stack<RelayCommand> UndoStack;
        public Stack<RelayCommand> RedoStack;
        RelayCommand command { get; set; }

        public UndoRedoClass()
        {
            UndoStack = new Stack<RelayCommand>();
            RedoStack = new Stack<RelayCommand>();
        }


        public void AddItem(RelayCommand command)
        {
            UndoStack.Push(command);
        }


        public RelayCommand Undo()
        {
            try
            {
                command = UndoStack.Pop();
                RedoStack.Push(command);
                return RedoStack.First();
            }
            catch
            {
                RedoStack.Clear();
                return null;
            }
        }


        public RelayCommand Redo()
        {
            //try
            //{
                command = RedoStack.Pop();
                UndoStack.Push(command);
                return UndoStack.First();
            //}
            //catch
            //{
                //UndoStack.Clear();
                //return null;
            //}
        }


    }
}
