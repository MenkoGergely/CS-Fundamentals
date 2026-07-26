namespace Optimization.Knapsack;

public class KnapsackProblem
{
    public int ItemCount { get; }
    public int MaxWeight { get; }
    public int[] Weights { get; }
    public float[] Values { get; }
    public KnapsackProblem(int itemCount, int maxWeight, int[] weights, float[] values)
    {
        ItemCount = itemCount;
        MaxWeight = maxWeight;
        Weights = weights;
        Values = values;
    }
    public int TotalWeight(bool[] selection)
    {
        int totalWeight = 0;
        for (int i = 0; i < ItemCount; i++)
        {
            if (selection[i])
                totalWeight += Weights[i];
        }
        return totalWeight;
    }
    public float TotalValue(bool[] selection)
    {
        float totalValue = 0;
        for (int i = 0; i < ItemCount; i++)
        {
            if (selection[i])
                totalValue += Values[i];
        }
        return totalValue;
    }
    public bool IsValid(bool[] selection)
    {
        return TotalWeight(selection) <= MaxWeight;
    }
}