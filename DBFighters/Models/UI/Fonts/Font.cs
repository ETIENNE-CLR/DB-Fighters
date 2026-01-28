using DBFighters.Config;
using DBFighters.Interfaces;
using DBFighters.Managers;
using DBFighters.Models.Base;
using DBFighters.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Models.UI.Fonts
{
    internal abstract class Font : GameElement, IMonogameElement
    {
        /// <summary>
        /// Le dictionnaire de références
        /// </summary>
        protected Dictionary<char, Rectangle> ReferenceDigits;

        /// <summary>
        /// Le tableau qui va contenir toutes les lettres à afficher
        /// </summary>
        public List<Rectangle> DigitsToDisplay { get; protected set; }

        /// <summary>
        /// Le texte à afficher
        /// </summary>
        public string Text { get; protected set; }

        /// <summary>
        /// Hitbox du texte
        /// </summary>
        public override Rectangle Hitbox
        {
            get
            {
                int w = 0; int h = 0;
                int spacing = 1;

                foreach (Rectangle l in DigitsToDisplay)
                {
                    w += l.Width + spacing;
                    h = Math.Max(h, l.Height);
                }
                return new Rectangle((int)Position.X, (int)Position.Y, w, h);
            }
        }

        public Font(Vector2 position, double scale = 1) : this("", position, scale)
        { }

        public Font(string text, Vector2 position, double scale = 1) : base(position, Vector2.Zero, scale)
        {
            Text = text;
            ReferenceDigits = new Dictionary<char, Rectangle>();
            DigitsToDisplay = new List<Rectangle>();
            // ShowHitbox = true;
        }

        /// <summary>
        /// Met à jour le texte à afficher
        /// </summary>
        /// <param name="text">Le texte à afficher</param>
        public void UpdateText(string text)
        {
            Text = text;
            BuildDigitsToDisplay();
        }

        /// <summary>
        /// Met à jour le texte d'affichage
        /// </summary>
        private void BuildDigitsToDisplay()
        {
            // Vérification du dictionnaire
            if (Text.Length > 0 && !(ReferenceDigits.Count > 0))
                throw new Exception("La référence bloque le build.");

            // Build
            DigitsToDisplay.Clear();
            foreach (char c in Text)
            {
                if (ReferenceDigits.ContainsKey(c))
                    DigitsToDisplay.Add(ReferenceDigits[c]);
                else
                    throw new Exception($"Le build pour le caractère \"{c.ToString()}\" s'est mal passé !");
            }
        }

        public void LoadContent(ContentManager content)
        {
            AssetsManager.LoadTexture(content, TextureName, $"Fonts/{TextureName}");
            BuildDigitsToDisplay();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Init
            Vector2 copy = new Vector2(Position.X, Position.Y);
            int letterSpacing = 2;

            // Draw chaque digitsToDisplay
            foreach (Rectangle l in DigitsToDisplay)
            {
                spriteBatch.Draw(Texture.Img, copy, l, Color.White, 0f, Vector2.Zero, ((float)Scale), SpriteEffects.None, 0f);
                copy.X += l.Width + letterSpacing;
            }

            // Afficher la hitbox
            if (ShowHitbox) LogicsUtils.DrawHitbox(spriteBatch, Hitbox);
        }
    }
}
