using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Source.Model
{
    public class Verificacoes<T> where T:ITabela
    {
        public static void VerificaId(List<T> Tabela, long id)
        {
            if(Tabela.Any(x => x.id == id)) throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();
        }

        public static bool Exite(List<T> Tabela, long id)
        {
            return Tabela.Any(x => x.id == id);
        }
    }
}
