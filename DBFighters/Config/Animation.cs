using DBFighters.Interfaces;
using DBFighters.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Config
{
    /// <summary>
    /// Classe représentant une animation composée de plusieurs sprites.
    /// </summary>
    internal class Animation : IMonogameElement
    {
        /// <summary>
        /// sprites Frames de l'animation
        /// </summary>
        public List<Sprite> Sprites { get; private set; }

        /// <summary>
        /// Le temps de durée d'une frame
        /// </summary>
        public float FrameDuration { get; private set; }

        /// <summary>
        /// Le temps écoulé de l'animation
        /// </summary>
        private float ElapsedTime;

        /// <summary>
        /// L'index de la frame actuelle
        /// </summary>
        private int currentFrameIndex;

        /// <summary>
        /// Si la lecture de l'animation se fait en boucle
        /// </summary>
        public bool Loop { get; private set; }

        /// <summary>
        /// la sprite actuelle
        /// </summary>
        public Sprite? CurrentSprite => Sprites.Count == 0 ? null : Sprites[Math.Clamp(currentFrameIndex, 0, Sprites.Count - 1)];

        /// <summary>
        /// Permet de dire si l'animation est en train de jouer
        /// </summary>
        public bool IsPlaying { get; private set; }

        /// <summary>
        /// Permet la logique pour mettre l'animation sur play
        /// </summary>
        public void Play() => IsPlaying = true;

        /// <summary>
        /// Permet la logique pour mettre l'animation sur pause
        /// </summary>
        public void Pause() => IsPlaying = false;

        /// <summary>
        /// Si l'animation est terminée ou non
        /// </summary>
        public bool IsFinished => !Loop && currentFrameIndex >= Sprites.Count - 1 && ElapsedTime <= 0f;

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="sprites">Frames de l'animation</param>
        /// <param name="frameDuration">Durée d'une frame en ms</param>
        /// <param name="loop">Est-ce que l'animation tourne en boucle ?</param>
        /// <exception cref="ArgumentNullException">Si paramètres null</exception>
        public Animation(List<Sprite> sprites, float frameDuration, bool loop)
        {
            Sprites = sprites ?? throw new ArgumentNullException(nameof(sprites));
            FrameDuration = frameDuration;
            Loop = loop;
            Play();
        }

        /// <summary>
        /// Retourne une instance de la classe Animation
        /// </summary>
        /// <param name="sprite">Un sprite de référence</param>
        /// <param name="horizontalOrientation">L'orientation de la lecture dans la spritesheet</param>
        /// <param name="frameCount">Nombre de frames de l'animation</param>
        /// <param name="frameTime">Le temps d'intervalle entre les frames</param>
        /// <param name="loop">Si l'animation doit être lu en boucle</param>
        /// <returns>L'animation configuré comme indiqué</returns>
        public static Animation GenAllAnimation(Sprite sprite, bool horizontalOrientation, int frameCount, float frameTime, bool loop = true)
        {
            List<Sprite> spritesTmp = [];
            for (int i = 0; i < frameCount; i++)
            {
                spritesTmp.Add(new Sprite(
                    sprite.Size,
                    new Vector2(
                        sprite.Padding.X + (horizontalOrientation ? (sprite.Size.Width + sprite.Spacing.X) * i : 0),
                        sprite.Padding.Y + (!horizontalOrientation ? (sprite.Size.Height + sprite.Spacing.Y) * i : 0)
                    ),
                    sprite.Spacing
                ));
            }
            return new Animation(spritesTmp, frameTime, loop);
        }

        public void Update(GameTime gameTime)
        {
            if (!IsPlaying) return;
            if (Sprites.Count <= 1) return;
            if (FrameDuration <= 0f) throw new InvalidOperationException("FrameDuration must be > 0");

            // Init
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ElapsedTime += deltaTime;

            // Update
            while (ElapsedTime >= FrameDuration)
            {
                ElapsedTime -= FrameDuration;
                this.currentFrameIndex++;

                if (this.currentFrameIndex >= Sprites.Count)
                {
                    if (Loop)
                        this.currentFrameIndex = 0;
                    else
                        this.currentFrameIndex = Sprites.Count - 1; // reste sur la dernière frame
                }
            }
        }

        /// <summary>
        /// Méthode pour remettre l'animation à zéro
        /// </summary>
        public void Reset()
        {
            currentFrameIndex = 0;
            ElapsedTime = 0;
        }

        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
