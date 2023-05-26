namespace Entity.Utils
{
    public static class Utils
    {
        private static object consoleLock = new object();

        public static void WriteLineWithColor(string message, ConsoleColor color)
        {
            lock (consoleLock)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}
