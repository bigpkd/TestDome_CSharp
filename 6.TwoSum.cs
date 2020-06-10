/*
6. Two Sum [Algorithmic thinking] [Dictionary]

Write a function that, when passed a list and a target sum, returns, efficiently with respect to time used, two distinct zero-based indices of any two of the numbers, whose sum is equal to the target sum. If there are no two numbers, the function should return null.

https://www.testdome.com/d/c-sharp-interview-questions/18

using System;
using System.Collections.Generic;

class TwoSum
{
    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public static void Main(string[] args)
    {
        Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if(indices != null) 
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }
}
*/ 

// =============================================================== solution (passes 3/4 tests)

using System;
using System.Collections.Generic;

class TwoSum
{
    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        var indexes = new List<Tuple<int,int>>();
        var indices = new Dictionary<int,int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (indices.ContainsValue(sum - list[i]))
            {
                indexes.Add(new Tuple<int,int>(list.IndexOf(sum - list[i]), i));
            }
            indices.Add(i, list[i]);
        }
        return indexes.Count == 0 ? null : indexes[RandomInt(indexes.Count)];
    }

    public static int RandomInt(int max)
    {
        Random random = new Random(); 
        object syncLock = new object(); 
        lock(syncLock) { 
            return random.Next(0, max);
        }
    }

    public static void Main(string[] args)
    {
        Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if(indices != null) 
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }
}