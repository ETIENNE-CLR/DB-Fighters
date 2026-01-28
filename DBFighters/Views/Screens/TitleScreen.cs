using DBFighters.Models;
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
    internal class TitleScreen : MonogameWindow
    {
        private Fighter f;

        public TitleScreen(double ratio, int baseWidth = 520) : base(ratio, baseWidth)
        {
            f = new Fighter(new Vector2(0, 0), Vector2.Zero);
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
