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

namespace CustomEvent.UserAccountEvents
{
    public class CreateAccountArguments : EventArgs
    {
        public bool isUserSignedIn { get; set; }

        public string email { get; set; }

        public string password { get; set;}
    }

    public class LogInArguments: EventArgs
    {
        public bool isUserSignedIn { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}