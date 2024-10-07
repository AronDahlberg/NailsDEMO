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
        public override string ToString()
        {
            return $"{Enum.GetName((NailPosition)NailPosition)} at {Enum.GetName((LimbPosition)NailLimbPosition)} limb has length {NailLength:F2} mm";
        }
    }
}
