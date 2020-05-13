using System;
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var Math = new Codenation.Challenge.Math();
            var fib = Math.Fibonacci();
            foreach( int item in fib)
            {
                Console.WriteLine(item);
            }
        }
    }
}

