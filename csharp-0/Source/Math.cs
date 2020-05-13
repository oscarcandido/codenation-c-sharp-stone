using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> FibonacciList = new List<int>() { 0, 1 };
            do
            {
                FibonacciList.Add(FibonacciList[FibonacciList.Count - 1] + FibonacciList[FibonacciList.Count - 2]);
            }
            while (FibonacciList[FibonacciList.Count - 1] + FibonacciList[FibonacciList.Count - 2] < 350);
            return FibonacciList;
        }

        public bool IsFibonacci(int numberToTest)
        {
            var Sequence = Fibonacci();
            return Sequence.Contains(numberToTest);
        }
    }
}
