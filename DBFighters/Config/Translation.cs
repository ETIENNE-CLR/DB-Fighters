using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Config
{
    /// <summary>
    /// Classe qui aide à l'indication de la translation d'un élement
    /// </summary>
    internal class Translation
    {
        /// <summary>
        /// Si l'élement doit être translaté en X
        /// </summary>
        public bool X { get; set; }

        /// <summary>
        /// Si l'élement doit être translaté en Y
        /// </summary>
        public bool Y { get; set; }

        /// <summary>
        /// Retourne une translation activé en X et Y
        /// </summary>
        public static Translation Full => new Translation(true, true);

        /// <summary>
        /// Retourne une translation désactivé en X et Y
        /// </summary>
        public static Translation None => new Translation(false, false);

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="translateX">Si l'élement doit être translaté en X</param>
        /// <param name="translateY">Si l'élement doit être translaté en Y</param>
        public Translation(bool translateX, bool translateY)
        {
            X = translateX;
            Y = translateY;
        }
    }
}
