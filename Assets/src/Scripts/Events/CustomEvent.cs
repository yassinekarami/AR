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

namespace CustomEvent.AccountArgument
{
    public class AccountEvent : EventArgs
    {
        public bool isUserSignedIn { get; set; }

        public string email { get; set; }

        public string password { get; set;}
    }
}
