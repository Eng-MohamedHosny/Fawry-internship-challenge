using System.Collections.Generic;
using QuantumRadarSystem.Models;

namespace QuantumRadarSystem.Rules;

public class TruckSpeedRule : IRule
{
    public List<Violation> Check(Observation obs)
    {
        var violations = new List<Violation>();
        if (obs.Type == CarType.Truck && obs.Speed > 60)
        {
            violations.Add(new Violation
            {
                Description = $"speed of {obs.Speed} exceeded max allowed 60",
                Fee = 300,
                RuleName = GetRuleName()
            });
        }
        return violations;
    }

    public string GetRuleName() => "TruckSpeedRule";
}
