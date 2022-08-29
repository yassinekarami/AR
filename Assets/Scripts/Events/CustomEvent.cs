using System;
using Utils;

namespace CustomEvent.IsOverEventArgument
{
    public class IsOverEventArgument : EventArgs
    {
        public bool isGameOver { get; set; }
    }
}

namespace CustomEvent.SelectedChoixEventArgument
{
    public class SelectedChoixEventArgument : EventArgs
    {
        public Choix choix { get; set; }
    }
}
