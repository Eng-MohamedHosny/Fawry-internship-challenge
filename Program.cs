using System;
using QuantumRadarSystem.Models;
using QuantumRadarSystem.Rules;

namespace QuantumRadarSystem;

public class Program
{
    public static void Main()
    {
        var radar = new QuRadar();

        radar.AddRule(new PrivateSpeedRule());
        radar.AddRule(new TruckSpeedRule());
        radar.AddRule(new SeatbeltRule());

        var obs1 = new Observation { PlateNumber = "ABC1234", Date = "2026-01-22", Type = CarType.Private, Speed = 94, SeatbeltFastened = false };
        var obs2 = new Observation { PlateNumber = "XYZ9876", Date = "2026-06-03", Type = CarType.Truck, Speed = 65, SeatbeltFastened = true };
        var obs3 = new Observation { PlateNumber = "OKK1111", Date = "2026-02-12", Type = CarType.Private, Speed = 70, SeatbeltFastened = true }; 
        var obs4 = new Observation { PlateNumber = "ABC1234", Date = "2026-07-25", Type = CarType.Private, Speed = 85, SeatbeltFastened = true }; 

        radar.ProcessObservation(obs1);
        radar.ProcessObservation(obs2);
        radar.ProcessObservation(obs3);
        radar.ProcessObservation(obs4);

        radar.GetAllPossibleFines();
        radar.GetViolatedRulesStats();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
