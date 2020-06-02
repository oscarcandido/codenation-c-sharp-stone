using System;
using Source.Model;
using Codenation.Challenge;
using System.Linq;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            SoccerTeamsManager Stm = new SoccerTeamsManager();
            Stm.AddTeam(1, "galo", new DateTime(2020, 05, 01), "preto e branco", "branco");
            Stm.AddPlayer(2, 1, "Tardelli", new DateTime(2000, 5, 2), 90, 10000m);
            Stm.AddPlayer(0, 1, "Victor", new DateTime(1990, 5, 2), 80, 100m);
            Stm.AddPlayer(1, 1, "Ronaldo", new DateTime(1984, 5, 2), 100, 1000m);
            Stm.SetCaptain(2);
            Console.WriteLine("O capitão é:{0}", Tabelas.Jogadores.Where(x => x.teamId == 1 && x.Capitao).Select(x => x.name).Single());
            Stm.SetCaptain(1);
            Console.WriteLine("O capitão é:{0}", Tabelas.Jogadores.Where(x => x.teamId == 1 && x.Capitao).Select(x => x.name).Single());
            Console.WriteLine(Stm.GetTeamCaptain(1));
            Console.WriteLine(Stm.GetPlayerName(0));
            Console.WriteLine(Stm.GetTeamName(1));
            var jog = Stm.GetTeamPlayers(1);
            jog.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(Stm.GetBestTeamPlayer(1));
            Console.WriteLine(Stm.GetOlderTeamPlayer(1));
            Console.WriteLine(Stm.GetTeams());
            Console.WriteLine(Stm.GetHigherSalaryPlayer(1));

        }
    }
}
