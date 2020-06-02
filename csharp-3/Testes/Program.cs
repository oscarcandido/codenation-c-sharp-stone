using System;
using Codenation.Challenge;
namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            State[] States = new Country().Top10StatesByArea();
            for (int i = 0; i < States.Length; i++)
            {
                Console.WriteLine("{0}:{1}", States[i].Acronym, States[i].Area);
            }
        }
    }
}
