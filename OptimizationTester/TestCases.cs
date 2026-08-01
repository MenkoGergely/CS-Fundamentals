using NUnit.Framework;

namespace Optimization.Tests
{
    internal class TestCases
    {
        public static IEnumerable<TestCaseData> KnapsackSolverTestCases()
        {
            //Regular test cases
            yield return new TestCaseData(4, 5,new int[] { 2, 3, 4, 5 },new float[] { 3, 4, 5, 6 },new bool[] { true, true, false, false },7f); 
            yield return new TestCaseData(3, 50,new int[] { 10, 20, 30 },new float[] { 60f, 100f, 120f },new bool[] { false, true, true },220f);
            yield return new TestCaseData(5, 10,new int[] { 4, 3, 5, 2, 1 },new float[] { 10f, 4f, 8f, 3f, 1f },new bool[] { true, false, true, false, true },19f);

            //Edge case: No capacity
            yield return new TestCaseData(6, 0, new int[] { 1, 2, 3, 4, 5, 6 }, new float[] { 1f, 2f, 3f, 4f, 5f, 6f }, new bool[] { false, false, false, false, false, false }, 0f);
           
            //Edge case: No items fit
            yield return new TestCaseData(4, 5, new int[] { 8, 6, 10, 9 }, new float[] {  3f, 4f, 5f, 6f }, new bool[] { false, false, false, false }, 0f);
           
            //Edge case: All items fit exactly
            yield return new TestCaseData(3, 20, new int[] { 5,5,10 }, new float[] { 8f, 2f, 5f }, new bool[] { true, true, true }, 15f);


        }
    }
}
