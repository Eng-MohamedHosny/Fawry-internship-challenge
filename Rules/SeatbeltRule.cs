using System.Collections.Generic;
using QuantumRadarSystem.Models;

namespace QuantumRadarSystem.Rules;

public class SeatbeltRule : IRule
{
    public List<Violation> Check(Observation obs)
    {
        var violations = new List<Violation>();
        if (!obs.SeatbeltFastened)
        {
            violations.Add(new Violation
            {
                Description = "Seatbelt not fastned",
                Fee = 100,
                RuleName = GetRuleName()
            });
        }
        return violations;
    }

    public string GetRuleName() => "SeatbeltRule";
}
