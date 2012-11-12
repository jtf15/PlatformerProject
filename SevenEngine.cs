using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
/*
 * Current Problems with the Seven Physics Engine
 * -Going foward when not colliding with a Collidable Object
 * -Cannot jump if there is a collidable object above the player
 *          *doesn't seem to take into account the x value of the player and object
 * -Animation bug, keep walking while running into wall, but if user lets go of 'D' 
 *                  then animation will stop looping if they press D again
 * -Comments :), I was just a little confused if rightCollision and aboveCollision are in perspective
 *               to the player or the object colliding with the player
 * 
 * I know all of these are pretty easy fixes just thought listing them would help us work through it
 * 
 * Also, GRATZ MAKING IT THROUGH WORK!!!!
 */

namespace PlatformerProject
{
    class SevenEngine
    {

        public bool rightCollide(Collidable player, ArrayList second)
        {
            foreach (Platform i in second)
                if(player.getPosition().X >= i.getPosition().X && player.getPosition().X <= (i.getPosition().X + i.getWidth()))
                {
                     return true;
                }
           return false;
         }

      

        public bool isOnTopOf(Collidable player, ArrayList second)
        {
            if (rightCollide(player, second) && aboveCollide(player, second)) 
            {
                return true ;
            }
            
            return false ;
        }


        public bool aboveCollide(Collidable player, ArrayList second)
        {
            foreach(Platform i in second)
                if ((i.getHitbox().Top - player.getPosition().Y) >= 0 && (i.getHitbox().Top - player.getPosition().Y) <= 30)
                {
                    return true;
                }
            return false;
        }

    }
}
