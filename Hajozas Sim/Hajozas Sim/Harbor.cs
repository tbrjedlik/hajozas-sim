namespace Hajozas_Sim
{
    public class Harbor
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public (double x, double y) Position { get; set; }
        public List<Cargo> CargoList { get; set; } = new List<Cargo>();
        public List<Ship> DockedShips { get; set; } = new List<Ship>();

        public Harbor(string name, int capacity, (double x, double y) position)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A kikötő neve nem lehet üres.");
            if (capacity <= 0)
                throw new ArgumentException("A kapacitásnak pozitívnak kell lennie.");

            Name = name;
            Capacity = capacity;
            Position = position;
        }

        public void DockShip(Ship ship)
        {
            if (ship == null)
                throw new ArgumentNullException(nameof(ship), "A hajó nem lehet null.");

            if (DockedShips.Contains(ship))
                throw new InvalidOperationException("A hajó már dokkolva van ebben a kikötőben.");

            if (DockedShips.Count >= Capacity)
                throw new InvalidOperationException("A kikötő elérte a maximális kapacitását.");

            DockedShips.Add(ship);
            ship.CurrentStatus = "Docked";
            ship.CurrentPosition = Position;
        }

        public void UndockShip(Ship ship)
        {
            if (ship == null)
                throw new ArgumentNullException(nameof(ship), "A hajó nem lehet null.");

            if (!DockedShips.Contains(ship))
                throw new InvalidOperationException("A hajó nincs dokkolva ebben a kikötőben.");

            DockedShips.Remove(ship);
            ship.CurrentStatus = "Sailing";
        }
    }

}