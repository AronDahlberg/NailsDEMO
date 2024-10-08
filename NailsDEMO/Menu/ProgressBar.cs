namespace NailsDEMO.Menu
{
    internal class ProgressBar (int size)
    {
        public int Size { get; set; } = size;

        public void PrintProgressBar(double percentage)
        {
            int FillAmount = Convert.ToInt32(Size * percentage);

            Console.Write("\x1b[1;1H\x1b[38;2;25;255;25m");

            for (int i = 0; i < FillAmount; i++)
            {
                Console.Write("*");
            }
            Console.Write("\x1b[38;2;255;25;25m");
            for (int i = FillAmount; i < Size; i++)
            {
                Console.Write("*");
            }
            Console.Write("\x1b[m");
        }
    }
}
