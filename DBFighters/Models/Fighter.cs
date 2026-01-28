using DBFighters.Config;
using DBFighters.Managers;
using DBFighters.Models.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.CodeDom;
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
        /// La scale de base
        /// </summary>
        public const int SCALE_BASE = 2;

        /// <summary>
        /// La vitesse de base
        /// </summary>
        public static Vector2 SPEED_BASE = new Vector2(6, 5);

        /// <summary>
        /// Gravité
        /// </summary>
        public GravityComponent Gravity { get; protected set; }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="position">La position initiale de l'entité</param>
        /// <param name="scale">Facteur de zoom pour l'affichage</param>
        public Fighter(Vector2 position, double scale = SCALE_BASE) : this(position, SPEED_BASE, scale)
        { }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="position">La position initiale de l'entité</param>
        /// <param name="speed">La vitesse initiale de l'entité</param>
        public Fighter(Vector2 position, Vector2 speed) : this(position, speed, SCALE_BASE)
        { }

        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        /// <param name="position">La position initiale de l'entité</param>
        /// <param name="speed">La vitesse initiale de l'entité</param>
        /// <param name="scale">Facteur de zoom pour l'affichage</param>
        public Fighter(Vector2 position, Vector2 speed, double scale = SCALE_BASE) : base(position, speed, scale)
        {
            Translate = new Translation(true, false);
            Gravity = new GravityComponent();
            ShowHitbox = true;
        }

        public override void LoadContent(ContentManager content)
        {
            AssetsManager.LoadTexture(content, TextureName, $"Fighters/{TextureName}");
            Gravity.SetGround(Hitbox.Bottom);
        }

        bool jumpPressedLastFrame;

        public override void Update(GameTime gameTime)
        {
            // Init
            base.Update(gameTime);
            Rectangle hb = Hitbox;
            KeyboardState kstate = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            bool isOnGround = Gravity.TouchesGround(hb);

            // Déplacement - Horizontal
            float targetX = 0;
            if (kstate.IsKeyDown(Keys.A)) targetX -= Speed.X;
            if (kstate.IsKeyDown(Keys.D)) targetX += Speed.X;
            velocity.X = targetX;

            // Check sol
            if (isOnGround)
            {
                velocity.Y = 0;
                position.Y = Gravity.GroundPositionY - hb.Height;

                // Saut
                if (kstate.IsKeyDown(Keys.W) && !jumpPressedLastFrame)
                    velocity.Y -= Speed.Y;
            }
            else
                Gravity.Apply(ref velocity, dt);

            // Sortie
            jumpPressedLastFrame = kstate.IsKeyDown(Keys.W);
            position += velocity;
        }
    }
}
