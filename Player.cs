﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Animation.cs
//Using declaration
using Microsoft.Xna.Framework.Content;
namespace PlatformerProject
{
    class Player : Collidable
    { 
        // Animation representing the player
        //public Texture2D PlayerTexture;

        // Animation representing the player
        public Animation PlayerAnimation;

        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position;

        public int Health;

        // State of the player
        public bool Active;

        public Rectangle hitbox ;
        

        // Get the width of the player ship
        public int Width
        {
            get { return PlayerAnimation.FrameWidth; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return PlayerAnimation.FrameHeight; }
        }


        // Initialize the player
        public void Initialize(Animation animation, Vector2 position)
        {
            PlayerAnimation = animation;

            // Set the starting position of the player around the middle of the screen and to the back
            Position = position;

            hitbox = new Rectangle((int)position.X, (int)position.Y, (int)this.Width, (int)this.Height);
            // Set the player to be active
            Active = true;
        }

        // Update the player animation
        public void Update(GameTime gameTime)
        {
            PlayerAnimation.Position = Position;
            PlayerAnimation.Update(gameTime);
        }

        // Draw the player
        public void Draw(SpriteBatch spriteBatch)
        {
            hitbox = new Rectangle((int)Position.X, (int)Position.Y, (int)this.Width, (int)this.Height);
            PlayerAnimation.Draw(spriteBatch);
        }

        public Vector2 getPosition()
        {
            return Position;
        }

        public int getWidth()
        {
            return Width;
        }

        public int getHeight()
        {
            return Height;
        }
    }
}
