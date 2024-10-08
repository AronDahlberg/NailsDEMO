using System.Text.RegularExpressions;

namespace NailsDEMO
{
    internal class Nail (LimbPosition limbposition, NailPosition nailPosition, double nailLength)
    {
        public LimbPosition NailLimbPosition { get; set; } = limbposition;
        public NailPosition NailPosition { get; set; } = nailPosition;
        public double NailLength { get; set; } = nailLength; // mm

        public void GrowNail()
        {
            NailLength += 0.1;
        }
        public void CutNail(double desiredLength)
        {
            NailLength = desiredLength;
        }
    }
}
