using System;
using DBFighters.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DBFighters.Windows
{
    /// <summary>
    /// Classe abstraite qui sert à représenter une fenêtre de jeu
    /// </summary>
    internal abstract class MonogameWindow : IMonogameElement
    {
        // Champs de la classe...
        public Rectangle View { get; private set; }

        // Constructeur de la classe...
        public MonogameWindow(double ratio, int baseWidth = 520)
        {
            View = new Rectangle(0, 0, baseWidth, (int)(baseWidth * ratio));
        }

        // Méthodes de la classe...
        public abstract void LoadContent(ContentManager content);

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public abstract void Update(GameTime gameTime);
    }
}
