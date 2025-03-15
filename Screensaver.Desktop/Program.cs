namespace Screensaver.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Screensaver screensaver = new Screensaver())
            {
                screensaver.Run();
            }
        }
    }
}