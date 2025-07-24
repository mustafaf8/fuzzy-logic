# Fuzzy Logic Washing Machine Controller 🧼

[![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.7.2-512BD4?style=for-the-badge&logo=.net)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)](https://visualstudio.microsoft.com/)

A C# Windows Forms application that demonstrates the principles of fuzzy logic through a practical simulation of a smart washing machine controller. This project provides a from-scratch implementation of a Mamdani-style fuzzy inference system.

---

## 📖 Table of Contents

- [📌 Project Abstract](#-project-abstract)
- [🧠 The Fuzzy Logic Engine: A Deep Dive](#-the-fuzzy-logic-engine-a-deep-dive)
  - [1. Input Variables](#1-input-variables)
  - [2. Fuzzification](#2-fuzzification)
  - [3. Rule Base & Inference](#3-rule-base--inference)
  - [4. Defuzzification](#4-defuzzification)
- [✨ Application Features](#-application-features)
- [🛠️ Technology Stack](#️-technology-stack)
- [🚀 Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation & Setup](#installation--setup)
- [🤝 Contributing](#-contributing)

---

## 📌 Project Abstract

Fuzzy logic provides a way to model complex systems using human-like reasoning, making it ideal for control systems where inputs can be imprecise or subjective. This project, **Bulanık Mantık (Fuzzy Logic)**, was developed as an educational tool to showcase these concepts.

It implements a complete fuzzy inference system to control a simulated washing machine. Users can input crisp values for the laundry's **sensitivity, amount, and dirtiness**. The application then uses a set of fuzzy rules to determine the optimal **rotation speed, detergent amount, and washing time**. This project is unique because it builds the entire fuzzy logic engine from the ground up, without relying on external libraries, offering a clear view into the core mechanics of fuzzification, rule evaluation, and defuzzification.

---

## 🧠 The Fuzzy Logic Engine: A Deep Dive

The core of this application is a custom-built fuzzy logic controller. It follows the classic Mamdani inference model, which consists of four main steps:

### 1. Input Variables

The system takes three crisp (numerical) inputs from the user via track bars:
-   **Sensitivity (`Hassasiyet`):** How delicate the clothes are.
-   **Amount (`Miktar`):** The quantity of laundry in the machine.
-   **Dirtiness (`Kirlilik`):** How soiled the clothes are.

### 2. Fuzzification

The first step is to take these crisp inputs and translate them into fuzzy linguistic variables. The `Bulanık.cs` class handles this process. Each input is mapped to a degree of membership in several fuzzy sets (e.g., "Low," "Medium," "High") using predefined membership functions (likely triangular or trapezoidal).

For example, a "Dirtiness" value of 75 might be translated to:
-   `0.0` membership in "Low"
-   `0.25` membership in "Medium"
-   `0.75` membership in "High"

### 3. Rule Base & Inference

The decision-making brain of the system is a set of human-readable IF-THEN rules. These rules are defined in an external `kural.txt` file and loaded at runtime by the `Kural.cs` class. A typical rule looks like this:

`IF Sensitivity IS High AND Amount IS Medium AND Dirtiness IS High THEN RotationSpeed IS Slow AND Detergent IS Much AND WashTime IS Long`

The inference engine evaluates all rules in the rule base. For each rule, it takes the membership values from the fuzzification step and applies a fuzzy operator (typically `MIN` for `AND` conditions) to determine the "firing strength" of that rule. This strength is then used to clip the output fuzzy sets.

### 4. Defuzzification

After all rules have been evaluated, the system has a collection of clipped fuzzy output sets for Rotation Speed, Detergent Amount, and Wash Time. The `Durulaştır.cs` ("Defuzzify") class is responsible for converting these fuzzy outputs back into a single, crisp, and actionable number.

This is achieved using the **Center of Gravity (Centroid)** method, which calculates the weighted average of the combined output fuzzy sets. The result is a precise value that the washing machine can use, for example:
-   Rotation Speed: `850 RPM`
-   Detergent Amount: `110 ml`
-   Wash Time: `75 minutes`

---

## ✨ Application Features

The main UI (`Form1.cs`) provides an interactive dashboard to control and observe the fuzzy logic system in real-time.

-   **Interactive Inputs:** Use sliders (TrackBars) to adjust the crisp input values for Sensitivity, Amount, and Dirtiness.
-   **Real-Time Outputs:** Instantly see the calculated crisp output values for Rotation Speed, Detergent Amount, and Wash Time.
-   **Process Visualization:** The application displays the intermediate results, including the membership degrees for each input and the final calculated values, offering a clear insight into the decision-making process.
-   **Rule-Based Logic:** The entire control logic is driven by the easily editable `kural.txt` file, allowing for quick adjustments to the machine's behavior without changing the source code.

---

## 🛠️ Technology Stack

-   **Framework:** .NET Framework 4.7.2
-   **Language:** C#
-   **User Interface:** Windows Forms (WinForms)
-   **Development Environment:** Visual Studio

---

## 🚀 Getting Started

Follow these instructions to get the project running on your local machine.

### Prerequisites

-   **Visual Studio:** 2019 or 2022 with the ".NET desktop development" workload installed.
-   **.NET Framework:** Version 4.7.2 Developer Pack.

### Installation & Setup

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/your-username/Bulanik-Mantik.git](https://github.com/your-username/Bulanik-Mantik.git)
    cd Bulanik-Mantik
    ```

2.  **Open in Visual Studio:**
    -   Launch Visual Studio.
    -   Open the `Bulanık Mantık.csproj` or the solution file (`.sln`).

3.  **Check the Rule File:**
    -   Ensure the `kural.txt` file exists in the `bin/Debug` directory of the project. This file is crucial for the application to load its decision-making rules.

4.  **Build the Project:**
    -   In the Visual Studio menu, select `Build` > `Build Solution` (or press `Ctrl+Shift+B`).

5.  **Run the Application:**
    -   Press `F5` or click the "Start" button in the toolbar to launch the application.
    -   Adjust the input sliders and click the "Hesapla" (Calculate) button to see the fuzzy logic controller in action.

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome.

1.  **Fork** the Project.
2.  Create your Feature Branch (`git checkout -b feature/NewMembershipFunction`).
3.  Commit your Changes (`git commit -m 'Add Gaussian membership function'`).
4.  Push to the Branch (`git push origin feature/NewMembershipFunction`).
5.  Open a **Pull Request**.
