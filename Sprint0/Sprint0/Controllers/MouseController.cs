using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System.Collections.Generic;


namespace Sprint0.Controllers
{
    internal class MouseController
    {
        private Dictionary<MouseButton, ICommand> _commands; 
        private MouseState _previousState;

        public MouseController() {
            _commands = new Dictionary<MouseButton, ICommand>();
            _previousState = Mouse.GetState();
        }

        public void RegisterAction(MouseButton button, ICommand command)
        {
            if (!_commands.ContainsKey(button))
            {
                _commands.Add(button, command);
            }
        }

        public void Update(Game1 game)
        {
            MouseState currentState = Mouse.GetState();

            // Left Mouse Click Detection
            if (currentState.LeftButton == ButtonState.Pressed && _previousState.LeftButton == ButtonState.Released)
            {
                Vector2 mousePosition = new Vector2(currentState.X, currentState.Y);
                HandleLeftClick(mousePosition, game);
            }

            // Right Mouse Click Detection (Exits the game)
            if (currentState.RightButton == ButtonState.Pressed && _previousState.RightButton == ButtonState.Released)
            {
                if (_commands.ContainsKey(MouseButton.Right))
                {
                    _commands[MouseButton.Right].Execute(game); 
                }
            }

            _previousState = currentState;  // Update the previous state
        }

        private void HandleLeftClick(Vector2 mousePosition, Game1 game)
        {
            int windowWidth = game.GraphicsDevice.Viewport.Width;
            int windowHeight = game.GraphicsDevice.Viewport.Height;

            // Divide window into quadrants
            bool isTop = mousePosition.Y < windowHeight / 2;
            bool isLeft = mousePosition.X < windowWidth / 2;

            // Top-left quadrant
            if (isTop && isLeft)
            {
                _commands[MouseButton.TopLeft]?.Execute(game);  // Trigger the command for top-left click
            }
            // Top-right quadrant
            else if (isTop && !isLeft)
            {
                _commands[MouseButton.TopRight]?.Execute(game);  // Trigger the command for top-right click
            }
            // Bottom-left quadrant
            else if (!isTop && isLeft)
            {
                _commands[MouseButton.BottomLeft]?.Execute(game);  // Trigger the command for bottom-left click
            }
            // Bottom-right quadrant
            else if (!isTop && !isLeft)
            {
                _commands[MouseButton.BottomRight]?.Execute(game);  // Trigger the command for bottom-right click
            }
        }
    }
    // Enum for mouse quadrants and buttons
    internal enum MouseButton
    {
        Left,
        Right,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
