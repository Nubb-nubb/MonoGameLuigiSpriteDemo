using Sprint0.Interfaces;
using System.Diagnostics;

namespace Sprint0.Commands
{
    internal class SwitchToAnimatedSpriteCommand : ICommand
    {
        private ISprite _animatedSprite;

        public SwitchToAnimatedSpriteCommand(ISprite animatedSprite)
        {
            _animatedSprite = animatedSprite;
        }

        public void Execute(Game1 game)
        {
            if (_animatedSprite != null)
            {
                Debug.WriteLine("Switching to animated sprite.");
                game.SetCurrentSprite(_animatedSprite);
            }
            else
            {
                Debug.WriteLine("Error: animated sprite is null.");
            }
        }
    }
}
