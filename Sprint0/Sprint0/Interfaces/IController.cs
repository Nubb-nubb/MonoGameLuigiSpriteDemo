using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IController
    {
        void RegisterAction(Keys key, ICommand command);
        void Update(Game1 game);
    }
}
