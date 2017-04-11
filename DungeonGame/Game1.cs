using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //The background image 
        Texture2D background;
        Vector2 backgroundPos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }



        protected override void Initialize()
        {
            backgroundPos = Vector2.Zero; // sets the location of bgpos to Y0, X0

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
          
            //loads the background image.
            background = Content.Load<Texture2D>("bg2");
        }



        protected override void UnloadContent()
        {
          
        }

//Update
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Get the keyboard inputs from the user. 
            KeyboardState state = Keyboard.GetState();
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveSpeed = 1000.0f;

            if (state.IsKeyDown(Keys.Down))
            {
                backgroundPos.Y += moveSpeed * time ;
            }

            if (state.IsKeyDown(Keys.Up))
            {
                backgroundPos.Y -= moveSpeed * time;
            }

            if (state.IsKeyDown(Keys.Left))
            {
                backgroundPos.X -= moveSpeed * time;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                backgroundPos.X += moveSpeed * time;
            }


            base.Update(gameTime);
        }



        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //start
            spriteBatch.Begin();

                spriteBatch.Draw(background, backgroundPos, Color.White);
            //end
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
