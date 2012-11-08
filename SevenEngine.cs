using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformerProject
{
    class SevenEngine
    {

        public bool rightCollide(Collidable player, Collidable second)
        {
            if (player.position.X >= second.position.X && player.position.X >= (second.position.X + second.width))
            {
                return true;
            }
           return false;
         }

        public bool aboveCollide(Collidable player, Collidable second)
        {
            if ((second.position.Y - player.position.Y) >= 30 && (second.position.Y - player.position.Y) <= 35)
            {
                return true;
            }
            return false;
        }




    }
}
