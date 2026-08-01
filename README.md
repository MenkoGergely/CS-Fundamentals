# CS Fundementals
A collection of computer science algorithms and data structures in C#, as part of university coursework and personal practice.

## Contents
- **0/1 Knapsack problem:** Solved with brute force, dynamic programming, bracktracking, and branch and bound, all behind IKnapsackSolver interfacel.
- **Graph traversal:** -- BFS, and DFS, built on custom binary search tree based set.

## Structure
**`Datastructures/`** Custom set (tree based), graph, and their interfaces
**`Optimization/`** Knapsack problem + the four solvers
**`OptimizationTester/`** NUnit tests on all solvers
**`Benchmark/`** Commpare runtime and step count of the solvers

Complexity
| Solver | Time complexity |
| :--- | :--- |
| **Bruteforce** | O(2ⁿ) |
| **Dynamic programming** | O(n · W) |
| **Backtracking** | O(2ⁿ) worst case |
| **Branch and bound** | O(2ⁿ) worst case, much faster in practice |

## Running 
*Requires the .NET 9 SDK.*
```bash
dotnet test
dotnet run --project Benchmark 
