using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class AnimatedSprite : ISprite
    {
        private Texture2D _textureAtlas;
        private Rectangle[] _frames;  // Array of frames 
        private int _currentFrame;
        private double _frameTime;    // Time to display each frame (in seconds)
        private double _timeElapsed;  // Time elapsed since the last frame change
        private Vector2 _position;
        private Rectangle _destinationRectangle;

        public AnimatedSprite(Texture2D textureAtlas, Rectangle[] frames, Vector2 position, double frameTime)
        {
            _textureAtlas = textureAtlas;
            _frames = frames;
            _position = position;
            _frameTime = frameTime; 
            _currentFrame = 0;
            _timeElapsed = 0;

            _destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 32, 32);
        }

        public void Update(GameTime gameTime)
        {
            _timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

            if (_timeElapsed >= _frameTime)
            {
                _currentFrame = (_currentFrame + 1) % _frames.Length;  
                _timeElapsed -= _frameTime;
            }
            _destinationRectangle.X = (int)_position.X;
            _destinationRectangle.Y = (int)_position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textureAtlas, _destinationRectangle, _frames[_currentFrame], Color.White);
        }
    }
}
