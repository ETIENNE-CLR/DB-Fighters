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
        public BlackGoku(Vector2 position) : base(position)
        { }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="position">La position initiale de Goku Black</param>
        /// <param name="speed">La vitesse de base de l'entité</param>
        public BlackGoku(Vector2 position, Vector2 speed) : base(position, speed)
        { }

        public override void LoadContent(ContentManager content)
        {
            // Init
            // ShowHitbox = true;
            TextureName = "black_goku";

            // Animations
            Animations["idle"] = Animation.FromSpriteSheet(new Sprite(new Size(50, 50), new Vector2(16, 38), new Vector2(7, 0)), true, 4, 205, true);
            AnimationName = "idle";

            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
