using static NailsDEMO.MenuHelper;

namespace NailsDEMO
{
    internal class HumanMenu(Simulation simulation) : BaseMenu(simulation)
    {
        public override void Run()
        {
            foreach (var human in simulation.Humans)
            {
                Console.WriteLine(human);
            }

            Console.Write(ClearScreen +
                "1: Simulate amount of days\n" +
                "2: Human Menu\n" +
                "3: Exit\n");

            string? input = Console.ReadLine();
        }
    }
}
