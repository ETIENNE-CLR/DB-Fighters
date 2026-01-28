using DBFighters.Interfaces;
using DBFighters.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Config
{
    /// <summary>
    /// Classe représentant une texture
    /// </summary>
    internal class MyTexture : IMonogameElement
    {

        /// <summary>
        /// Nom de la texture
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Source de l'image de la texture
        /// </summary>
        public string Src { get; private set; }

        /// <summary>
        /// Image de la texture
        /// </summary>
        public Texture2D Img { get; private set; }

        /// <summary>
        /// Si la texture a été chargé
        /// </summary>
        public bool Loaded => AssetsManager.GetTexture(Name) != null;

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="name">Nom de la texture</param>
        /// <param name="src">Chemin vers l'image de la texture</param>
        /// <exception cref="ArgumentNullException">Si les paramètres données sont invalides ou null</exception>
        public MyTexture(string name, string src)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Src = src ?? throw new ArgumentNullException(nameof(src));
        }

        public void LoadContent(ContentManager content)
        {
            Img = content.Load<Texture2D>(Src);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
