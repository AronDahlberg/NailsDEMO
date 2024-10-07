namespace NailsDEMO
{
    internal class Human 
    {
        public List<Nail> ToeNails { get; set; } = [];
        public List<Nail> FingerNails { get; set; } = [];
        public double DesiredNailLength { get; set; }
        public string Name { get; set; } = "";
        private List<string> DailyMessages { get; set; } = [];

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

            DailyResult(DailyMessages);

            DailyMessages.Clear();
        }

        private void GrowNails()
        {
            foreach (var nail in ToeNails)
            {
                nail.GrowNail();
            }
            foreach (var nail in FingerNails)
            {
                nail.GrowNail();
            }
        }
        private void CutNails(double desiredNailLength)
        {
            bool nailsCutToday = false;

            foreach (var nail in ToeNails)
            {
                if (nail.NailLength > MaxNailLength())
                {
                    nail.CutNail(desiredNailLength);

                    nailsCutToday = true;
                }
            }
            foreach (var nail in FingerNails)
            {
                if (nail.NailLength > MaxNailLength())
                {
                    nail.CutNail(desiredNailLength);

                    nailsCutToday = true;
                }
            }

            if (nailsCutToday)
            {
                DailyMessages.Add($"{Name} cut their nails today!");
            }
        }
        public void ShowHands()
        {
            foreach (var nail in FingerNails)
            {
                Console.WriteLine($"{Name}'s {nail}");
            }
        }
        public void DailyResult(List<string> messages)
        {
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }
        public double MaxNailLength() => DesiredNailLength + 2;
    }
}
