using Screensaver.BL.Contracts.Models;
using System.Collections.Generic;

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
        /// Возращает список снежинок
        /// </summary>
        IEnumerable<Snowflake> GetSnowflakes();
    }
}