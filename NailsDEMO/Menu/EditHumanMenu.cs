namespace NailsDEMO.Menu
{
    internal class EditHumanMenu(Simulation simulation, Human human) : BaseMenu(simulation)
    {
        private Human ThisHuman { get; set; } = human;
        public override void Run()
        {
            Console.Write(MenuHelper.ClearScreen +

                $"Input choice to edit values\n" +
                $"0: Name = {ThisHuman.Name}\n" +
                $"1: Desired Nail Length = {ThisHuman.DesiredNailLength}\n" +
                $"2: Nails Menu\n" +
                $"b: Back\n" +
                "> ");

            string? input = Console.ReadLine();

            if (input == null || !input.Any()) { return; }

            switch (input)
            {
                case "b": simulation.ChangeMenu(new HumansMenu(simulation)); break;

                case "0": ThisHuman.Name = MenuHelper.GetUserInput() ?? ""; break;

                case "1": 
                    if (double.TryParse(MenuHelper.GetUserInput(), out double value))
                    {
                        ThisHuman.DesiredNailLength = value; 
                    }
                    break;

                case "2": simulation.ChangeMenu(new NailsMenu(simulation, ThisHuman)); break;
            }
        }
    }
}
