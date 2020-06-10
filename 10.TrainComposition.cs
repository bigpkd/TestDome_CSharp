/*
10. Train Composition [Algorithmic thinking] [Linked list] 

A TrainComposition is built by attaching and detaching wagons from the left and the right sides, efficiently with respect to time used.

For example, if we start by attaching wagon 7 from the left followed by attaching wagon 13, again from the left, we get a composition of two wagons (13 and 7 from left to right). Now the first wagon that can be detached from the right is 7 and the first that can be detached from the left is 13.

Implement a TrainComposition that models this problem.

https://www.testdome.com/d/c-sharp-interview-questions/18

using System;

public class TrainComposition
{
    public void AttachWagonFromLeft(int wagonId)
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public void AttachWagonFromRight(int wagonId)
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public int DetachWagonFromLeft()
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public int DetachWagonFromRight()
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public static void Main(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7 
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}
*/ 

// =============================================================== solution (passes 3/3 tests)

using System;

public class TrainComposition
{
    public class Wagon
    {
        public Wagon LeftWagon { get; set; }
        public Wagon RightWagon { get; set; }
        public int WagonId { get; set; }

        public Wagon(int wagonId)
        {
            WagonId = wagonId;
            LeftWagon = null;
            RightWagon = null;
        }
    }

    private Wagon LeftMostWagon { get; set; }
    private Wagon RightMostWagon { get; set; }

    public TrainComposition()
    {
        LeftMostWagon = null;
        RightMostWagon = null;
    }

    public void AttachWagonFromLeft(int wagonId)
    {
        Wagon newWagon = new Wagon(wagonId);
        if (LeftMostWagon is null)
        {
            LeftMostWagon = newWagon;
            RightMostWagon = newWagon;
        }
        else
        {
            newWagon.RightWagon = LeftMostWagon;
            LeftMostWagon.LeftWagon = newWagon;
            LeftMostWagon = newWagon;
        }
    }

    public void AttachWagonFromRight(int wagonId)
    {
        Wagon newWagon = new Wagon(wagonId);
        if (RightMostWagon is null)
        {
            RightMostWagon = newWagon;
            LeftMostWagon = newWagon;
        }
        else
        {
            newWagon.LeftWagon = RightMostWagon;
            RightMostWagon.RightWagon = newWagon;
            RightMostWagon = newWagon;
        }
    }

    public int DetachWagonFromLeft()
    {
        int detachedWagonId = -1;
        if (LeftMostWagon == null) return detachedWagonId;
        detachedWagonId = LeftMostWagon.WagonId;
        LeftMostWagon = LeftMostWagon.RightWagon;
        if (LeftMostWagon == null)
            RightMostWagon = null; // to ensure train state consistency (no wagon in train)
        else
            LeftMostWagon.LeftWagon = null;
        return detachedWagonId;
    }

    public int DetachWagonFromRight()
    {
        int detachedWagonId = -1;
        if (RightMostWagon == null) return detachedWagonId;
        detachedWagonId = RightMostWagon.WagonId;
        RightMostWagon = RightMostWagon.LeftWagon;
        if (RightMostWagon == null)
            LeftMostWagon = null; // to ensure train state consistency (no wagon in train)
        else
            RightMostWagon.RightWagon = null;
        return detachedWagonId;
    }

    public static void Main(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7 
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}