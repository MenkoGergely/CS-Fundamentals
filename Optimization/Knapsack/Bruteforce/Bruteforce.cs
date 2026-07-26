namespace Optimization.Knapsack.Bruteforce;


internal class BruteForce<T>
{
    int candidateCount;
    Func<int, T> generator;
    Func<T, float> fitness;
    public int StepCount { get; private set; }
    public BruteForce(int candidateCount, Func<int, T> generator, Func<T, float> fitness)
    {
        this.candidateCount = candidateCount;
        this.generator = generator;
        this.fitness = fitness;
    }
    public T OptimalSolution()
    {
        T best = generator(1);
        for (int i = 2; i <= candidateCount; i++)
        {
            StepCount++;
            T candidate = generator(i);
            if (fitness(candidate) > fitness(best))
            {
                best = candidate;
            }
        }
        return best;
    }
}
