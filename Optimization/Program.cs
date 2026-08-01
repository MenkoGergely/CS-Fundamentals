using Optimization.Knapsack;
using Optimization.Knapsack.Bruteforce;

namespace Optimization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KnapsackProblem problem = new KnapsackProblem(4, 5, new int[] { 2, 3, 4, 5 }, new float[] { 3, 4, 5, 6 });
            bool[] selection = { true, false, true, false };
            Console.WriteLine($"Total Weight: {problem.TotalWeight(selection)}");
            Console.WriteLine($"Total Value: {problem.TotalValue(selection)}");
            Console.WriteLine($"Is Valid: {problem.IsValid(selection)}");

            BruteForceKnapsackSolver solver = new BruteForceKnapsackSolver(problem);
            bool[] solution = solver.OptimalSolution();
            float value = solver.OptimalValue();
            Console.WriteLine(string.Join(",", solution));
            Console.WriteLine(value);
        }
    }
}
