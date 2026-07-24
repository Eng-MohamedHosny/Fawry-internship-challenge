using System.Collections.Generic;
using QuantumRadarSystem.Models;

namespace QuantumRadarSystem.Rules;

public class PrivateSpeedRule : IRule
{
    public List<Violation> Check(Observation obs)
    {
        var violations = new List<Violation>();
        if (obs.Type == CarType.Private && obs.Speed > 80)
        {
            violations.Add(new Violation
            {
                Description = $"speed of {obs.Speed} exceeded max allowed 80",
                Fee = 300,
                RuleName = GetRuleName()
            });
        }
        return violations;
    }

    public string GetRuleName() => "PrivateSpeedRule";
}
