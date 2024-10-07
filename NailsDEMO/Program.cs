namespace NailsDEMO
{
    internal class Program
    {
        private static bool Running = true;
        static void Main(string[] args)
        {
            List<Human> humans = [new Human("Kalle", 1, 1), new Human("Bob", 2, 0.5)];

            int currentDay = 0;

            while (Running)
            {
                Console.WriteLine($"The current day is: {currentDay}");
                foreach (Human human in humans)
                {
                    human.SimulateNewDay();
                    if (currentDay % 25 == 0)
                    {
                        human.ShowHands();
                    }
                }

                currentDay++;

                Console.ReadKey();
            }
        }
    }
}
