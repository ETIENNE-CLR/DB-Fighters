using DBFighters.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Config
{
    /// <summary>
    /// Classe représentant une animation composée de plusieurs frames
    /// </summary>
    internal class Animation : IMonogameElement
    {
        /// <summary>
        /// sprites Frames de l'animation
        /// </summary>
        public List<Rectangle> Frames { get; private set; }

        /// <summary>
        /// L'index de la frame actuelle
        /// </summary>
        private int FrameIndex;

        /// <summary>
        /// Le temps écoulé de l'animation
        /// </summary>
        private float ElapsedTime;

        /// <summary>
        /// Si l'animation est terminée ou non
        /// </summary>
        public bool Finished { get; private set; }

        /// <summary>
        /// Le temps de durée d'une frame
        /// </summary>
        public float FrameDuration { get; private set; }

        /// <summary>
        /// Si la lecture de l'animation se fait en boucle
        /// </summary>
        public bool Loop { get; private set; }

        /// <summary>
        /// Si l'animation est en train d'être jouée
        /// </summary>
        public bool IsPlaying { get; private set; }

        /// <summary>
        /// la frame actuelle
        /// </summary>
        public Rectangle CurrentFrame => Frames.Count == 0 ? Rectangle.Empty : Frames[FrameIndex];

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="frames">Tableau d'images de l'animation</param>
        /// <param name="frameDuration">Durée d'une frame en ms</param>
        /// <param name="loop">Est-ce que l'animation tourne en boucle ?</param>
        /// <param name="autoPlay">Si l'animation doit être jouée dès le début</param>
        /// <exception cref="ArgumentOutOfRangeException">Si frameDuration négatif</exception>
        public Animation(List<Rectangle> frames, float frameDuration, bool loop = true, bool autoPlay = true)
        {
            if (frameDuration <= 0f)
                throw new ArgumentOutOfRangeException(nameof(frameDuration), "frameDuration must be > 0.");

            Frames = frames;
            FrameDuration = frameDuration;
            FrameIndex = 0;

            ElapsedTime = 0f;
            Loop = loop;

            Finished = false;
            IsPlaying = autoPlay;
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
        public static Animation FromSpriteSheet(Sprite sprite, bool horizontalOrientation, int frameCount, float frameTime, bool loop = true)
        {
            List<Rectangle> framesTmp = [];
            for (int i = 0; i < frameCount; i++)
            {
                framesTmp.Add(new Rectangle(
                    ((int)(sprite.Padding.X + (horizontalOrientation ? (sprite.Size.Width + sprite.Spacing.X) * i : 0))),
                    ((int)(sprite.Padding.Y + (!horizontalOrientation ? (sprite.Size.Height + sprite.Spacing.Y) * i : 0))),
                    sprite.Size.Width,
                    sprite.Size.Height
                ));
            }
            return new Animation(framesTmp, frameTime, loop);
        }


        /// <summary>
        /// Permet la logique pour mettre l'animation sur play
        /// </summary>
        public void Play()
        {
            if (Frames.Count == 0) return;
            if (Finished && !Loop) return;
            IsPlaying = true;
        }

        /// <summary>
        /// Permet la logique pour mettre l'animation sur pause
        /// </summary>
        public void Pause() => IsPlaying = false;

        /// <summary>
        /// Stop l'animation
        /// </summary>
        public void Stop() => Pause();

        /// <summary>
        /// Méthode pour remettre l'animation à zéro
        /// </summary>
        public void Reset()
        {
            FrameIndex = 0;
            ElapsedTime = 0f;
            Finished = false;
        }

        /// <summary>
        /// Permet de redémarrer l'animation
        /// </summary>
        public void Restart()
        {
            Reset();
            IsPlaying = Frames.Count > 0;
        }

        /// <summary>
        /// Force l'index de la frame de l'animation
        /// </summary>
        public void SetFrame(int frameIndex)
        {
            if (Frames.Count == 0) return;
            FrameIndex = Math.Clamp(frameIndex, 0, Frames.Count - 1);
        }

        public void Update(GameTime gameTime)
        {
            // Test de base
            if (!IsPlaying) return;
            if (Frames.Count == 0) return;
            if (Finished && !Loop) return;

            // DeltaTime
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (deltaTime <= 0) return;
            ElapsedTime += deltaTime;

            // Update
            while (ElapsedTime >= FrameDuration)
            {
                ElapsedTime -= FrameDuration;

                // Aller vers la prochaine frame
                FrameIndex++;
                if (FrameIndex >= Frames.Count)
                {
                    if (Loop)
                        FrameIndex = 0;
                    else
                    {
                        // reste sur la dernière frame
                        FrameIndex = Frames.Count - 1;
                        Finished = true;
                        IsPlaying = false;
                        break;
                    }
                }
            }
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
