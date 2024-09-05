using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MovingStaticSprite : ISprite
    {
        private Texture2D _texture;
        private Rectangle _sourceRectangle;
        private Vector2 _position;
        private float _speed = 200f;  
        private bool _movingUp = true;  // Direction flag for movement
        private int _windowHeight;
        private Rectangle _destinationRectangle;

        public MovingStaticSprite(Texture2D texture, Rectangle sourceRectangle, Vector2 startPosition, int windowHeight)
        {
            _texture = texture;
            _sourceRectangle = sourceRectangle;
            _position = startPosition;
            _windowHeight = windowHeight;  // Store the window height for boundary detection

            _destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 32, 32);
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_movingUp)
            {
                _position.Y -= _speed * deltaTime;
                if (_position.Y <= 0)  // Top of the window
                {
                    _movingUp = false;  // Start moving down
                }
            }
            else
            {
                _position.Y += _speed * deltaTime;
                if (_position.Y + _sourceRectangle.Height >= _windowHeight)  // Bottom of the window
                {
                    _movingUp = true;  // Start moving up
                }
            }

            _destinationRectangle.X = (int)_position.X;
            _destinationRectangle.Y = (int)_position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _destinationRectangle, _sourceRectangle, Color.White);
        }
    }
}
