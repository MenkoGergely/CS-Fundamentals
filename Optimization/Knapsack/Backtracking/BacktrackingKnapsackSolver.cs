namespace Optimization.Knapsack.Backtracking;

public class BacktrackingKnapsackSolver:IKnapsackSolver
{
    protected KnapsackProblem problem;
    public int StepCount { get; protected set; }
    public BacktrackingKnapsackSolver(KnapsackProblem problem)
    {
        this.problem = problem;
    }
    public virtual bool[] OptimalSolution()
    {
        int[] optionCount = new int[problem.ItemCount];
        bool[,] options = new bool[problem.ItemCount, 2];
        for (int i = 0; i < problem.ItemCount; i++)
        {
            optionCount[i] = 2;
            options[i, 0] = true;
            options[i, 1] = false;
        }
        var optimizer = new Backtracking<bool>(problem.ItemCount, optionCount, options, IsCandidateValid, IsPartialSolutionValid, Fitness);
        bool[] solution = optimizer.OptimalSolution();
        StepCount = optimizer.StepCount;
        return solution;
    }
    protected float Fitness(bool[] selection)
    {
        return problem.TotalValue(selection);
    }
    protected bool IsCandidateValid(int level, bool candidate)
    {
        return true;
    }
    protected bool IsPartialSolutionValid(int level, bool isPacked, bool[] current)
    {
        if (isPacked)
        {
            return problem.TotalWeight(current) + problem.Weights[level] <= problem.MaxWeight;
        }
        return true;
    }
    public float OptimalValue()
    {
        bool[] solution = OptimalSolution();
        return problem.TotalValue(solution);
    }
}