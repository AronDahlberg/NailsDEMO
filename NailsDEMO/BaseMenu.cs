namespace NailsDEMO
{
    internal abstract class BaseMenu (Simulation simulation)
    {
        public Simulation simulation { get; set; } = simulation;
        public abstract void Run();
    }
}
