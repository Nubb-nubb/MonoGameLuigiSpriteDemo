using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System.Diagnostics;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyboardController _keyboardController;
        private MouseController _mouseController;
        private StaticSprite _staticSprite;
        private AnimatedSprite _animatedSprite;
        private MovingStaticSprite _movingStaticSprite;
        private MovingAnimatedSprite _movingAnimatedSprite;
        private ISprite _currentSprite;
        private TextSprite _creditsText;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        

        public void SetCurrentSprite(ISprite sprite)
        {
            //logs current sprite being set to the debug console
            Debug.WriteLine($"Current sprite is now: {sprite.GetType().Name}");

            _currentSprite = sprite;
        }


        protected override void Initialize()
        {
            _keyboardController = new KeyboardController();
            _mouseController = new MouseController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D luigiTextureAtlas = Content.Load<Texture2D>("luigi_texture_atlas");

            SpriteFont font = Content.Load<SpriteFont>("defaultFont");
            _creditsText = new TextSprite(font, new Vector2(10, 10), Color.White);

            Rectangle staticSpriteRect = new Rectangle(91, 0, 16, 16);
            Rectangle movingStaticSpriteRect = new Rectangle(245, 0, 16, 16);

            //get the window size
            int windowWidth = GraphicsDevice.Viewport.Width;
            int windowHeight = GraphicsDevice.Viewport.Height;

            //left running frames
            Rectangle[] luigiRunLeftFrames = new Rectangle[]
            {
                new Rectangle(61, 0, 16, 16),   // Frame 1
                new Rectangle(32, 0, 16, 16),  // Frame 2
                new Rectangle(0, 0, 16, 16),  // Frame 3
            };

            //right running frames
            Rectangle[] luigiRunRightFrames = new Rectangle[]
            {
                new Rectangle(29, 38, 16, 16),  // Frame 1
                new Rectangle(60, 38, 16, 16), // Frame 2
                new Rectangle(88, 38, 16, 16), // Frame 3
            };



            //calculate the center position
            Vector2 centeredPosition = new Vector2(
                (windowWidth / 2) - (luigiRunRightFrames[0].Width / 2),
                (windowHeight / 2) - (luigiRunRightFrames[0].Height / 2)
            );

            //initialize the static and animated sprites
            _staticSprite = new StaticSprite(luigiTextureAtlas, staticSpriteRect, centeredPosition);
            _animatedSprite = new AnimatedSprite(luigiTextureAtlas, luigiRunLeftFrames, centeredPosition, 0.1);
            _movingStaticSprite = new MovingStaticSprite(luigiTextureAtlas, movingStaticSpriteRect, centeredPosition, windowHeight);
            _movingAnimatedSprite = new MovingAnimatedSprite(luigiTextureAtlas, luigiRunRightFrames, luigiRunLeftFrames, centeredPosition, 0.1, windowWidth);

            //set the default sprite to static sprite
            SetCurrentSprite(_staticSprite);

            //mapping the keyboard number 1-4 to Sprite logic
            _keyboardController.RegisterAction(Keys.D1, new SwitchToStaticSpriteCommand(_staticSprite));
            _keyboardController.RegisterAction(Keys.D2, new SwitchToAnimatedSpriteCommand(_animatedSprite));
            _keyboardController.RegisterAction(Keys.D3, new SwitchToStaticSpriteCommand(_movingStaticSprite));
            _keyboardController.RegisterAction(Keys.D4, new SwitchToAnimatedSpriteCommand(_movingAnimatedSprite));

            //mapping mouse buttons to the Sprite Logic
            _mouseController.RegisterAction(MouseButton.TopLeft, new SwitchToStaticSpriteCommand(_staticSprite));
            _mouseController.RegisterAction(MouseButton.TopRight, new SwitchToAnimatedSpriteCommand(_animatedSprite));
            _mouseController.RegisterAction(MouseButton.BottomLeft, new SwitchToStaticSpriteCommand(_movingStaticSprite));
            _mouseController.RegisterAction(MouseButton.BottomRight, new SwitchToAnimatedSpriteCommand(_movingAnimatedSprite));

            //exiting the game
            _keyboardController.RegisterAction(Keys.Escape, new ExitGameCommand());
            _mouseController.RegisterAction(MouseButton.Right, new ExitGameCommand());
        }

        protected override void Update(GameTime gameTime)
        {
            _keyboardController.Update(this);
            _mouseController.Update(this);

            if (_currentSprite != null)
            {
                _currentSprite.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            //draw the current sprite (either static or animated)
            if (_currentSprite != null)
            {
                _currentSprite.Draw(_spriteBatch);
            }

            _creditsText.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
