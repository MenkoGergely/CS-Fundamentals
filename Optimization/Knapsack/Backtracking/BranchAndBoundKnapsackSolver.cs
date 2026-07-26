namespace Optimization.Knapsack.Backtracking;

internal class BranchAndBoundKnapsackSolver : BacktrackingKnapsackSolver
{
    public BranchAndBoundKnapsackSolver(KnapsackProblem problem) : base(problem)
    {
    }
    public override bool[] OptimalSolution()
    {
        int[] optionCount = new int[problem.ItemCount];
        bool[,] options = new bool[problem.ItemCount, 2];
        for (int i = 0; i < optionCount.Length; i++)
        {
            optionCount[i] = 2;
            options[i, 0] = true;
            options[i, 1] = false;
        }
        var optimizer = new BranchAndBound<bool>(problem.ItemCount, optionCount, options, IsCandidateValid, IsPartialSolutionValid, Fitness, Bound);
        bool[] solution = optimizer.OptimalSolution();
        StepCount = optimizer.StepCount;
        return solution;
    }
    private float Bound(int level, bool[] current)
    {
        float bound = 0;
        for (int i = level; i < current.Length; i++)
        {
            if (problem.TotalWeight(current) + problem.Weights[i] <= problem.MaxWeight)
                bound += problem.Values[i];
        }
        return bound;
    }
    public float OptimalValue()
    {
        bool[] solution = OptimalSolution();
        return problem.TotalValue(solution);
    }
}