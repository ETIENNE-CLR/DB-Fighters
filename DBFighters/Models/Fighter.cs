using DBFighters.Config;
using DBFighters.Managers;
using DBFighters.Models.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Models
{
    /// <summary>
    /// Classe abstraite qui représente un combattant
    /// </summary>
    internal class Fighter : AnimatedElement
    {
        public Fighter(Vector2 position, Vector2 velocity, double scale = 1.5) : base(position, velocity, scale)
        {
            TextureName = "BlackGoku";
        }

        public override void LoadContent(ContentManager content)
        {
            MyTexture texture = AssetsManager.LoadTexture(content, TextureName, "Fighters/black_goku");

            // Animations
            Animations["idle"] = Animation.FromSpriteSheet(new Sprite(new Size(50, 50), new Vector2(16, 38), new Vector2(7, 0)), true, 4, 205, true);
            AnimationName = "idle";
            CurrentAnimation.Play();
        }

        public override void UpdateFlipped()
        {
            throw new NotImplementedException();
        }
    }
}
