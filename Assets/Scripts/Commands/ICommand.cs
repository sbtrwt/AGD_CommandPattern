using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Commands
{
    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }
}
