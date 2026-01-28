using DBFighters.Config;
using DBFighters.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Models.UI.Fonts
{
    internal class PixelFont : Font
    {
        public PixelFont(Vector2 position, double scale = 1) : base(position, scale)
        {
        }

        public PixelFont(string text, Vector2 position, double scale = 1) : base(text, position, scale)
        {
        }

        public void LoadContent(ContentManager content)
        {
            // Init
            TextureName = "pixel";
            ReferenceDigits.Clear();

            // Digits
            ReferenceDigits.Add('0', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(142, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('1', Animation.FromSpriteSheet(new Sprite(new Size(12, 32), new Vector2(174, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('2', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(198, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('3', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(226, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('4', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(254, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('5', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(282, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('6', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(310, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('7', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(338, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('8', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(366, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('9', Animation.FromSpriteSheet(new Sprite(new Size(20, 32), new Vector2(394, 146), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);

            ReferenceDigits.Add(',', Animation.FromSpriteSheet(new Sprite(new Size(16, 36), new Vector2(534, 538), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);
            ReferenceDigits.Add('-', Animation.FromSpriteSheet(new Sprite(new Size(24, 40), new Vector2(422, 482), new Vector2(0, 0)), true, 1, int.MaxValue, false).Frames[0]);

            base.LoadContent(content);
        }
    }
}
