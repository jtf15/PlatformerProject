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
        Vector2 getPosition();
        int getWidth();
        int getHeight();
        Rectangle getHitbox();
    }
}
