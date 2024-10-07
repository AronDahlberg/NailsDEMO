using NailsDEMO.Menu;

namespace NailsDEMO
{
    internal class Simulation
    {
        public List<Human> Humans { get; set; }
        public DateOnly Date { get; set; } = new DateOnly(1, 1, 1);
        private bool Running { get; set; } = true;
        private BaseMenu Menu { get; set; }
        public int AmountOfSimulationDays { get; set; } = 50;

        public Simulation(List<Human> humans)
        {
            Humans = humans;
            Menu = new MainMenu(this);
        }
        public void Run()
        {
            while (Running)
            {
                Menu.Run();
            }
        }
        public void Simulate()
        {
            double completionPercentage;

            for (int i = 0; i < AmountOfSimulationDays; i++)
            {
                foreach (Human human in Humans)
                {
                    human.SimulateNewDay();
                }

                try
                {
                    if (i % (AmountOfSimulationDays / 100) == 0)
                    {
                        completionPercentage = (double)i / (double)AmountOfSimulationDays;

                        PrintProgressBar(completionPercentage, 30);
                    }
                }
                catch (DivideByZeroException) {}
            }

            Date = Date.AddDays(AmountOfSimulationDays);

            Console.Write(MenuHelper.ClearScreen +
                $"{AmountOfSimulationDays} days have passed\n" +
                $"Current date is: {Date.ToLongDateString()}\n" +
                $"Press any key to continue\n");

            Console.ReadKey();
        }
        private void PrintProgressBar(double percentage, int size)
        {
            int FillAmount = Convert.ToInt32(size * percentage);

            Console.Write("\x1b[5;1H\x1b[38;2;25;255;25m");
            
            for(int i = 0; i < FillAmount; i++)
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
        public void ChangeMenu(BaseMenu menu)
        {
            Menu = menu;
        }
        public void Exit()
        {
            Running = false;
        }
    }
}
