namespace NailsDEMO.Menu
{
    internal class SimulationMenu(Simulation simulation) : BaseMenu(simulation)
    {
        public override void Run()
        {
            Console.Write(MenuHelper.ClearScreen +
                $"r: Run\n" +
                $"1: Edit amount of days to simulate, currently: {simulation.AmountOfSimulationDays}\n" +
                $"2: Edit progress bar size, currently: {simulation.ProgressBar.Size} of maximum [100]\n" +
                $"b: Back\n" +
                "> ");

            string? input = Console.ReadLine();
            int value; // used differently in multiple places

            switch (input)
            {
                case "b": simulation.ChangeMenu(new MainMenu(simulation)); break;

                case "r": simulation.Simulate(); break;

                case "1":
                    if (int.TryParse(MenuHelper.GetUserInput(), out value))
                    {
                        simulation.AmountOfSimulationDays = value;
                    }
                    break;

                case "2":
                    if (int.TryParse(MenuHelper.GetUserInput(), out value))
                    {
                        if(value < 1 || value > 100)
                        {
                            return;
                        }
                        simulation.ProgressBar.Size = value;
                    }
                    break;
            }
        }
    }
}
