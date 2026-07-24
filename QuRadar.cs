using System;
using System.Collections.Generic;
using QuantumRadarSystem.Models;
using QuantumRadarSystem.Rules;

namespace QuantumRadarSystem;

public class QuRadar
{
    private readonly List<IRule> _rules = new List<IRule>();
    private readonly Dictionary<string, int> _totalFinesPerCar = new Dictionary<string, int>();
    private readonly Dictionary<string, int> _ruleViolationCount = new Dictionary<string, int>();

    public void AddRule(IRule rule)
    {
        _rules.Add(rule);
    }

    public void ProcessObservation(Observation obs)
    {
        var activeViolations = new List<Violation>();
        int totalFee = 0;

        foreach (var rule in _rules)
        {
            var violations = rule.Check(obs);
            foreach (var v in violations)
            {
                activeViolations.Add(v);
                totalFee += v.Fee;

                if (!_ruleViolationCount.ContainsKey(v.RuleName))
                    _ruleViolationCount[v.RuleName] = 0;
                _ruleViolationCount[v.RuleName]++;
            }
        }

        if (activeViolations.Count > 0)
        {
            if (!_totalFinesPerCar.ContainsKey(obs.PlateNumber))
                _totalFinesPerCar[obs.PlateNumber] = 0;
            
            _totalFinesPerCar[obs.PlateNumber] += totalFee;

            Console.WriteLine($"Traffic for car {obs.PlateNumber}");
            Console.WriteLine($"Total amount: {totalFee} EGP");
            Console.WriteLine("Violations:");
            foreach (var v in activeViolations)
            {
                Console.WriteLine($"- {v.Description} : {v.Fee} EGP");
            }
            Console.WriteLine();
        }
    }

    public void GetAllPossibleFines()
    {
        Console.WriteLine("[ ALL FINES SYSTEM ]");
        foreach (var pair in _totalFinesPerCar)
        {
            Console.WriteLine($"Plate Number: {pair.Key} | Total Outstanding: {pair.Value} EGP");
        }
        Console.WriteLine("------------------------------------------");
    }

    public void GetViolatedRulesStats()
    {
        Console.WriteLine("[ VIOLATED RULES STATISTICS ]");
        foreach (var pair in _ruleViolationCount)
        {
            Console.WriteLine($"Rule: {pair.Key} | Total Violations: {pair.Value}");
        }
        Console.WriteLine("------------------------------------------");
    }
}
