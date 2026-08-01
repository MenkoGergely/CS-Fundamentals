using Optimization.Knapsack;
using Optimization.Knapsack.Backtracking;
using Optimization.Knapsack.Bruteforce;
using Optimization.Knapsack.DynamicProgramming;
using System.Diagnostics;

namespace Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benchmarking All Knapsack Solver");

            int[] testSizes = { 5, 10,15,20,22 };
            for(int i = 0; i < testSizes.Length; i++)
            {
                RunBenchmark(testSizes[i]);
                Console.WriteLine();
            }

        }
        static void RunBenchmark(int itemCount)
        {
            Console.WriteLine($"Running benchmark for {itemCount} items.");
            KnapsackProblem problem = GenerateProblem(itemCount);
            Type[] solverTypes =  { typeof(BruteForceKnapsackSolver), typeof(DynamicProgrammingKnapsackSolver), typeof(BacktrackingKnapsackSolver),typeof(BranchAndBoundKnapsackSolver) };

            foreach(Type type in solverTypes)
            {
                IKnapsackSolver solver = (IKnapsackSolver)Activator.CreateInstance(type, problem);
                Stopwatch stopwatch = Stopwatch.StartNew();
                float optimalValue =  solver.OptimalValue();
                stopwatch.Stop();
                Console.WriteLine($"- {type.Name} Value: {optimalValue} | Step Count: {solver.StepCount} | Time: {stopwatch.ElapsedMilliseconds} ms");
            }

        }


        static KnapsackProblem GenerateProblem(int itemCount)
        {
            Random random = new Random(42);
            int maxWeight = itemCount*5;
            int[] weights = new int[itemCount];
            float[] values = new float[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                weights[i] = random.Next(1, 15);
                values[i] = random.Next(10, 100);
            }
            return new KnapsackProblem(itemCount, maxWeight, weights, values);
        }
    }
}
