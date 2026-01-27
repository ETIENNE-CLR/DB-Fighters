using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Config
{
    /// <summary>
    /// Classe représentant une taille en 2D.
    /// </summary>
    internal class Size
    {

        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="width">Largeur de l'élément</param>
        /// <param name="height">Hauteur de l'élément</param>
        public Size(int width = 0, int height = 0)
        {
            Width = width;
            Height = height;
        }
    }
}
