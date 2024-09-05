using System;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    internal class PrintCommand : ICommand
    {
        private string _message;

        public PrintCommand(string message)
        {
            _message = message;
        }

        public void Execute(Game1 game)
        {
            System.Diagnostics.Debug.WriteLine(_message);
        }
    }
}
