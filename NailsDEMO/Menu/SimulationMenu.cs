namespace NailsDEMO.Menu
{
    internal class SimulationMenu(Simulation simulation) : BaseMenu(simulation)
    {
        public override void Run()
        {
            Console.Write(MenuHelper.ClearScreen +
                $"b: Back\n" +
                $"r: Run\n" +
                $"1: Edit amount of days to simulate (Currently: {simulation.AmountOfSimulationDays})\n");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "b": simulation.ChangeMenu(new MainMenu(simulation)); break;

                case "r": simulation.Simulate(); break;

                case "1":
                    if (int.TryParse(MenuHelper.GetUserInput(), out int value))
                    {
                        simulation.AmountOfSimulationDays = value;
                    }
                    break;
            }
        }
    }
}
