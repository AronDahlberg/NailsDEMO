using System.Security.Cryptography;

namespace NailsDEMO.Menu
{
    internal class EditNailMenu(Simulation simulation, Nail nail, Human human) : BaseMenu(simulation)
    {
        private Nail ThisNail { get; set; } = nail;
        private Human ThisHuman { get; set; } = human;
        public override void Run()
        {
            Console.Write(MenuHelper.ClearScreen +
                $"Current nail length: {ThisNail.NailLength:F2}\n"+
                $"Input new length of nail\n" +
                $"b: Back\n" +
                "> ");

            string? input = Console.ReadLine();

            if (input == null || !input.Any()) { return; }

            if (input == "b")
            {
                simulation.ChangeMenu(new NailsMenu(simulation, ThisHuman)); 
            }
            
            if (double.TryParse(input, out double value))
            {
                ThisNail.NailLength = value;
            }
        }
    }
}
