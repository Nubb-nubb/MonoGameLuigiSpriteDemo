using System;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    internal class ExitGameCommand : ICommand
    {
        public void Execute(Game1 game)
        {
            game.Exit(); 
        }
    }
}
