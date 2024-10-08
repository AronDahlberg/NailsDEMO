namespace NailsDEMO
{
    internal class Human 
    {
        public List<Nail> ToeNails { get; set; } = [];
        public List<Nail> FingerNails { get; set; } = [];
        public double DesiredNailLength { get; set; }
        public string Name { get; set; } = "";
        private Random Random { get; set; } = new();

        public Human (string name, double desiredNailLength, double initialNailLength)
        {
            Name = name;
            DesiredNailLength = desiredNailLength;

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

        public void SimulateNewDay()
        {
            GrowNails();

            CutNails(DesiredNailLength);
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
                    nail.CutNail(desiredNailLength);
                }
            }
            foreach (var nail in FingerNails)
            {
                if (nail.NailLength > MaxNailLength())
                {
                    nail.CutNail(desiredNailLength);
                }
            }
        }
        public double MaxNailLength() => DesiredNailLength + 2;
        public override string ToString()
        {
            return $"Name: {Name}, Desired Nail Length: {DesiredNailLength} mm";
        }
    }
}
