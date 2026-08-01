using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.Knapsack
{
    public interface IKnapsackSolver
    {
        float OptimalValue();
        bool[] OptimalSolution();
        int StepCount { get; }
    }
}
