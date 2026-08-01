namespace Optimization.Knapsack.Bruteforce;

public class BruteForceKnapsackSolver : IKnapsackSolver
{
    KnapsackProblem problem;
    public int StepCount { get; private set; }
    public BruteForceKnapsackSolver(KnapsackProblem problem)
    {
        this.problem = problem;
    }
    public bool[] Generator(int i)
    {
        int number = i;
        bool[] selection = new bool[problem.ItemCount];
        for (int j = 0; j < problem.ItemCount; j++)
        {
            selection[j] = (int)(number / Math.Pow(2, j) % 2) == 1;
        }
        return selection;
    }
    public float Fitness(bool[] selection)
    {
        if (!problem.IsValid(selection)) return -1;
        else
        {
            return problem.TotalValue(selection);
        }
    }
    public bool[] OptimalSolution()
    {
        BruteForce<bool[]> optimizer = new BruteForce<bool[]>((int)Math.Pow(2, problem.ItemCount), Generator, Fitness);
        bool[] solution = optimizer.OptimalSolution();
        StepCount = optimizer.StepCount;
        return solution;
    }
    public float OptimalValue()
    {
        return problem.TotalValue(OptimalSolution());
    }
}