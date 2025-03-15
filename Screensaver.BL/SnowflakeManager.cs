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
        private readonly int screenWidth;
        private readonly int screenHeight;
        private static readonly Random rand = new Random();
        private readonly List<Snowflake> snowflakes = new List<Snowflake>();
        private readonly Texture2D snowflakeTexture;
        private readonly SnowflakeSettings settings = new SnowflakeSettings();

        /// <summary>
        /// Инициализирует новый экземляр <see cref="SnowflakeManager"/>
        /// </summary>
        public SnowflakeManager(int screenWidth, int screenHeight, Texture2D snowflakeTexture)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.snowflakeTexture = snowflakeTexture ?? throw new ArgumentNullException();
        }

        public void GenerateSnowflakes()
        {
            snowflakes.Clear();

            int maxDivisor = Math.Max(2, settings.SnowflakeMaxSpeed / settings.SnowflakeSizeStep);

            for (var i = 0; i < settings.SnowflakeCount; i++)
            {
                snowflakes.Add(new Snowflake
                {
                    X = rand.Next(screenWidth),
                    Y = rand.Next(screenHeight),
                    Size = rand.Next(1, maxDivisor) * settings.SnowflakeSizeStep,
                });
            }
        }

        public void MoveSnowflakes()
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Y += GetSnowflakeSpeed(snowflake);

                if (snowflake.Y >= screenHeight)
                {
                    ResetSnowflake(snowflake);
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

        /// <summary>
        /// Возвращает снежинку наверх экрана
        /// </summary>
        private void ResetSnowflake(Snowflake snowflake)
        {
            snowflake.Y = -snowflake.Size;
            snowflake.X = rand.Next(screenWidth);
        }

        /// <summary>
        /// Рассчитывает скорость <see cref="Snowflake"/>
        /// </summary>
        private int GetSnowflakeSpeed(Snowflake snowflake)
        {
            int calculatedSpeed = settings.SnowflakeMaxSpeed - snowflake.Size + settings.SnowflakeSizeStep;
            calculatedSpeed = Math.Min(settings.SnowflakeMaxSpeed, Math.Max(settings.SnowflakeMinSpeed, calculatedSpeed)); //Math.Clamp

            return calculatedSpeed;
        }
    }
}