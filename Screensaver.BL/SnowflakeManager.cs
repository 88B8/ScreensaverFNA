using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Screensaver.BL.Contracts;
using Screensaver.BL.Contracts.Models;
using System;
using System.Collections.Generic;

namespace Screensaver.BL
{
    /// <inheritdoc cref="ISnowflakeManager"/>

    public class SnowflakeManager : ISnowflakeManager
    {
        private int screenWidth;
        private int screenHeight;
        private static Random rand = new Random();
        private readonly List<Snowflake> snowflakes = new List<Snowflake>();
        private Texture2D snowflakeTexture;
        private const int SnowflakeCount = 50;
        private const int SnowflakeMaxSpeed = 6;
        private const int SnowflakeSizeStep = 5;

        /// <summary>
        /// Инициализирует новый экземляр <see cref="SnowflakeManager"/>
        /// </summary>
        public SnowflakeManager(int screenWidth, int screenHeight, Texture2D snowflakeTexture)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.snowflakeTexture = snowflakeTexture;
        }

        public void GenerateSnowflakes()
        {
            for (var i = 0; i < SnowflakeCount; i++)
            {
                snowflakes.Add(new Snowflake
                {
                    X = rand.Next(screenWidth),
                    Y = rand.Next(screenHeight),
                    Size = rand.Next(1, SnowflakeMaxSpeed / SnowflakeSizeStep) * SnowflakeSizeStep,
                });
            }
        }

        public void MoveSnowflakes()
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Y += SnowflakeMaxSpeed - snowflake.Size + SnowflakeSizeStep;

                if (snowflake.Y >= screenHeight)
                {
                    snowflake.Y = -snowflake.Size;
                    snowflake.X = rand.Next(screenWidth);
                }
            }
        }

        public void DrawSnowflakes(SpriteBatch spriteBatch)
        {
            foreach (var snowflake in snowflakes)
            {
                spriteBatch.Draw(snowflakeTexture, new Rectangle(snowflake.X, snowflake.Y, snowflake.Size, snowflake.Size), Color.White);
            }
        }
    }
}