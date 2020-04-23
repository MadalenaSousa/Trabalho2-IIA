using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedAnnealingOptimiser : OptimisationAlgorithm
{
    private List<int> newSolution = null;
    private int CurrentSolutionCost;
    private float Temperature;
    public float maxTemperature;
    public string functionType;
    private float zero = Mathf.Pow(10, -6);// numbers bellow this value can be considered zero.

    string fileName = "Assets/Logs/" + System.DateTime.Now.ToString("ddhmmsstt") + "_SimulatedAnnealingOptimiser.csv";

    protected override void Begin()
    {
        CreateFileSA(fileName);
        // Initialization
        this.newSolution = GenerateRandomSolution(targets.Count);
        int quality = Evaluate(newSolution);
        base.CurrentSolution = new List<int>(newSolution);
        CurrentSolutionCost = quality;
        Temperature = maxTemperature;

        //DO NOT CHANGE THE LINES BELLOW
        AddInfoToFile(fileName, base.CurrentNumberOfIterations, CurrentSolutionCost, CurrentSolution, Temperature);
        base.CurrentNumberOfIterations++;
    }

    protected override void Step()
    {
        if (Temperature > zero) {

            this.newSolution = GenerateNeighbourSolution(CurrentSolution);
            int newSolutionCost = Evaluate(newSolution);

            float probability = Mathf.Exp((CurrentSolutionCost - newSolutionCost)/Temperature); 

            if (newSolutionCost <= CurrentSolutionCost || probability > Random.Range(0f, 1f)) 
            {
                base.CurrentSolution = new List<int>(newSolution);
                CurrentSolutionCost = newSolutionCost;
            }
           
            Temperature = TemperatureSchedule(Temperature, functionType);

            //DO NOT CHANGE THE LINES BELLOW
            AddInfoToFile(fileName, base.CurrentNumberOfIterations, CurrentSolutionCost, CurrentSolution, Temperature);
            base.CurrentNumberOfIterations++;
        }

    }

    protected float TemperatureSchedule(float temperature, string functionType)
    {
        if (functionType == "linear")
        {
            return temperature;
        }
        else if(functionType == "logaritmic")
        {
            return temperature;
        }
        else if(functionType == "sinusoid")
        {
            return temperature;
        }
        else
        {
            return temperature;
        }
    }


}
