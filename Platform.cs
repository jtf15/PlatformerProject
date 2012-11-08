using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerProject
{
    class Platform : Collidable
    {
        /// <summary>
        /// This class is going to be used to hold all of the current platforms on the screen.
        /// It will have placement, size of the platforms, and will also store the image for it's respective
        /// platform
        ///</summary>
        
        // This will be the image that we need to draw
        Texture2D picture;
        
        // This will be the position where it will be drawn
        public Vector2 position;
        
        // The width and the height, in order to calculate hitbox
        public float width, height;
        
        // The rectancle surrounding the object, will be used for collision
        public Rectangle hitbox;
        
        // The batch, will be used to draw!
        SpriteBatch batch;
        
        //The scale we wish for the platform to be drawn
        float scale;

        public Platform(Texture2D picture, Vector2 position, SpriteBatch batch, float scale)
        {
            this.picture = picture;     // The picture to be drawn
            this.position = position;   // The position to where it will be drawn
            this.width = picture.Width * scale; // Width of the picture
            this.height = picture.Height * scale; //Height of the sprite
            hitbox = new Rectangle((int)position.X, (int)position.Y, (int)this.width, (int)this.height); //This hitbox is the rectangle that is surrounding the sprite
            this.batch = batch; // Getting the batch so that we can draw in this funtion
            this.scale = scale; // In case we need to scale (in example, for the floor). 

        }


        public void drawNoCol()
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, (int)this.width, (int)this.height);
            batch.Draw(picture, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

        }


    }
}
