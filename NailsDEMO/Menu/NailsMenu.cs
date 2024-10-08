using System.Text.RegularExpressions;

namespace NailsDEMO.Menu
{
    internal class NailsMenu(Simulation simulation, Human human) : BaseMenu(simulation)
    {
        private Human ThisHuman { get; set; } = human;

        public override void Run()
        {
            Console.Write(MenuHelper.ClearScreen);
            
            DisplayNailTable();

            Console.Write(
                "\nb: Back\n" +
                "Input F or T + index of nail to edit it\n");

            string? input = Console.ReadLine();
            int value; // used differently in multiple places

            if (input == null || !input.Any()) { return; }

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

        private void DisplayNailTable()
        {
            string format = "| {0,-2} | {1,-19} | {2,-9} |\n";

            string header = String.Format(format, "ID", "Position", "Length mm");


            for (int i = 0; i < header.Length; i++)
            {
                Console.Write("-");
            }

            Console.Write("\n");

            PrintNails(ThisHuman.FingerNails, format);
            PrintNails(ThisHuman.ToeNails, format);

            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
            }
        }

        private void PrintNails(List<Nail> nails, string format)
        {
            int index = 0;
            foreach (Nail nail in nails)
            {
                string nailPosition = Enum.GetName((NailPosition)nail.NailPosition) ?? "";

                nailPosition = Regex.Replace(nailPosition, "(?<!^)([A-Z])", " $1");

                string posMessage = $"{Enum.GetName((LimbPosition)nail.NailLimbPosition)} {nailPosition}";

                string lengthMessage = $"{nail.NailLength:F2}";

                Console.Write(format, $"F{index}", posMessage, lengthMessage);
                index++;
            }
        }
    }
}
