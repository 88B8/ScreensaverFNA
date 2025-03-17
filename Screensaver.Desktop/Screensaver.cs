﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Screensaver.BL.Contracts;
using Screensaver.BL.Contracts.Models;

namespace Screensaver.Desktop
{
    public class Screensaver : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly ISnowflakeManager snowflakeManager;
        private SpriteBatch spriteBatch;
        private Texture2D backgroundTexture;
        private Texture2D snowflakeTexture;
        private KeyboardState keyboardState;

        public Screensaver(ISnowflakeManager snowflakeManager) //This is the constructor, this function is called whenever the game class is created.
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            this.snowflakeManager = snowflakeManager;
        }

        /// <summary>
        /// This function is automatically called when the game launches to initialize any non-graphic variables.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Automatically called when your game launches to load any game assets (graphics, audio etc.)
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("winter_village");
            snowflakeTexture = Content.Load<Texture2D>("snowflake");

            snowflakeManager.GenerateSnowflakes();
        }

        /// <summary>
        /// Called each frame to update the game. Games usually runs 60 frames per second.
        /// Each frame the Update function will run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            snowflakeManager.MoveSnowflakes();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game is ready to draw to the screen, it's also called each frame.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            DrawSnowflakes();
            spriteBatch.End();

            //Draw the things FNA handles for us underneath the hood:
            base.Draw(gameTime);
        }

        /// <summary>
        /// Рисует снежинки
        /// </summary>
        private void DrawSnowflakes()
        {
            foreach (var snowflake in snowflakeManager.GetSnowflakes())
            {
                spriteBatch.Draw(snowflakeTexture, new Rectangle(snowflake.X, snowflake.Y, snowflake.Size, snowflake.Size), Color.White);
            }
        }
    }
}
