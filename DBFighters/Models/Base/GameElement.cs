using DBFighters.Config;
using DBFighters.Interfaces;
using DBFighters.Managers;
using DBFighters.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Models.Base
{
    /// <summary>
    /// Classe qui sert à représenter un élement du jeu
    /// </summary>
    internal abstract class GameElement
    {
        /// <summary>
        /// Position de l'élement
        /// </summary>
        protected Vector2 position;

        /// <summary>
        /// Position de l'élement
        /// </summary>
        public Vector2 Position { get => position; }

        /// <summary>
        /// Nom de la texture associée
        /// </summary>
        public string TextureName { get; protected set; }

        /// <summary>
        /// Vitesse au moment T de l'élement
        /// </summary>
        protected Vector2 velocity;

        /// <summary>
        /// Vitesse au moment T de l'élement
        /// </summary>
        public Vector2 Velocity { get => velocity; }


        /// <summary>
        /// Vitese de base de l'élement
        /// </summary>
        protected Vector2 speed;

        /// <summary>
        /// Vitese de base de l'élement
        /// </summary>
        public Vector2 Speed { get => speed; }


        /// <summary>
        /// Facteur de zoom pour l'affichage
        /// </summary>
        public double Scale { get; protected set; }

        /// <summary>
        /// Indicateur d'affichage de la hitbox
        /// </summary>
        public bool ShowHitbox { get; protected set; }

        /// <summary>
        /// La translation de l'élement
        /// </summary>
        public Translation Translate { get; protected set; }

        /// <summary>
        /// Si l'élement est retourné
        /// </summary>
        public bool Flipped { get; protected set; }

        /// <summary>
        /// Texture de l'élement
        /// </summary>
        public MyTexture Texture => !string.IsNullOrEmpty(TextureName) ? AssetsManager.GetTexture(TextureName) : null;

        /// <summary>
        /// Dimension de l'élément
        /// </summary>
        public virtual Size Dimension => (Texture != null && Texture.Loaded) ? new Size(Texture.Img.Width, Texture.Img.Height) : new Size();

        /// <summary>
        /// Hitbox de l'élement
        /// </summary>
        public virtual Rectangle Hitbox
        {
            get
            {
                // Init
                Rectangle rect = new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    ((int)(Dimension.Width * Scale)),
                    ((int)(Dimension.Height * Scale))
                );

                // Translation
                if (Translate.X) rect.X -= ((int)LogicsUtils.GetNumberFromPercentage(50, rect.Width));
                if (Translate.Y) rect.Y -= ((int)LogicsUtils.GetNumberFromPercentage(50, rect.Height));
                return rect;
            }
        }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="position">La position initiale de l'entité</param>
        /// <param name="speed">La vitesse de l'élement</param>
        /// <param name="scale">Facteur de zoom pour l'affichage</param>
        public GameElement(Vector2 position, Vector2 speed, double scale)
        {
            this.position = position;
            this.speed = speed;
            this.velocity = Vector2.Zero;
            Scale = scale;

            TextureName = null;
            ShowHitbox = false;
            Translate = Translation.None;
        }
    }
}
