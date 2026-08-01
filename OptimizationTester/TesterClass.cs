using NUnit.Framework;
using Optimization.Knapsack;
using Optimization.Knapsack.Backtracking;
using Optimization.Knapsack.Bruteforce;
using Optimization.Knapsack.DynamicProgramming;


namespace Optimization.Tests
{
    [TestFixture]
    internal class TesterClass
    {
       
        [TestCaseSource(typeof(TestCases),nameof(TestCases.KnapsackSolverTestCases))]
        public void BruteForceKnapsackSolverTest(int itemCount, int maxWeight, int[] weights, float[] values, bool[] expectedSolution, float expectedValue)
        {
            //Arrange
            KnapsackProblem problem = new KnapsackProblem(itemCount, maxWeight, weights, values);
            BruteForceKnapsackSolver solver = new BruteForceKnapsackSolver(problem);
            //Act

            bool[] solution = solver.OptimalSolution();
            float value = solver.OptimalValue();

            //Assert
            Assert.That(solution, Is.EqualTo(expectedSolution));
            Assert.That(value, Is.EqualTo(expectedValue));

        }



        [TestCaseSource(typeof(TestCases), nameof(TestCases.KnapsackSolverTestCases))]
        public void DynamicKnapsackSolverTest(int itemCount, int maxWeight, int[] weights, float[] values, bool[] expectedSolution, float expectedValue)
        {
            //Arrange
            KnapsackProblem problem = new KnapsackProblem(itemCount, maxWeight, weights, values);
            DynamicProgrammingKnapsackSolver solver = new DynamicProgrammingKnapsackSolver(problem);
            //Act

            bool[] solution = solver.OptimalSolution();
            float value = solver.OptimalValue();

            //Assert
            Assert.That(solution, Is.EqualTo(expectedSolution));
            Assert.That(value, Is.EqualTo(expectedValue));

        }

        [TestCaseSource(typeof(TestCases), nameof(TestCases.KnapsackSolverTestCases))]
        public void BackTrackKnapsackSolverTest(int itemCount, int maxWeight, int[] weights, float[] values, bool[] expectedSolution, float expectedValue)
        {
            //Arrange
            KnapsackProblem problem = new KnapsackProblem(itemCount, maxWeight, weights, values);
            BacktrackingKnapsackSolver solver = new BacktrackingKnapsackSolver(problem);
            //Act

            bool[] solution = solver.OptimalSolution();
            float value = solver.OptimalValue();

            //Assert
            Assert.That(solution, Is.EqualTo(expectedSolution));
            Assert.That(value, Is.EqualTo(expectedValue));

        }

        [TestCaseSource(typeof(TestCases), nameof(TestCases.KnapsackSolverTestCases))]
        public void BranchAndBoundKnapsackSolverTest(int itemCount, int maxWeight, int[] weights, float[] values, bool[] expectedSolution, float expectedValue)
        {
            //Arrange
            KnapsackProblem problem = new KnapsackProblem(itemCount, maxWeight, weights, values);
            BranchAndBoundKnapsackSolver solver = new BranchAndBoundKnapsackSolver(problem);
            //Act

            bool[] solution = solver.OptimalSolution();
            float value = solver.OptimalValue();

            //Assert
            Assert.That(solution, Is.EqualTo(expectedSolution));
            Assert.That(value, Is.EqualTo(expectedValue));

        }
    }
}
