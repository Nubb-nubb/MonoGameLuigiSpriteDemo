using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    internal class SwitchToStaticSpriteCommand : ICommand
    {
        private ISprite _staticSprite;

        public SwitchToStaticSpriteCommand(ISprite staticSprite)
        {
            _staticSprite = staticSprite;
        }

        public void Execute(Game1 game)
        {
            // Set the current sprite in the game to the static sprite
            game.SetCurrentSprite(_staticSprite);
        }
    }
}
