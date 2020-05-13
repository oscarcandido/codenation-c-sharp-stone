using System;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var Crypt = new Codenation.Challenge.CesarCypher();
            Console.WriteLine(Crypt.Crypt("The quick brown fox jumps over the lazy dog"));
            Console.WriteLine(Crypt.Decrypt("wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj"));
        }
    }
}
