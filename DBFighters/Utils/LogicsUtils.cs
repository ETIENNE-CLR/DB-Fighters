using DBFighters.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Utils
{
    internal static class LogicsUtils
    {
        /// <summary>
        /// Méthode qui retourne le nombre précis en fonction de son pourcentage
        /// </summary>
        public static float GetNumberFromPercentage(float percentage, float total)
        {
            return (percentage / 100f) * total;
        }

        /// <summary>
        /// Dessine les bordures de la hitbox
        /// </summary>
        /// <param name="spriteBatch">Outil de dessin</param>
        /// <param name="Hitbox">La hitbox à dessiner le contour</param>
        public static void DrawHitbox(SpriteBatch spriteBatch, Rectangle Hitbox)
        {
            int thickness = 2;
            Color color = Color.Red;
            Rectangle rect = Hitbox;

            // Tracer les 4 côtés
            spriteBatch.Draw(AssetsManager.WhitePixel, new Rectangle(rect.X, rect.Y, rect.Width, thickness), color); // Haut
            spriteBatch.Draw(AssetsManager.WhitePixel, new Rectangle(rect.X, rect.Y, thickness, rect.Height), color); // Gauche
            spriteBatch.Draw(AssetsManager.WhitePixel, new Rectangle(rect.X + rect.Width - thickness, rect.Y, thickness, rect.Height), color); // Droite
            spriteBatch.Draw(AssetsManager.WhitePixel, new Rectangle(rect.X, rect.Y + rect.Height - thickness, rect.Width, thickness), color); // Bas
        }
    }
}
