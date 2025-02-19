using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    class Program
    {
        static List<Harbor> harbors = new List<Harbor>();
        static List<Ship> ships = new List<Ship>();
        static List<Cargo> cargos = new List<Cargo>();
        static List<Route> routes = new List<Route>();

        static void Main()
        {
            Menu();
        }

        static void Menu()
        {
            bool menu = true;

            do
            {
                Console.Clear();
                Console.WriteLine("==== Hajózási Szimuláció ====");
                Console.WriteLine("1. Kikötő hozzáadása");
                Console.WriteLine("2. Hajó hozzáadása");
                Console.WriteLine("3. Rakomány hozzáadása");
                Console.WriteLine("4. Útvonal hozzáadása");
                Console.WriteLine("5. Szimuláció indítása");
                Console.WriteLine("0. Kilépés");
                Console.Write("Válassz egy opciót: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddHarbor();
                        break;
                    case "2":
                        AddShip();
                        break;
                    case "3":
                        AddCargo();
                        break;
                    case "4":
                        AddRoute();
                        break;
                    case "5":
                        StartSimulation();
                        break;
                    case "0":
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Érvénytelen választás! Nyomj Entert a folytatáshoz...");
                        Console.ReadLine();
                        break;
                }
            } while (menu);
        }

        static void AddHarbor()
        {
            Console.Clear();
            try
            {
                Console.Write("Kikötő neve: ");
                string name = Console.ReadLine();

                Console.Write("Kapacitás: ");
                int capacity = int.Parse(Console.ReadLine());

                Console.Write("Cargo kapacitás: ");
                int cargoCapacity = int.Parse(Console.ReadLine());

                Console.Write("Pozíció (x koordináta): ");
                double x = double.Parse(Console.ReadLine());

                Console.Write("Pozíció (y koordináta): ");
                double y = double.Parse(Console.ReadLine());

                harbors.Add(new Harbor(name, capacity, cargoCapacity, (x, y)));
                Console.WriteLine("Kikötő sikeresen hozzáadva!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }

            Console.WriteLine("Nyomj Entert a folytatáshoz...");
            Console.ReadLine();
        }

        static void AddShip()
        {
            Console.Clear();
            try
            {
                Console.Write("Hajó azonosító: ");
                string shipId = Console.ReadLine();

                Console.Write("Hajó típusa (CargoShip / MilitaryShip): ");
                string type = Console.ReadLine();

                Console.Write("Kapacitás: ");
                double capacity = double.Parse(Console.ReadLine());

                Console.Write("Sebesség: ");
                double speed = double.Parse(Console.ReadLine());

                if (type.ToLower() == "cargoship")
                {
                    ships.Add(new CargoShip(shipId, capacity, speed));
                    Console.WriteLine("CargoShip sikeresen hozzáadva!");
                }
                else if (type.ToLower() == "militaryship")
                {
                    Console.Write("Fegyverzet típusa: ");
                    string armament = Console.ReadLine();
                    ships.Add(new MilitaryShip(shipId, capacity, speed, armament));
                    Console.WriteLine("MilitaryShip sikeresen hozzáadva!");
                }
                else
                {
                    Console.WriteLine("Ismeretlen hajótípus!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }

            Console.WriteLine("Nyomj Entert a folytatáshoz...");
            Console.ReadLine();
        }

        static void AddCargo()
        {
            Console.Clear();
            try
            {
                Console.Write("Rakomány azonosító: ");
                string cargoId = Console.ReadLine();

                Console.Write("Rakomány típusa: ");
                string cargoType = Console.ReadLine();

                Console.Write("Súly: ");
                double weight = double.Parse(Console.ReadLine());

                Console.WriteLine("Válaszd ki a célkikötőt:");
                for (int i = 0; i < harbors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {harbors[i].Name}");
                }

                int harborIndex = int.Parse(Console.ReadLine()) - 1;
                if (harborIndex < 0 || harborIndex >= harbors.Count)
                    throw new Exception("Érvénytelen kikötő!");

                cargos.Add(new Cargo(cargoId, cargoType, weight, harbors[harborIndex]));
                Console.WriteLine("Rakomány sikeresen hozzáadva!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }

            Console.WriteLine("Nyomj Entert a folytatáshoz...");
            Console.ReadLine();
        }

        static void AddRoute()
        {
            Console.Clear();
            try
            {
                if (harbors.Count < 2)
                {
                    Console.WriteLine("Legalább 2 kikötő szükséges útvonal létrehozásához!");
                    return;
                }

                Console.WriteLine("Válaszd ki az indulási kikötőt:");
                for (int i = 0; i < harbors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {harbors[i].Name}");
                }
                int startIndex = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Válaszd ki a cél kikötőt:");
                int endIndex = int.Parse(Console.ReadLine()) - 1;

                List<(double x, double y)> waypoints = new List<(double x, double y)>();

                Console.Write("Szeretnél megadni waypointokat? (igen/nem): ");
                string response = Console.ReadLine().ToLower();

                while (response == "igen")
                {
                    try
                    {
                        Console.Write("Waypoint X koordinátája: ");
                        double x = double.Parse(Console.ReadLine());

                        Console.Write("Waypoint Y koordinátája: ");
                        double y = double.Parse(Console.ReadLine());

                        waypoints.Add((x, y));
                        Console.Write("Szeretnél még egy waypointot hozzáadni? (igen/nem): ");
                        response = Console.ReadLine().ToLower();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba: {ex.Message}");
                    }
                }

                routes.Add(new Route(harbors[startIndex], harbors[endIndex], waypoints));
                Console.WriteLine("Útvonal sikeresen hozzáadva!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }

            Console.WriteLine("Nyomj Entert a folytatáshoz...");
            Console.ReadLine();
        }

        static void StartSimulation()
        {
            Console.Clear();
            if (harbors.Count < 2 || routes.Count < 1)
            {
                Console.WriteLine("A szimuláció indításához legalább 2 kikötő és 1 útvonal szükséges!");
            }
            else
            {
                Console.WriteLine("Szimuláció elindult!");
            }

            Console.WriteLine("Nyomj Entert a folytatáshoz...");
            Console.ReadLine();
        }
    }
}
