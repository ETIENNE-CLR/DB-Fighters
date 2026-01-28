using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Config
{
    /// <summary>
    /// Classe représentant une gravité
    /// </summary>
    internal class GravityComponent
    {
        /// <summary>
        /// La position Y du sol
        /// </summary>
        public float GroundPositionY { get; set; }

        /// <summary>
        /// L'intensité de la gravité environnante
        /// </summary>
        public float GravityEnvironnement { get; set; }

        /// <summary>
        /// La vitesse maximale lorsqu'on tombe
        /// </summary>
        public float MaxFallSpeed { get; set; }

        /// <summary>
        /// Si la gravité est active
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="gravityEnvironnement">L'intensité de la gravité environnante</param>
        /// <param name="maxFallSpeed">La vitesse maximale lorsqu'on tombe</param>
        /// <param name="enabled">Si la gravité est active</param>
        public GravityComponent(float gravityEnvironnement = 30f, float maxFallSpeed = 100f, bool enabled = true)
        {
            GravityEnvironnement = gravityEnvironnement;
            MaxFallSpeed = maxFallSpeed;
            Enabled = enabled;
        }

        /// <summary>
        /// Définie la hauteur du sol
        /// </summary>
        /// <param name="groundPositionY">Les coordonées du sol</param>
        public void SetGround(float groundPositionY)
        {
            GroundPositionY = groundPositionY;
        }

        /// <summary>
        /// Appliquer la gravité
        /// </summary>
        /// <param name="velocity">La référence Vecteur de la vélocité</param>
        /// <param name="deltaTime">intervalle de temps entre les fps en secondes</param>
        public void Apply(ref Vector2 velocity, float deltaTime)
        {
            if (!Enabled) return;
            velocity.Y += GravityEnvironnement * deltaTime;
            velocity.Y = Math.Min(velocity.Y, MaxFallSpeed);
        }


        /// <summary>
        /// Dit si la coordonné touche le sol
        /// </summary>
        /// <param name="coordonate">la coordonnée de la hauteur</param>
        /// <returns>Si la coordonné touche le sol</returns>
        public bool TouchesGround(float coordonate)
        {
            return coordonate < GroundPositionY;
        }

        /// <summary>
        /// Dit si le vecteur touche le sol
        /// </summary>
        /// <param name="position">La position</param>
        /// <returns>Si le vecteur touche le sol</returns>
        public bool TouchesGround(Vector2 position)
        {
            return position.Y < GroundPositionY;
        }

        /// <summary>
        /// Dit si un rectangle touche le sol
        /// </summary>
        /// <param name="rect">Le rectangle de l'élement</param>
        /// <returns>Si un rectangle touche le sol</returns>
        public bool TouchesGround(Rectangle rect)
        {
            return rect.Bottom >= GroundPositionY;
        }
    }
}
