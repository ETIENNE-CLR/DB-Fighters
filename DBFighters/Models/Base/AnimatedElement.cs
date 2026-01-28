using DBFighters.Config;
using DBFighters.Interfaces;
using DBFighters.Managers;
using DBFighters.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Models.Base
{
    /// <summary>
    /// Une classe représentant un objet animé
    /// </summary>
    internal abstract class AnimatedElement : GameElement, IMonogameElement
    {
        /// <summary>
        /// Tableau d'animations
        /// </summary>
        public Dictionary<string, Animation> Animations { get; protected set; }

        /// <summary>
        /// Le nom de l'animation
        /// </summary>
        public string AnimationName { get; protected set; }


        public override Size Dimension => new Size(CurrentAnimation.CurrentFrame.Width, CurrentAnimation.CurrentFrame.Height);

        /// <summary>
        /// L'animation courante
        /// </summary>
        public Animation CurrentAnimation
        {
            get
            {
                Animation? found = Animations[AnimationName];
                if (found == null) throw new Exception($"L'animation avec la clé {this.AnimationName} n'a pas été trouvé.");
                return found;
            }
        }

        /// <summary>
        /// Constructeur de la classe Entity.
        /// </summary>
        /// <param name="position">La position initiale de l'entité</param>
        /// <param name="velocity">La vélocité initiale de l'entité</param>
        /// <param name="scale">Facteur de zoom pour l'affichage</param>
        protected AnimatedElement(Vector2 position, Vector2 velocity, double scale = 1) : base(position, velocity, scale)
        {
            Animations = new Dictionary<string, Animation>();
            AnimationName = null;
        }

        /// <summary>
        /// Fonction qui définit la condition pour laquel l'élement est flip.
        /// Elle doit redéfinir la propriété dans chaque classe hérité !
        /// </summary>
        public abstract void UpdateFlipped();
        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gameTime)
        {
            CurrentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Texture == null) throw new Exception("La texture n'a pas été chargé.");

            // Init
            Animation anim = CurrentAnimation;
            Rectangle sprite = CurrentAnimation.CurrentFrame;
            Rectangle src = new Rectangle(((int)sprite.X), ((int)sprite.Y), Dimension.Width, Dimension.Height);
            Rectangle dst = Hitbox;
            SpriteEffects effects = this.Flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            // Draw
            spriteBatch.Draw(
                Texture.Img,
                position: new Vector2(dst.X, dst.Y),
                sourceRectangle: src,
                color: Color.White,
                rotation: 0f,
                origin: Vector2.Zero,
                scale: ((float)Scale),
                effects: effects,
                layerDepth: 0f
            );


            // Show Hitbox
            if (ShowHitbox)
            {
                // Init
                int thickness = 2;
                Color color = Color.Red;

                // Tracer les 4 côtés
                spriteBatch.Draw(AssetsManager.WhitePixel, new Rectangle(dst.X, dst.Y, dst.Width, thickness), color); // Haut
                spriteBatch.Draw(AssetsManager.WhitePixel, new Rectangle(dst.X, dst.Y, thickness, dst.Height), color); // Gauche
                spriteBatch.Draw(AssetsManager.WhitePixel, new Rectangle(dst.X + dst.Width - thickness, dst.Y, thickness, dst.Height), color); // Droite
                spriteBatch.Draw(AssetsManager.WhitePixel, new Rectangle(dst.X, dst.Y + dst.Height - thickness, dst.Width, thickness), color); // Bas
            }
        }
    }
}
