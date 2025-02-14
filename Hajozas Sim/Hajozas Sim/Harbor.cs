namespace Hajozas_Sim
{
    public class Harbor
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Cargo> CargoList { get; set; } = new List<Cargo>();
        public List<Ship> DockedShips { get; set; } = new List<Ship>();

        public Harbor(string name, int capacity)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A kikötő neve nem lehet üres.");
            if (capacity <= 0)
                throw new ArgumentException("A kapacitásnak pozitívnak kell lennie.");

            Name = name;
            Capacity = capacity;
        }
    }
}