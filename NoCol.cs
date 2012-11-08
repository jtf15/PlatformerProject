// NolCol.cs
//Using declarations
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace PlatformerProject
{
    class NoCol
    {
        /// <summary>
        /// This class will simply be used to store many non-collidable background objects
        /// No collision or anythign else is needed.
        ///</summary>
        Texture2D picture;
        Vector2 position;
        float width, height;
        SpriteBatch batch;
        bool active;
        
        public NoCol(Texture2D picture, Vector2 position, SpriteBatch batch)
        {
            this.picture = picture; // The sprite
            this.position = position; // Where the sprite will be drawn
            this.width = picture.Width; // the width of the sprite
            this.height = picture.Height; //the height of the sprite
            this.batch = batch;           // Get the batch so we can draw in this Class
            
        }

        public void drawNoCol()
        {
            batch.Draw(picture, position, Color.White) ;
        }

        public void incrementPosition(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

       

    }
}
