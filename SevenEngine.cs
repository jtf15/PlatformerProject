using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
