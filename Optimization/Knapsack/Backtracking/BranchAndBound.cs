namespace Optimization.Knapsack.Backtracking;

internal class BranchAndBound<T> : Backtracking<T>
{
    protected Func<int, T[], float> bound;
    public BranchAndBound(int levelCount, int[] optionCount, T[,] options, Func<int, T, bool> isCandidateValid, Func<int, T, T[], bool> isPartialSolutionValid, Func<T[], float> fitness, Func<int, T[], float> bound) : base(levelCount, optionCount, options, isCandidateValid, isPartialSolutionValid, fitness)
    {
        this.bound = bound;
    }
    protected override void Backtrack(int level, ref T[] current, ref bool found, ref T[] best)
    {
        int i = 0;
        while (i < optionCount[level])
        {
            i++;
            StepCount++;
            if (isCandidateValid(level, options[level, i - 1]))
            {
                if (isPartialSolutionValid(level, options[level, i - 1], current))
                {
                    current[level] = options[level, i - 1];
                    if (level == levelCount - 1)
                    {
                        if (!found || fitness(current) > fitness(best))
                        {
                            for (int k = 0; k < levelCount; k++)
                            {
                                best[k] = current[k];
                            }
                            found = true;
                        }
                    }
                    else
                    {
                        if (fitness(current) + bound(level, current) > fitness(best))
                        {
                            Backtrack(level + 1, ref current, ref found, ref best);
                        }
                    }
                }
            }
        }
    }
    public override T[] OptimalSolution()
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
}