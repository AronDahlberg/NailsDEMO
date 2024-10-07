namespace NailsDEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Human> humans = [new Human("Kalle", 1, 1), new Human("Bob", 2, 0.5)];
            Simulation simulation = new(humans);

            simulation.Run();
        }
    }
}
