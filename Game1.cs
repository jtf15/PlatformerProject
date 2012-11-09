using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

/*
 * Platformer Project 
 * By:  Josh Frey
 *      Derek Bitterman
 *      Derek Ness
 * */

namespace PlatformerProject
{
    
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        float playerMoveSpeed;

       //This enumeration is used to keep track of the state
        //it will restrict updating to the proper components of the game
        //this would allow the game to appear frozen if in menu
        public enum State
        {
            TitleState,
            PlayState,
            MenuState
        };

        State currentState;

        //This is the input handler for our program
        KeyboardState currentKeyboardState;
        KeyboardState oldKeyboardState;

        GamePadState currentGamePadState;
        GamePadState oldGamePadState;

        //Title Screen Texture
        Texture2D titleScreen;
           

        //These are 2D textures that are drawn onto the screen
        Texture2D mainbackground;   //The main backgorund
        Texture2D nocol;            //Testing non-collision tree
        Platform platform;
       
        
        //This is the menu screen used to choose options
        Texture2D menuScreen;
        NoCol mousePointer;
        int mouseCounter = 0;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {   
            // TODO: Add your initialization logic here
            player = new Player();
            playerMoveSpeed = 3.0f;
           
            currentState = State.TitleState;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //Load Title Screen
            titleScreen = Content.Load<Texture2D>("Titlescreen");

            //Load the player and his animations
            Animation playerAnimation = new Animation();
            Texture2D playerTexture = Content.Load<Texture2D>("kidright");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 33, 64, 4, 80, Color.White, 1f, false);
            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 20f, GraphicsDevice.Viewport.TitleSafeArea.Y
            + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            player.Initialize(playerAnimation, playerPosition);
            
            //all of these are our test images to be used for now
            //later we will replace with the actual game textures
            mainbackground = Content.Load<Texture2D>("quickSky");
            nocol = Content.Load<Texture2D>("treeSmall");
            menuScreen = Content.Load<Texture2D>("quickMenu");
            platform = new Platform(Content.Load<Texture2D>("platform"), new Vector2(0f, 400f), spriteBatch, 2f);
            mousePointer = new NoCol(Content.Load<Texture2D>("menuArrow"), new Vector2(280f, 260f), spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            UpdatePlayer(gameTime);
            base.Update(gameTime);
        }

        private void UpdateCollision()
        {

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            //Starts the sprite batch
            //Will be drwan in order, so things on bottom layer should be called first
            spriteBatch.Begin();

            spriteBatch.Draw(mainbackground, Vector2.Zero, Color.White);    //Draw the main background    
            
             //This is the overload method that will work with scaling we would just need to make an alternate draw method for scaling. 
            if (currentState == State.PlayState || currentState == State.MenuState)
            {
                platform.drawNoCol();
                player.Draw(spriteBatch);

                if (currentState == State.MenuState)
                {
                    spriteBatch.Draw(menuScreen, new Vector2(200, 200), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
                    mousePointer.drawNoCol();
                }
            }
            //Will draw the menu only if the game is currently in the MenuState
           
            if(currentState == State.TitleState)
            {
                spriteBatch.Draw(titleScreen, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, .75f, SpriteEffects.None, 0f);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

       private void UpdatePlayer(GameTime gameTime)
        {
            player.Update(gameTime);

            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

//*********************************************************************************************************************************************
//************************************************* CONTROL FOR PLAYSTATE *********************************************************************
//*********************************************************************************************************************************************
           if(currentState == State.PlayState)
            {
                if (((platform.position.Y - player.Position.Y) >= 30 && (platform.position.Y - player.Position.Y) <= 35) &&
                     player.Position.X >= platform.position.X && player.Position.X <= (platform.position.X + platform.width + 10f))
                {
                    if (currentKeyboardState.IsKeyDown(Keys.D))
                    {

                        player.PlayerAnimation.Looping = true;
                        
                            player.Position.X += playerMoveSpeed;

                    }

                    //if D is released stop moving
                    if (oldKeyboardState.IsKeyDown(Keys.D) && currentKeyboardState.IsKeyUp(Keys.D))
                    {
                        player.PlayerAnimation.Looping = false;
                    }

                    //if m is pressed stop moving and switch to MenuState
                    if ((oldKeyboardState.IsKeyDown(Keys.M) && currentKeyboardState.IsKeyUp(Keys.D)) || currentGamePadState.Buttons.Y == ButtonState.Pressed)
                    {
                        player.PlayerAnimation.Looping = false;
                        currentState = State.MenuState;
                    }
                }
                else
                {
                    player.PlayerAnimation.Looping = false;
                    player.Position.Y += playerMoveSpeed;
                    player.Position.X += playerMoveSpeed;
                }
              
            }
//*********************************************************************************************************************************************
//************************************************* CONTROL FOR MENUSTATE *********************************************************************
//*********************************************************************************************************************************************
           else if (currentState == State.MenuState)
           {
               //if c is pressed go back to the PlayState
               if ((oldKeyboardState.IsKeyDown(Keys.C) && currentKeyboardState.IsKeyUp(Keys.C)) || currentGamePadState.Buttons.B == ButtonState.Pressed)
               {
                   currentState = State.PlayState;
               }
               //if d is pressed move menu arrow left, but only if it is currently on continue option
               if ((oldKeyboardState.IsKeyDown(Keys.D) && currentKeyboardState.IsKeyUp(Keys.D)) || currentGamePadState.DPad.Right == ButtonState.Pressed && mouseCounter == 0)
               {
                   mousePointer.incrementPosition(100f, 0f);
                   mouseCounter = 1;

               }

               //if a is pressed move menu arrow right, but only if it is currently on exit option
               if ((oldKeyboardState.IsKeyDown(Keys.A) && currentKeyboardState.IsKeyUp(Keys.A)) || currentGamePadState.DPad.Left == ButtonState.Pressed && mouseCounter == 1)
               {
                   mousePointer.incrementPosition(-100f, 0f);
                   mouseCounter = 0;
               }
           }
 //*********************************************************************************************************************************************
 //************************************************* CONTROL FOR TITLESTATE *********************************************************************
 //*********************************************************************************************************************************************
           else if(currentState == State.TitleState)
           {
               if (oldKeyboardState.IsKeyDown(Keys.Enter) && currentKeyboardState.IsKeyUp(Keys.Enter))
               {
                   currentState = State.PlayState;
               }

           }
//*********************************************************************************************************************************************
//************************************************* END OF CONTROL SECTION ********************************************************************
//*********************************************************************************************************************************************
           
            player.Position.X = MathHelper.Clamp(player.Position.X, 0, GraphicsDevice.Viewport.Width - player.Width);
            player.Position.Y = MathHelper.Clamp(player.Position.Y, 0, GraphicsDevice.Viewport.Height - player.Height);




            oldKeyboardState = currentKeyboardState;
            oldGamePadState = currentGamePadState;
        }


       



        
    }
}
