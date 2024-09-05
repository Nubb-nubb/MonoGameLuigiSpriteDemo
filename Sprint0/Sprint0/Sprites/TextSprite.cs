using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    internal class TextSprite
    {
        private SpriteFont _font;
        private string[] _lines;
        private Vector2 _position;
        private Color _color;

        public TextSprite(SpriteFont font, Vector2 position, Color color)
        {
            _font = font;
            _position = position;
            _color = color;
            _lines = new string[]
            {
                "Credits",
                "Program Made By: Steven Sun",
                "Sprites from: https://www.mariouniverse.com/wp-content/img/sprites/nes/smb/luigi.png"
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 linePosition = _position;

            foreach (var line in _lines)
            {
                spriteBatch.DrawString(_font, line, linePosition, _color);
                linePosition.Y += _font.LineSpacing;  
            }
        }
    }
}
