using System.Collections.Generic;

namespace NailsDEMO
{
    internal class Simulation
    {
        public List<Human> Humans { get; set; }
        private DateOnly CurrentDate { get; set; } = new(1, 1, 1);
        private bool Running { get; set; } = true;
        private BaseMenu Menu { get; set; }

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
        public void ChangeMenu(BaseMenu menu)
        {
            Menu = menu;
        }
        private void Simulate()
        {

        }
        public void Exit()
        {
            Running = false;
        }
    }
}
