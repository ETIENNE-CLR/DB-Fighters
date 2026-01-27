using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Config
{
    /// <summary>
    /// Classe représentant un sprite individuel extrait d'une texture (spritesheet).
    /// </summary>
    internal class Sprite
    {
        /// <summary>
        /// Dimension du sprite en pixels
        /// </summary>
        public Size Size { get; private set; }

        /// <summary>
        /// Marge interieur du spritesheet
        /// </summary>
        public Vector2 Padding { get; private set; }

        /// <summary>
        /// Espace entre les sprites
        /// </summary>
        public Vector2 Spacing { get; private set; }

        /// <summary>
        /// Facteur de zoom pour l'affichage
        /// </summary>
        public int Scale { get; private set; }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="size">Dimension du sprite en pixels</param>
        /// <param name="padding">Marge interieur du spritesheet</param>
        /// <param name="spacing">Espace entre les sprites</param>
        /// <param name="scale">Facteur de zoom pour l'affichage</param>
        /// <exception cref="ArgumentNullException">Si les paramètres données sont invalides ou null</exception>
        public Sprite(Size size, Vector2 padding, Vector2 spacing, int scale = 1)
        {
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Padding = padding;
            Spacing = spacing;
            Scale = scale;
        }
    }
}
