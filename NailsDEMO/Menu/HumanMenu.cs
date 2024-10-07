namespace NailsDEMO.Menu
{
    internal class HumanMenu(Simulation simulation) : BaseMenu(simulation)
    {
        public override void Run()
        {
            for (int i = 0; i < simulation.Humans.Count; i++)
            {
                Console.WriteLine($"{i}: {simulation.Humans[i]}");
            }

            Console.Write(MenuHelper.ClearScreen +
                "1: Simulate amount of days\n" +
                "2: Human Menu\n" +
                "3: Exit\n");

            string? input = Console.ReadLine();
        }
    }
}
