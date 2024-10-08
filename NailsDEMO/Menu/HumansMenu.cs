namespace NailsDEMO.Menu
{
    internal class HumansMenu(Simulation simulation) : BaseMenu(simulation)
    {
        public override void Run()
        {
            Console.Write(MenuHelper.ClearScreen);

            for (int i = 0; i < simulation.Humans.Count; i++)
            {
                Console.WriteLine($"{i}: {simulation.Humans[i]}");
            }

            Console.Write("Input index of human to edit them\n" +
               "Input 'd' + index of human to delete them\n" +
               "a: Add human\n" +
               "b: Back\n" +
               "> ");

            string? input = Console.ReadLine();
            int value; // used differently in multiple places

            if (input == null || !input.Any()) { return; }

            if (input == "b")
            {
                simulation.ChangeMenu(new MainMenu(simulation));
                return;
            }

            if (input == "a")
            {
                simulation.ChangeMenu(new HumanCreationMenu(simulation));
                return;
            }

            if (int.TryParse(input, out value))
            {
                var human = simulation.Humans.ElementAtOrDefault(value);

                if (human != default)
                {
                    simulation.ChangeMenu(new EditHumanMenu(simulation, human));
                }

                return;
            }

            if (input[0] == 'd' && int.TryParse(input.AsSpan(1), out value))
            {
                simulation.Humans.RemoveAt(value);
            }

        }
    }
}
