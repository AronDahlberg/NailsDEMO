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
        public ProgressBar ProgressBar { get; set; } = new(30);

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
            double modulo;

            DateOnly startDate = new DateOnly(Date.Year, Date.Month, Date.Day);

            Console.Write(MenuHelper.ClearScreen);

            ProgressBar.PrintProgressBar(0);

            for (int i = 0; i < AmountOfSimulationDays; i++)
            {
                foreach (Human human in Humans)
                {
                    human.SimulateNewDay();
                }

                modulo = AmountOfSimulationDays < 100 ? 1 : (AmountOfSimulationDays / ProgressBar.Size);

                if (i % modulo == 0)
                {
                    completionPercentage = (double)i / (double)AmountOfSimulationDays;

                    ProgressBar.PrintProgressBar(completionPercentage);
                }
            }

            ProgressBar.PrintProgressBar(1);

            try
            {
                Date = Date.AddDays(AmountOfSimulationDays);
            }
            catch (ArgumentOutOfRangeException)
            {
                Date = default;
            }

            PrintResult(startDate);
            ResetCutCounter();
        }

        private void ResetCutCounter()
        {
            foreach(var human in Humans)
            {
                human.AmountOfCuts = 0;
            }
        }

        private void PrintResult(DateOnly startDate)
        {
            string dateMessage = Date != default
                                      ? Date.ToLongDateString()
                                      : "over year 9999";

            Console.Write(
                $"\nSimulation started {startDate.ToLongDateString()}" +
                $"\nCurrent date is {dateMessage}" +
                $"\nSimulation took {AmountOfSimulationDays} days\n\n");

            foreach(var human in Humans)
            {
                Console.WriteLine($"{human.Name} cut their nails {human.AmountOfCuts} times.");
                Console.WriteLine($"Death log for {human.Name}: ");

                if (human.DeathLog.Count == 0)
                {
                    Console.WriteLine($"    {human.Name} never died");
                }
                foreach(var log in human.DeathLog)
                {
                    Console.WriteLine($"    {log}");
                }

                Console.Write("\n");
            }

            Console.Write($"Press any key to continue\n");
            Console.ReadKey();
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
