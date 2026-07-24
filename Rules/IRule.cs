using System.Collections.Generic;
using QuantumRadarSystem.Models;

namespace QuantumRadarSystem.Rules;

public interface IRule
{
    List<Violation> Check(Observation obs);
    string GetRuleName();
}
