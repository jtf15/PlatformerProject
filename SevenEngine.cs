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
            if (player.getPosition().X >= second.getPosition().X && player.getPosition().X <= (second.getPosition().X + second.getWidth()))
            {
                return true;
            }
           return false;
         }

        public bool isOnTopOf(Collidable player, Collidable second)
        {
            if (rightCollide(player, second) && aboveCollide(player, second)) 
            {
                return true ;
            }
            
            return false ;
        }


        public bool aboveCollide(Collidable player, Collidable second)
        {
            if ((second.getPosition().Y - player.getPosition().Y) >= 0 && (second.getPosition().Y - player.getPosition().Y) <= 35)
            {
                return true;
            }
            return false;
        }

        



    }
}
