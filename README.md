# Fawry Internship Challenge - Solution

This project contains the clean, structured, and refactored solution for the **Fawry Internship Challenge (Quantum Radar System)**.

---

## 📋 Table of Contents
1. [Overview](#-overview)
2. [Project Structure](#-project-structure)
3. [Original vs. Clean Architecture](#-original-vs-clean-architecture)
4. [How to Run](#🚀-how-to-run)
5. [Classes and Namespace Overview](#-classes-and-namespace-overview)

---

## 🔍 Overview
The **Quantum Radar System** is a console application designed to process traffic observations for different vehicle types (Private, Truck, Bus) and verify them against active traffic rules (Private Speed limit, Truck Speed limit, and Seatbelt safety rules). If a rule is violated, the system records the violation details, calculates fines, and keeps track of accumulated totals and rule violation statistics.

---

## 📁 Project Structure

Below is the directory tree of the refactored solution:

```text
Fawry internship challenge/
│
├── QuantumRadarSystem.csproj   # Project configuration (.NET 10)
├── README.md                   # Project documentation (this file)
├── OriginalChallenge.cs        # The original monolithic challenge file
│
├── Program.cs                  # Entry point & traffic simulation logic
├── QuRadar.cs                  # The manager class coordinating rules & violations
│
├── Models/                     # Core data contracts & types
│   ├── CarType.cs              # Vehicle type enumeration
│   ├── Observation.cs          # Vehicle observation model
│   └── Violation.cs            # Violation report model
│
└── Rules/                      # Domain logic rules
    ├── IRule.cs                # General rule interface
    ├── PrivateSpeedRule.cs     # Speed checking rule for private cars (Limit: 80 km/h)
    ├── TruckSpeedRule.cs       # Speed checking rule for trucks (Limit: 60 km/h)
    └── SeatbeltRule.cs         # Seatbelt fastening checking rule
```

---

## 🛠 Original vs. Clean Architecture

- **Original Monolithic File**: All code was contained in a single namespace/file, making it difficult to scale or unit-test individual rules. You can find the raw challenge source code in [OriginalChallenge.cs](file:///h:/temp/Fawry%20internship%20challenge/OriginalChallenge.cs).
- **Modern C# File-Scoped Namespaces**: The refactored version uses file-scoped namespaces (e.g. `namespace QuantumRadarSystem.Models;`), which reduces indentation, improves readability, and adheres to standard C# 10+ guidelines.
- **Clean Nullability Handling**: Added proper string initialization (`string.Empty`) to model properties to guarantee warning-free compilation on modern .NET compilers.
- **Improved Maintainability**: Rules are isolated in their own directory under the `IRule` contract, making it simple to add future regulations (e.g., `BusSpeedRule` or `RedLightRule`) without modifying existing logic.

---

## 🚀 How to Run

Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed on your system.

### Option A: Command Line
Open your terminal in this directory and execute:
```bash
dotnet run
```

### Option B: IDE (VS Code / Visual Studio)
1. Open the project folder in your editor.
2. Run the project by pressing `F5` (or `Ctrl + F5` to run without debugging).
3. The console will print the processed traffic results and prompt `Press any key to exit...` to keep the console window from closing instantly.

---

## 📝 Classes and Namespace Overview

### Namespaces:
- `QuantumRadarSystem`: Contains the entry point and core radar processor.
- `QuantumRadarSystem.Models`: Contains data structures representing observations, violation data, and vehicle classification.
- `QuantumRadarSystem.Rules`: Hosts speed rules, safety rules, and the base rule contract.
