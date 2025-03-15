namespace Screensaver.BL.Contracts.Models
{
    /// <summary>
    /// Модель настроек падения <see cref="Snowflake"/>
    /// </summary>
    public class SnowflakeSettings
    {
        /// <summary>
        /// Количество снежинок
        /// </summary>
        public int SnowflakeCount { get; set; } = 500;

        /// <summary>
        /// Минимальная скорость падения снежинок
        /// </summary>
        public int SnowflakeMinSpeed { get; set; } = 1;

        /// <summary>
        /// Максимальная скорость падения снежинок
        /// </summary>
        public int SnowflakeMaxSpeed { get; set; } = 2;

        /// <summary>
        /// Шаг падения снежинки
        /// </summary>
        public int SnowflakeSizeStep { get; set; } = 5;
    }
}
