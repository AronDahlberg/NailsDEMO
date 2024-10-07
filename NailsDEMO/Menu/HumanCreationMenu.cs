namespace NailsDEMO.Menu
{
    internal class HumanCreationMenu(Simulation simulation) : BaseMenu(simulation)
    {
        public override void Run()
        {

            Console.Write(MenuHelper.ClearScreen +
                "b: Back\n" +
                "Input three values:\n" +
                "  Name (string)\n" +
                "  Desired Nail Length (double)\n" +
                "  Initial Nail Length (double)\n" +
                "seperated by ':'\n");

            string input = Console.ReadLine() ?? "";

            if (input == "b")
            {
                simulation.ChangeMenu(new HumansMenu(simulation));
            }

            try
            {
                

                var inputs = input.Split(":");

                Human human = new(inputs[0], double.Parse(inputs[1]), double.Parse(inputs[2]));

                simulation.Humans.Add(human);
            }
            catch (Exception) {}
        }
    }
}
