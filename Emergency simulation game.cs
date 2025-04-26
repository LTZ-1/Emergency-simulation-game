using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

abstract class EmergencyUnit
{
    public string Name { get; set; }
    public int Speed { get; set; }

    public EmergencyUnit(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public abstract bool CanHandle(string incidentType);
    public abstract void RespondToIncident(Incident incident);

}

class Police : EmergencyUnit
{
    public Police(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Crime";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is handling the crime at {incident.Location}.");
    }

}

class Firefighter : EmergencyUnit
{
    public Firefighter(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Fire";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is extinguishing the fire at {incident.Location}.");
    }

}

class Ambulance : EmergencyUnit
{
    public Ambulance(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Medical";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is treating patients at {incident.Location}.");
    }

}

class RescueTeam : EmergencyUnit
{
    public RescueTeam(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Rescue";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is rescuing people at {incident.Location}.");
    }

}

class HazardControl : EmergencyUnit
{
    public HazardControl(string name, int speed) : base(name, speed) { }

    public override bool CanHandle(string incidentType) => incidentType == "Hazard";

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is containing the hazard at {incident.Location}.");
    }

}

class Incident
{
    public string Type { get; set; }
    public string Location { get; set; }

    public Incident(string type, string location)
    {
        Type = type;
        Location = location;
    }

}

class Program
{
    static List<EmergencyUnit> units = new List<EmergencyUnit>
{
new Police("Police Unit 1", 80),
new Firefighter("Firefighter Unit 1", 70),
new Ambulance("Ambulance Unit 1", 90),
new RescueTeam("Rescue Team 1", 75),
new HazardControl("Hazard Control Unit 1", 65)
};

    static List<string> incidentTypes = new List<string> { "Crime", "Fire", "Medical", "Rescue", "Hazard" };
    static List<string> locations = new List<string> { "City Hall", "Downtown", "Uptown", "Harbor", "Suburb", "Airport", "University" };

    static Random random = new Random();

    static void Main()
    {
        int score = 0;

        Console.WriteLine("=== Emergency Response Simulation ===");

        for (int round = 1; round <= 5; round++)
        {
            Console.WriteLine($"\n--- Turn {round} ---");

            string incidentType = incidentTypes[random.Next(incidentTypes.Count)];
            string location = locations[random.Next(locations.Count)];
            Incident incident = new Incident(incidentType, location);

            Console.WriteLine($"Incident: {incidentType} at {location}");

            var possibleUnits = units.Where(u => u.CanHandle(incidentType)).ToList();

            if (possibleUnits.Any())
            {
                EmergencyUnit selectedUnit = null;

                // Optional: Manual selection  
                Console.WriteLine("Select a unit to dispatch:");
                for (int i = 0; i < possibleUnits.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {possibleUnits[i].Name} (Speed: {possibleUnits[i].Speed})");
                }

                Console.Write("Enter choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= possibleUnits.Count)
                {
                    selectedUnit = possibleUnits[choice - 1];
                }
                else
                {
                    selectedUnit = possibleUnits[0]; // fallback  
                    Console.WriteLine("Invalid choice. Default unit dispatched.");
                }

                int responseTime = 100 - selectedUnit.Speed + random.Next(10);
                Thread.Sleep(500); // simulate delay  
                selectedUnit.RespondToIncident(incident);

                int points = 10;
                if (responseTime < 30) points += 5;
                if (responseTime > 70) points -= 3;

                Console.WriteLine($"+{points} points (Response time: {responseTime} units)");
                score += points;
            }
            else
            {
                Console.WriteLine("No unit available to handle this incident.");
                score -= 5;
                Console.WriteLine("-5 points");
            }

            Console.WriteLine($"Current Score: {score}");
        }

        Console.WriteLine($"\n=== Simulation Ended ===\nFinal Score: {score}");
    }

}

