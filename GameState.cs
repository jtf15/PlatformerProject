using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * This is the GameState class, which will be used to keep track of the state of the game. In other
 * words if the game is currently in play mode the GameState will switch to PlayState. Or if the user 
 * is in the menu the GameState will be in MenuState.
 * 
 * 
 *********************
 *Behaviors of states*
 *********************
 *
 * TitleState
 * -brings up the title screen to begin game
 * -will intialize character and game once start is chosen
 * -state will then switch to PlayState
 * 
 * PlayState
 * -game will continously run and character will react to buttons
 * 
 * MenuState
 * -game pauses so character and enemies will freeze while in menu
 * -this state will also bring up the menu screen
 * */
namespace PlatformerProject
{
    class GameState
    {
        enum State {TitleState,
                    PlayState,
                    MenuState};

        State currentState;

        public GameState()
        {
            //Intializes the GameState to TitleScreen when game starts
             currentState = State.PlayState;    //switch to TitleState once a title screen is made
        }

        public State getCurrentState()
        {
            //get the current game state
            return currentState;
        }

        public void setCurrentState(State state)
        {
            //changes the current game state to new current one
            currentState = state; 
        }

    }
}
