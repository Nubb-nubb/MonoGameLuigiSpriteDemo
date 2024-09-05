using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class StaticSprite : ISprite
    {
        private Texture2D _textureAtlas;
        private Rectangle _sourceRectangle;
        private Vector2 _position;
        private Rectangle _destinationRectangle;

        public StaticSprite(Texture2D textureAtlas, Rectangle sourceRectangle, Vector2 position)
        {
            _textureAtlas = textureAtlas;
            _sourceRectangle = sourceRectangle;  
            _position = position;
            _destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textureAtlas, _destinationRectangle, _sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime) { }
    }
}
