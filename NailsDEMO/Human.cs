namespace NailsDEMO
{
    internal class Human 
    {
        public List<Nail> ToeNails { get; set; } = [];
        public List<Nail> FingerNails { get; set; } = [];
        public double DesiredNailLength { get; set; }
        public string Name { get; set; } = "";
        private Random Random { get; set; } = new();

        public int AmountOfCuts { get; set; }

        private DateOnly Age;
        public int Incarnation { get; private set; }

        public List<string> DeathLog = [];

        public Human (string name, double desiredNailLength, double initialNailLength)
        {
            Name = name;
            DesiredNailLength = desiredNailLength;
            CreateFingers(initialNailLength);
            Age = new DateOnly(1,1,1);
        }

        public void SimulateNewDay()
        {
            GrowNails();

            CutNails(DesiredNailLength);

            Ageify();
        }

        private double MaxNailLength() => DesiredNailLength + 2;

        private void Ageify()
        {
            Age = Age.AddDays(1);
            if (Age.DayOfYear == 1)
            {
                if (MortalityChecker.DidPersonDie(Age.Year - 1))
                {
                    Reincarnate();
                }
            }
        }

        private int CalculateMortality()
        {
            return 0;
        }

        private void Reincarnate()
        {
            DeathLog.Add($"{Name} died at the age of {Age.Year}");
            Age = new DateOnly(1, 1, 1);
            Incarnation++;
        }

        private void GrowNails()
        {
            foreach (var nail in ToeNails)
            {
                nail.GrowNail(Random);
            }
            foreach (var nail in FingerNails)
            {
                nail.GrowNail(Random);
            }
        }
        private void CutNails(double desiredNailLength)
        {

            foreach (var nail in ToeNails)
            {
                if (nail.NailLength > MaxNailLength())
                {
                    CutNail(nail);
                    AmountOfCuts++;
                }
            }
            foreach (var nail in FingerNails)
            {
                if (nail.NailLength > MaxNailLength())
                {
                    CutNail(nail);
                    AmountOfCuts++;
                }
            }
        }

        private void CutNail(Nail nail)
        {
            nail.NailLength = DesiredNailLength;
        }

        private void CreateFingers(double initialNailLength)
        {
            // for all fingers
            int firstFinger = 0;
            int lastFinger = 4;
            for (int i = firstFinger; i <= lastFinger; i++)
            {
                Nail leftFingerNail = new(LimbPosition.Left, (NailPosition)i, initialNailLength);
                FingerNails.Add(leftFingerNail);

                Nail rightFingerNail = new(LimbPosition.Right, (NailPosition)i, initialNailLength);
                FingerNails.Add(rightFingerNail);
            }

            // for all toes
            int firstToe = 5;
            int lastToe = 9;
            for (int i = firstToe; i <= lastToe; i++)
            {
                Nail leftToeNail = new(LimbPosition.Left, (NailPosition)i, initialNailLength);
                ToeNails.Add(leftToeNail);

                Nail rightToeNail = new(LimbPosition.Right, (NailPosition)i, initialNailLength);
                ToeNails.Add(rightToeNail);
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"    Age: {Age.Year} years\n" +
                $"    Reincarnations: {Incarnation}\n" +
                $"    Desired Nail Length: {DesiredNailLength} mm";
        }
    }
}
