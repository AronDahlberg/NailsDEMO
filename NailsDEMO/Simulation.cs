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

            Console.Write(MenuHelper.ClearScreen);

            ProgressBar.PrintProgressBar(0);

            for (int i = 0; i < AmountOfSimulationDays; i++)
            {
                foreach (Human human in Humans)
                {
                    human.SimulateNewDay();
                }

                modulo = AmountOfSimulationDays < 100? 1 : (AmountOfSimulationDays / 100);

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

            string dateMessage = Date != default
                                ? Date.ToLongDateString()
                                : "over year 9999";

            Console.Write(
                $"\n{AmountOfSimulationDays} days have passed\n" +
                $"Current date is: {dateMessage}\n" +
                $"Press any key to continue\n");

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
