using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MovingAnimatedSprite : ISprite
    {
        private Texture2D _texture;
        private Rectangle[] _rightFrames;  
        private Rectangle[] _leftFrames;  
        private int _currentFrame;
        private double _frameTime;
        private double _timeElapsed;
        private Vector2 _position;
        private float _speed = 200f;  
        private bool _movingRight = true;  // Direction flag
        private int _windowWidth;
        private Rectangle _destinationRectangle;

        public MovingAnimatedSprite(Texture2D texture, Rectangle[] rightFrames, Rectangle[] leftFrames, Vector2 startPosition, double frameTime, int windowWidth)
        {
            _texture = texture;
            _rightFrames = rightFrames;
            _leftFrames = leftFrames;
            _position = startPosition;
            _frameTime = frameTime;
            _currentFrame = 0;
            _timeElapsed = 0;
            _windowWidth = windowWidth;
            _destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 32, 32);
        }

        public void Update(GameTime gameTime)
        {
            _timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

            // Update frame for animation
            if (_timeElapsed >= _frameTime)
            {
                _currentFrame = (_currentFrame + 1) % (_movingRight ? _rightFrames.Length : _leftFrames.Length);
                _timeElapsed -= _frameTime;
            }

            // Move the sprite left or right based on the direction
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_movingRight)
            {
                _position.X += _speed * deltaTime;
                // Check if the sprite hits the right boundary
                if (_position.X + _rightFrames[_currentFrame].Width >= _windowWidth)
                {
                    _movingRight = false;  // Switch direction to left
                }
            }
            else
            {
                _position.X -= _speed * deltaTime;
                // Check if the sprite hits the left boundary
                if (_position.X <= 0)
                {
                    _movingRight = true;  // Switch direction to right
                }
            }

            _destinationRectangle.X = (int)_position.X;
            _destinationRectangle.Y = (int)_position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the correct frame depending on the direction
            spriteBatch.Draw(
                _texture,
                _destinationRectangle,
                _movingRight ? _rightFrames[_currentFrame] : _leftFrames[_currentFrame],
                Color.White
            );
        }
    }
}
