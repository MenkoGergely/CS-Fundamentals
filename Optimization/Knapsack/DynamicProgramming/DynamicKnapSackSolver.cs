namespace Optimization.Knapsack.DynamicProgramming;
internal class DynamicProgrammingKnapsackSolver
{
    KnapsackProblem problem;
    public int StepCount { private set; get; }
    public DynamicProgrammingKnapsackSolver(KnapsackProblem problem)
    {
        this.problem = problem;
    }
    public float[,] FillTable()
    {
        float[,] table = new float[problem.ItemCount + 1, problem.MaxWeight + 1];
        for (int itemIndex = 0; itemIndex <= problem.ItemCount; itemIndex++)
        {
            table[itemIndex, 0] = 0;
        }
        for (int capacity = 0; capacity <= problem.MaxWeight; capacity++)
        {
            table[0, capacity] = 0;
        }
        for (int itemIndex = 1; itemIndex <= problem.ItemCount; itemIndex++)
        {
            for (int capacity = 1; capacity <= problem.MaxWeight; capacity++)
            {
                StepCount++;
                if (capacity < problem.Weights[itemIndex - 1])
                {
                    table[itemIndex, capacity] = table[itemIndex - 1, capacity];
                }
                else
                {
                    table[itemIndex, capacity] = Math.Max(table[itemIndex - 1, capacity], table[itemIndex - 1, capacity - problem.Weights[itemIndex - 1]] + problem.Values[itemIndex - 1]);
                }
            }
        }
        return table;
    }
    public float OptimalValue()
    {
        StepCount = 0;
        return FillTable()[problem.ItemCount, problem.MaxWeight];
    }
    public bool[] OptimalSolution()
    {
        StepCount = 0;
        float[,] table = FillTable();
        bool[] selection = new bool[problem.ItemCount];
        int itemIndex = problem.ItemCount;
        int capacity = problem.MaxWeight;
        for (int i = 0; i < problem.ItemCount; i++)
        {
            selection[i] = false;
        }
        while (itemIndex > 0 && capacity > 0)
        {
            if (table[itemIndex, capacity] != table[itemIndex - 1, capacity])
            {
                selection[itemIndex - 1] = true;
                capacity -= problem.Weights[itemIndex - 1];
            }
            itemIndex--;
        }
        return selection;
    }
}