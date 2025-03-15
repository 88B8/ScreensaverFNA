using Microsoft.Xna.Framework.Graphics;

namespace Screensaver.BL.Contracts
{
    /// <summary>
    /// Менеджер по управлению <see cref="Snowflake"/>
    /// </summary>
    public interface ISnowflakeManager
    {
        /// <summary>
        /// Генерирует снежинки
        /// </summary>
        void GenerateSnowflakes();

        /// <summary>
        /// Двигает снежинки
        /// </summary>
        void MoveSnowflakes();

        /// <summary>
        /// Рисует снежинки
        /// </summary>
        void DrawSnowflakes(SpriteBatch spriteBatch);
    }
}