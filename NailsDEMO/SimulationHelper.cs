namespace NailsDEMO
{
    internal static class SimulationHelper
    {
        public static void PrintProgressBar(double percentage, int size)
        {
            int FillAmount = Convert.ToInt32(size * percentage);

            Console.Write("\x1b[5;1H\x1b[38;2;25;255;25m");

            for (int i = 0; i < FillAmount; i++)
            {
                Console.Write("*");
            }
            Console.Write("\x1b[38;2;255;25;25m");
            for (int i = FillAmount; i < 30; i++)
            {
                Console.Write("*");
            }
            Console.Write("\x1b[m");
        }
    }
}
