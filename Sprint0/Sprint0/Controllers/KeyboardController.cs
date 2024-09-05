using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Controllers
{
    internal class KeyboardController
    {
        private Dictionary<Keys, ICommand> commands;

        public KeyboardController() {
            commands = new Dictionary<Keys, ICommand>();
        }

        public void RegisterAction(Keys key, ICommand command)
        {
            if (!commands.ContainsKey(key))
            {
                commands.Add(key, command);
            }
        }
        public void Update(Game1 game)
        {
            KeyboardState state = Keyboard.GetState();

            foreach (var key in commands.Keys)
            {
                if (state.IsKeyDown(key))
                {
                    commands[key].Execute(game);
                }
            }
        }
    }
}
