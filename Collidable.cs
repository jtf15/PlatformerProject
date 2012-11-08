using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Animation.cs
//Using declaration
using Microsoft.Xna.Framework.Content;

namespace PlatformerProject
{
    interface Collidable
    {
        public Vector2 position;
        public float width, height;
    }
}
