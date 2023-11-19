namespace Tools
{
    public interface IPlayerData
    {
        public float Acceleration { get; }
        public float ShipSpeed { get; }
        public float Faster { get; }
        public float NormalFov { get; }
        public float FasterFov { get; }
        public float ChangeFovSpeed { get; }
    }
}
