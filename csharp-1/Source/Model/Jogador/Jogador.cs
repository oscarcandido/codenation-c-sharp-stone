using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Source.Model
{
    public class Jogador :ITabela
    {
        public long id { get; set; }
        public long teamId { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public int skillLevel { get; set; }
        public decimal salary { get; set; }

        public bool Capitao { get; set; }

        public Jogador(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            this.id = id;
            this.teamId = teamId;
            this.name = name;
            this.birthDate = birthDate;
            this.skillLevel = skillLevel;
            this.salary = salary;
        }

        public void DefineCapitao()
        {
            if(Tabelas.Jogadores.Any(x => x.teamId == teamId && x.Capitao))
            {
                Tabelas.Jogadores.Where(x => x.teamId == teamId && x.Capitao).Single().Capitao = false;
            }
            Capitao = true;
        }
    }
}
