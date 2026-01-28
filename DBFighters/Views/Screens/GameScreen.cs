using DBFighters.Models.Fighters;
using DBFighters.Models.UI.Fonts;
using DBFighters.Utils;
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
        private PixelFont font;

        public GameScreen(double ratio, int baseWidth) : base(ratio, baseWidth)
        {
            f = new BlackGoku(new Vector2(
                LogicsUtils.GetNumberFromPercentage(25, View.Width),
                LogicsUtils.GetNumberFromPercentage(65, View.Height)
            ));
            font = new PixelFont(new Vector2(0, 0));
        }

        public override void LoadContent(ContentManager content)
        {
            f.LoadContent(content);
            font.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            f.Update(gameTime);
            font.UpdateText(f.Position.Y.ToString());
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            f.Draw(spriteBatch, gameTime);
            font.Draw(spriteBatch, gameTime);
        }
    }
}
