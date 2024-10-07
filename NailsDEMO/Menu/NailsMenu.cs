namespace NailsDEMO.Menu
{
    internal class NailsMenu(Simulation simulation, Human human) : BaseMenu(simulation)
    {
        private Human ThisHuman { get; set; } = human;
        public override void Run()
        {
            Console.Write(MenuHelper.ClearScreen +
                "b: Back\n" +
                "Input F or T + index of nail to edit it\n");

            for (int i = 0; i < ThisHuman.FingerNails.Count; i++)
            {
                Console.WriteLine($"F{i}: {ThisHuman.FingerNails[i]}");
            }
            for (int i = 0; i < ThisHuman.ToeNails.Count; i++)
            {
                Console.WriteLine($"T{i}: {ThisHuman.ToeNails[i]}");
            }

            string? input = Console.ReadLine();
            int value; // used differently in multiple places

            if (input == null) { return; }

            if (input == "b")
            {
                simulation.ChangeMenu(new EditHumanMenu(simulation, ThisHuman));
                return;
            }

            if (input[0] == 'F' && int.TryParse(input.AsSpan(1), out value))
            {
                var nail = ThisHuman.FingerNails.ElementAtOrDefault(value);

                if (nail != default)
                {
                    simulation.ChangeMenu(new EditNailMenu(simulation, nail, ThisHuman));
                }

                return;
            }

            if (input[0] == 'T' && int.TryParse(input.AsSpan(1), out value))
            {
                var nail = ThisHuman.ToeNails.ElementAtOrDefault(value);

                if (nail != default)
                {
                    simulation.ChangeMenu(new EditNailMenu(simulation, nail, ThisHuman));
                }

                return;
            }
        }
    }
}
