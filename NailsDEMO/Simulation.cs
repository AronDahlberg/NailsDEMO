using NailsDEMO.Menu;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System;

namespace NailsDEMO
{
    internal class Simulation
    {
        public List<Human> Humans { get; set; }
        public DateOnly Date { get; set; } = new DateOnly(1, 1, 1);
        private bool Running { get; set; } = true;
        private BaseMenu Menu { get; set; }
        public int AmountOfSimulationDays { get; set; } = 50;
        public ProgressBar ProgressBar { get; set; } = new(30);

        public Simulation(List<Human> humans)
        {
            Humans = humans;
            Menu = new MainMenu(this);
        }
        public void Run()
        {
            while (Running)
            {
                Menu.Run();
            }
        }
        public void Simulate()
        {
            double completionPercentage;
            double modulo;

            Console.Write(MenuHelper.ClearScreen);

            ProgressBar.PrintProgressBar(0);

            for (int i = 0; i < AmountOfSimulationDays; i++)
            {
                foreach (Human human in Humans)
                {
                    human.SimulateNewDay();
                }

                modulo = AmountOfSimulationDays < 100 ? 1 : (AmountOfSimulationDays / ProgressBar.Size);

                if (i % modulo == 0)
                {
                    completionPercentage = (double)i / (double)AmountOfSimulationDays;

                    ProgressBar.PrintProgressBar(completionPercentage);
                }
            }

            ProgressBar.PrintProgressBar(1);

            try
            {
                Date = Date.AddDays(AmountOfSimulationDays);
            }
            catch (ArgumentOutOfRangeException)
            {
                Date = default;
            }

            PrintResult();
        }


        //50 days has passed
        //Current date....
        //Human[]
        //human.Name har klippt x gånger
        //human.desiredLength

        private void PrintResult()
        {
            string dateMessage = Date != default
                                      ? Date.ToLongDateString()
                                      : "over year 9999";

            Console.Write(
                $"\n{AmountOfSimulationDays} days have passed\n" +
                $"Current date is: {dateMessage}\n");

            foreach(var human in Humans)
            {
                Console.WriteLine($"{human.Name} has cut the nails {human.AmountOfCuts} times.");
            }

            Console.Write($"Press any key to continue\n");
            Console.ReadKey();
        }

        public void ChangeMenu(BaseMenu menu)
        {
            Menu = menu;
        }
        public void Exit()
        {
            Running = false;
        }
    }
}
