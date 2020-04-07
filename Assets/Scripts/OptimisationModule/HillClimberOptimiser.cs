using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;


public class HillClimberOptimiser : OptimisationAlgorithm
{

    private int bestCost;
    private List<int> newSolution = null;
    
    string fileName = "Assets/Logs/" + System.DateTime.Now.ToString("ddhmmsstt") + "_HillClimberOptimiser.csv";
    //string neighbourFile = "Assets/Logs/" + System.DateTime.Now.ToString("ddhmmsstt") + "neighbourSolution.csv";


    protected override void Begin()
    {
        CreateFile(fileName);
        //CreateFile(neighbourFile);
        bestSequenceFound = new List<GameObject>();

        // Initialization
        this.newSolution = GenerateRandomSolution(targets.Count);
        int quality = Evaluate(newSolution);
        base.CurrentSolution = new List<int>(newSolution);
        bestCost = quality;

        //------------ LOG DA HIPÓTESE RANDOM INICIAL GERADA + CUSTO + ITERAÇÃO ----------------
        //AddInfoToFile(neighbourFile, this.CurrentNumberOfIterations, this.Evaluate(this.newSolution), this.newSolution);
        //--------------------------------------------------------------------------------------

        //DO NOT CHANGE THE LINES BELLOW
        AddInfoToFile(fileName, base.CurrentNumberOfIterations, this.Evaluate(base.CurrentSolution), base.CurrentSolution);
        base.CurrentNumberOfIterations++;
    }

    protected override void Step()
    {
        this.newSolution = GenerateNeighbourSolution(CurrentSolution);
        int newSolutionCost = Evaluate(newSolution);

        //----------------- LOG DAS HIPÓTESES VIZINHAS GERADAS + CUSTO + ITERAÇÃO --------------------
        //AddInfoToFile(neighbourFile, this.CurrentNumberOfIterations, this.Evaluate(this.newSolution), this.newSolution);
        //--------------------------------------------------------------------------------------------

        if (newSolutionCost <= bestCost) {
            base.CurrentSolution = new List<int>(newSolution);
            bestCost = newSolutionCost;
        }

        //DO NOT CHANGE THE LINES BELLOW
        AddInfoToFile(fileName, base.CurrentNumberOfIterations, this.Evaluate(base.CurrentSolution), base.CurrentSolution);
        base.CurrentNumberOfIterations++;
        
    }

}
