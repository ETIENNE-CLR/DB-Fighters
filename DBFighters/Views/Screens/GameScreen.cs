using DBFighters.Models.Fighters;
using DBFighters.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Views.Screens
{
    internal class GameScreen : MonogameWindow
    {
        private BlackGoku f;

        public GameScreen(double ratio, int baseWidth) : base(ratio, baseWidth)
        {
            f = new BlackGoku(new Vector2(0, 0), Vector2.Zero);
        }

        public override void LoadContent(ContentManager content)
        {
            f.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            f.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            f.Draw(spriteBatch, gameTime);
        }
    }
}
