using DBFighters.Config;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Managers
{
    /// <summary>
    /// Classe qui sert à gérer les assets chargées
    /// </summary>
    internal class AssetsManager
    {
        /// <summary>
        /// Dictionnaire qui sert à relier une texture à un nom
        /// </summary>
        private static Dictionary<string, MyTexture> textures = [];

        /// <summary>
        /// Pixel blanc
        /// </summary>
        public static Texture2D WhitePixel { get; set; }

        /// <summary>
        /// Permet de charger les pixels
        /// </summary>
        /// <param name="graphicsDevice"></param>
        public static void Load(GraphicsDevice graphicsDevice)
        {
            WhitePixel = new Texture2D(graphicsDevice, 1, 1);
            WhitePixel.SetData(new[] { Color.White });
        }

        /// <summary>
        /// Permet de charger une texture
        /// </summary>
        /// <param name="content">Content qui chargera les textures</param>
        /// <param name="name">Nom de la texture</param>
        /// <param name="src">Source de la texture</param>
        /// <returns>Texture chargée</returns>
        public static MyTexture LoadTexture(ContentManager content, string name, string src)
        {
            string key = name.ToLower();
            if (textures[key] == null)
            {
                MyTexture texture = new MyTexture(name, src);
                texture.LoadContent(content);
            }
            VerifyIfTextureCloned();
            return textures[key];
        }

        /// <summary>
        /// Récupère une texture déjà chargée
        /// </summary>
        /// <param name="name">nom de la texture</param>
        /// <returns>texture demandée</returns>
        public static MyTexture GetTexture(string name)
        {
            return textures[name.ToLower()];
        }

        /// <summary>
        /// fonction qui verifie si une texture n'a pas deux non différent (n'a pas été chargé deux fois)
        /// </summary>
        /// <exception cref="Exception">Si la texture a déjà été chargé</exception>
        private static void VerifyIfTextureCloned()
        {
            var seen = new HashSet<string>();

            foreach (var texture in textures.Values)
                if (!seen.Add(texture.Src))
                    throw new Exception($"La texture \"{texture.Src}\" a déjà été chargée !");
        }
    }
}
