using DBFighters.Enums;
using DBFighters.Managers;
using DBFighters.Views.Screens;
using DBFighters.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DBFighters
{
    internal class Game1 : Game
    {
        // Champs de la classe...
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ScreenManager ScreenManager { get; private set; }

        // Constructeur de la classe...
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        // Méthodes de la classe...
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            const double RATIO = 5.0 / 8.0;
            const int BASE_WIDTH = 1080;

            ScreenManager = new ScreenManager(_graphics, new Dictionary<NamesViews, MonogameWindow>()
            {
                { NamesViews.TITLESCREEN, new TitleScreen(RATIO, BASE_WIDTH) },
            });
            ScreenManager.SetScreen(NamesViews.TITLESCREEN);

            // Init window
            this.Window.Title = "Dragon Ball Fighters";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            AssetsManager.Load(GraphicsDevice);
            ScreenManager.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ScreenManager.CurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            ScreenManager.CurrentScreen.Draw(_spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}
