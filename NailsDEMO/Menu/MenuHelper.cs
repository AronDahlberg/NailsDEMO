namespace NailsDEMO.Menu
{
    internal static class MenuHelper
    {
        public static string ClearScreen { get; } = "\x1b[m\x1b[2J\x1b[H"; // ANSI ESC Code

        public static string? GetUserInput()
        {
            Console.WriteLine(ClearScreen +
                "Input value:");

            return Console.ReadLine();
        }
    }
}
