using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedAnnealingOptimiser : OptimisationAlgorithm
{
    private List<int> newSolution = null;
    private int CurrentSolutionCost;
    public float Temperature;
    private float zero = Mathf.Pow(10, -6);// numbers bellow this value can be considered zero.

    string fileName = "Assets/Logs/" + System.DateTime.Now.ToString("ddhmmsstt") + "_SimulatedAnnealingOptimiser.csv";


    protected override void Begin()
    {
        CreateFileSA(fileName);
        // Initialization
        this.newSolution = GenerateRandomSolution(targets.Count);
        this.Temperature = zero;
        this.CurrentSolutionCost = Evaluate(newSolution);
        base.CurrentSolution = new List<int>(newSolution);
    }

    protected override void Step()
    {

        this.newSolution = GenerateNeighbourSolution(CurrentSolution);
        int newSolutionCost = Evaluate(newSolution);

        //float probability = Mathf.Pow((float)Math.E, (CurrentSolutionCost - newSolutionCost)/Temperature);

        if (newSolutionCost <= CurrentSolutionCost)
        {
            base.CurrentSolution = new List<int>(newSolution);
            CurrentSolutionCost = newSolutionCost;
        }

        //DO NOT CHANGE THE LINES BELLOW
        AddInfoToFile(fileName, base.CurrentNumberOfIterations, CurrentSolutionCost, CurrentSolution, Temperature);
        base.CurrentNumberOfIterations++;

    }


}
