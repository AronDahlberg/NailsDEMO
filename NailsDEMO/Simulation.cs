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

                double modulo = AmountOfSimulationDays < 100? 1 : (AmountOfSimulationDays / 100);

                if (i % modulo == 0)
                {
                    completionPercentage = (double)i / (double)AmountOfSimulationDays;

                    SimulationHelper.PrintProgressBar(completionPercentage, 30);
                }
            }

            Date = Date.AddDays(AmountOfSimulationDays);

            Console.Write(MenuHelper.ClearScreen +
                $"{AmountOfSimulationDays} days have passed\n" +
                $"Current date is: {Date.ToLongDateString()}\n" +
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
