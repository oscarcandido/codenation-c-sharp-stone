using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> fibonacciList = new List<int>() { 0, 1 };
            do
            {
                fibonacciList.Add(fibonacciList[fibonacciList.Count - 1] + fibonacciList[fibonacciList.Count - 2]);
            }
            while (fibonacciList[fibonacciList.Count - 1] + fibonacciList[fibonacciList.Count - 2] < 350);
            return fibonacciList;
        }

        public bool IsFibonacci(int numberToTest)
        {
            var Sequence = Fibonacci();
            return Sequence.Contains(numberToTest);
        }
    }
}
