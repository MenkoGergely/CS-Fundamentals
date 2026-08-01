namespace Optimization.Knapsack.Backtracking;



public class Backtracking<T>
{
    protected int levelCount;
    protected int[] optionCount;
    protected T[,] options;
    protected Func<int, T, bool> isCandidateValid;
    protected Func<int, T, T[], bool> isPartialSolutionValid;
    protected Func<T[], float> fitness;
    public int StepCount { get; protected set; }
    public Backtracking(int levelCount, int[] optionCount, T[,] options, Func<int, T, bool> isCandidateValid, Func<int, T, T[], bool> isPartialSolutionValid, Func<T[], float> fitness)
    {
        this.levelCount = levelCount;
        this.optionCount = optionCount;
        this.options = options;
        this.isCandidateValid = isCandidateValid;
        this.isPartialSolutionValid = isPartialSolutionValid;
        this.fitness = fitness;
    }
    public virtual T[] OptimalSolution()
    {
        bool found = false;
        T[] current = new T[levelCount];
        T[] best = new T[levelCount];
        Backtrack(0, ref current, ref found, ref best);
        if (found)
        {
            return best;
        }
        else
            throw new Exception("No solution found");
    }
    protected virtual void Backtrack(int level, ref T[] current, ref bool found, ref T[] best)
    {
        int i = 0;
        while (i < optionCount[level])
        {
            StepCount++;
            if (isCandidateValid(level, options[level, i]))
            {
                if (isPartialSolutionValid(level, options[level, i], current))
                {
                    current[level] = options[level, i];
                    if (level + 1 == levelCount)
                    {
                        if (!found || fitness(current) > fitness(best))
                        {
                            for (int k = 0; k < levelCount; k++)
                                best[k] = current[k];
                        }
                        found = true;
                    }
                    else
                    {
                        Backtrack(level + 1, ref current, ref found, ref best);
                    }
                }
            }
            i++;
        }
    }
}

