using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsDEMO
{
    public static class MortalityChecker
    {
        private static Random random = new Random();

        public static double ProbabilityOfDying(int age)
        {
            if (age < 0 || age > 300)
            {
                throw new ArgumentOutOfRangeException("Age must be between 0 and 300.");
            }

            if (age >= 0 && age < 1)
                return 0.002;
            else if (age >= 1 && age < 15)
                return 0.0001;
            else if (age >= 15 && age < 45)
                return 0.0005;
            else if (age >= 45 && age < 65)
                return 0.0015;
            else if (age >= 65 && age < 75)
                return 0.01;
            else if (age >= 75 && age < 85)
                return 0.05;
            else if (age >= 85 && age < 100)
                return 0.15;
            else if (age >= 100 && age < 150)
                return 0.3; // Increased probability for ages 100-149
            else if (age >= 150 && age < 200)
                return 0.5; // Higher probability for ages 150-199
            else if (age >= 200 && age <= 300)
                return 0.9; // Very high probability for ages 200-300

            return 0.0; // Default case, should not be reached due to range checks above.
        }

        public static bool DidPersonDie(int age)
        {
            double probability = ProbabilityOfDying(age);
            double randomValue = random.NextDouble(); // Generates a random number between 0.0 and 1.0

            return randomValue < probability;
        }
    }
}
