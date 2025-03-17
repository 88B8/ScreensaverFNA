using Microsoft.Xna.Framework.Graphics;
using Screensaver.BL;
using Screensaver.BL.Contracts;

namespace Screensaver.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            GraphicsAdapter adapter = GraphicsAdapter.DefaultAdapter;
            int screenWidth = adapter.CurrentDisplayMode.Width;
            int screenHeight = adapter.CurrentDisplayMode.Height;

            ISnowflakeManager snowflakeManager = new SnowflakeManager(screenWidth, screenHeight);
            using (Screensaver screensaver = new Screensaver(snowflakeManager))
            {
                screensaver.Run();
            }
        }
    }
}