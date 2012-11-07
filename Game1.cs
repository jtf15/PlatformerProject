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
        //This is the input handler for our program
        KeyboardState currentKeyboardState;
        KeyboardState oldKeyboardState;
           

        //These are 2D textures that are drawn onto the screen
        Texture2D mainbackground;   //The main backgorund
        Texture2D nocol;            //Testing non-collision tree

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
            //Load the player and his animations
            Animation playerAnimation = new Animation();
            
            Texture2D playerTexture = Content.Load<Texture2D>("kidright");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 32, 64, 4, 110, Color.White, 1f, false);
            
            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y
            + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            player.Initialize(playerAnimation, playerPosition);
           
            // TODO: use this.Content to load your game content here
            mainbackground = Content.Load<Texture2D>("background");
            nocol = Content.Load<Texture2D>("treeSmall");

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

            // TODO: Add your update logic here

            base.Update(gameTime);
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
            spriteBatch.Draw(nocol, new Vector2(400,175), Color.White);     //Draw the tree
            
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

       private void UpdatePlayer(GameTime gameTime)
        {
            player.Update(gameTime); 
           
           currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                
                    player.PlayerAnimation.Looping = true;
                    player.Position.X += playerMoveSpeed;
                
            }
           
            if (oldKeyboardState.IsKeyDown(Keys.D) && currentKeyboardState.IsKeyUp(Keys.D))
            {
                player.PlayerAnimation.Looping = false;
            }

            player.Position.X = MathHelper.Clamp(player.Position.X, 0, GraphicsDevice.Viewport.Width - player.Width);
            player.Position.Y = MathHelper.Clamp(player.Position.Y, 0, GraphicsDevice.Viewport.Height - player.Height);




            oldKeyboardState = currentKeyboardState;
        }


       



        
    }
}
