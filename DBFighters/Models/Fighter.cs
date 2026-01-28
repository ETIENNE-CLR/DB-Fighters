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
    internal abstract class Fighter : AnimatedElement
    {
        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="position">La position initiale de l'entité</param>
        /// <param name="velocity">La vélocité initiale de l'entité</param>
        /// <param name="scale">Facteur de zoom pour l'affichage</param>
        public Fighter(Vector2 position, Vector2 velocity, double scale = 1.5) : base(position, velocity, scale)
        {
            Translate = new Translation(true, false);
            ShowHitbox = true;
        }

        public override void UpdateFlipped()
        {
            throw new NotImplementedException();
        }
    }
}
