using System.Text.RegularExpressions;

namespace NailsDEMO.Menu
{
    internal class NailsMenu(Simulation simulation, Human human) : BaseMenu(simulation)
    {
        private Human ThisHuman { get; set; } = human;
        public override void Run()
        {
            Console.Write(MenuHelper.ClearScreen);

            string format = "| {0,-2} | {1,-19} | {2,-9} |\n";

            Console.Write(format, "ID", "Position", "Length mm");

            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
            }

            Console.Write("\n");

            for (int i = 0; i < ThisHuman.FingerNails.Count; i++)
            {
                string nailPosition = Enum.GetName((NailPosition)ThisHuman.FingerNails[i].NailPosition) ?? "";

                nailPosition = Regex.Replace(nailPosition, "(?<!^)([A-Z])", " $1");

                string posMessage = $"{Enum.GetName((LimbPosition)ThisHuman.FingerNails[i].NailLimbPosition)} {nailPosition}";

                string lengthMessage = $"{ThisHuman.FingerNails[i].NailLength:F2}";

                Console.Write(format, $"F{i}", posMessage, lengthMessage);
            }
            for (int i = 0; i < ThisHuman.ToeNails.Count; i++)
            {
                string nailPosition = Enum.GetName((NailPosition)ThisHuman.ToeNails[i].NailPosition) ?? "";

                nailPosition = Regex.Replace(nailPosition, "(?<!^)([A-Z])", " $1");

                string posMessage = $"{Enum.GetName((LimbPosition)ThisHuman.ToeNails[i].NailLimbPosition)} {nailPosition}";

                string lengthMessage = $"{ThisHuman.ToeNails[i].NailLength:F2}";

                Console.Write(format, $"T{i}", posMessage, lengthMessage);
            }

            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
            }

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
    }
}
