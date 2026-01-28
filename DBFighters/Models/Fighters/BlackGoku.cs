using DBFighters.Config;
using DBFighters.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Models.Fighters
{
    internal class BlackGoku : Fighter
    {
        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="position">La position initiale de Goku Black</param>
        /// <param name="velocity">La vélocité initiale de Goku Black</param>
        public BlackGoku(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            TextureName = "black_goku";
            // ShowHitbox = true;
        }

        public override void LoadContent(ContentManager content)
        {
            MyTexture texture = AssetsManager.LoadTexture(content, TextureName, $"Fighters/{TextureName}");

            // Animations
            Animations["idle"] = Animation.FromSpriteSheet(new Sprite(new Size(50, 50), new Vector2(16, 38), new Vector2(7, 0)), true, 4, 205, true);
            AnimationName = "idle";
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
