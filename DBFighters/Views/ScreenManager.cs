using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFighters.Enums;
using DBFighters.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DBFighters.Windows
{
    /// <summary>
    /// Classe qui sert à gérer l'affichage d'une vue
    /// </summary>
    internal class ScreenManager : IMonogameElement
    {
        /// <summary>
        /// Paramètres graphique gardé en cache pour le
        /// redimensionnement de la fenêtre
        /// </summary>
        private GraphicsDeviceManager graphics;

        /// <summary>
        /// Dictionnaire qui relie une vue pour un id
        /// </summary>
        private Dictionary<NamesViews, MonogameWindow> screens;

        /// <summary>
        /// Id de la vue active
        /// </summary>
        private NamesViews currentScreenId;

        /// <summary>
        /// Vue courante
        /// </summary>
        public MonogameWindow CurrentScreen => screens[currentScreenId];

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="graphics">Paramètre graphique</param>
        /// <param name="screens">Vue de l'application</param>
        public ScreenManager(GraphicsDeviceManager graphics, Dictionary<NamesViews, MonogameWindow> screens)
        {
            this.graphics = graphics;
            this.screens = screens;
        }

        /// <summary>
        /// Méthode qui permet de changer la vue actuelle par une autre
        /// </summary>
        /// <param name="idView"></param>
        /// <exception cref="Exception"></exception>
        public void SetScreen(NamesViews idView)
        {
            if (screens.TryGetValue(idView, out MonogameWindow screen))
            {
                // New win
                currentScreenId = idView;
                MonogameWindow cs = CurrentScreen;

                // Definir les dimensions
                graphics.PreferredBackBufferWidth = cs.View.Width;
                graphics.PreferredBackBufferHeight = cs.View.Height;
                graphics.ApplyChanges();
            }
            else throw new Exception($"La vue {idView} n'a pas été trouvé !");
        }

        public void LoadContent(ContentManager content)
        {
            foreach (var screen in screens.Values)
                screen.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            CurrentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            CurrentScreen.Draw(spriteBatch, gameTime);
        }
    }
}
