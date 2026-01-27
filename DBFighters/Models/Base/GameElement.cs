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
        public Vector2 Position { get; protected set; }

        /// <summary>
        /// Nom de la texture associée
        /// </summary>
        public string TextureName { get; protected set; }

        /// <summary>
        /// Vélocité de l'élement
        /// </summary>
        public Vector2 Velocity { get; protected set; }

        /// <summary>
        /// Facteur de zoom pour l'affichage
        /// </summary>
        public int Scale { get; protected set; }

        /// <summary>
        /// Indicateur d'affichage de la hitbox
        /// </summary>
        public bool ShowHitbox { get; protected set; }

        /// <summary>
        /// Si l'élement doit se draw à -50% de sa position
        /// </summary>
        public bool Translate { get; protected set; }

        /// <summary>
        /// Si l'élement est retourné
        /// </summary>
        public bool Flipped { get; protected set; }

        /// <summary>
        /// Texture de l'élement
        /// </summary>
        public MyTexture Texture => !string.IsNullOrEmpty(TextureName) ? AssetsManager.GetTexture(TextureName) : null;

        /// <summary>
        /// Dimension de l'élement
        /// </summary>
        public Size Size => (Texture != null) ? new Size(Texture.Img.Width, Texture.Img.Height) : new Size();

        /// <summary>
        /// Hitbox de l'élement
        /// </summary>
        public Rectangle Hitbox
        {
            get
            {
                // Init
                Rectangle rect = new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Size.Width * this.Scale,
                    Size.Height * this.Scale
                );

                // Translation
                if (Translate)
                {
                    rect.X -= ((int)LogicsUtils.GetNumberFromPercentage(50, rect.Width));
                    rect.Y -= ((int)LogicsUtils.GetNumberFromPercentage(50, rect.Height));
                }
                return rect;
            }
        }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="position">La position initiale de l'entité</param>
        /// <param name="velocity">La vélocité initiale de l'entité</param>
        /// <param name="scale">Facteur de zoom pour l'affichage</param>
        public GameElement(Vector2 position, Vector2 velocity, int scale)
        {
            Position = position;
            Velocity = velocity;
            Scale = scale;

            TextureName = null;
            ShowHitbox = false;
            Translate = false;
        }
    }
}
