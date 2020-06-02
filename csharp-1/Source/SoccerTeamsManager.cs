using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source.Model;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        public SoccerTeamsManager()
        {
            Tabelas.Times = new List<Time>();
            Tabelas.Jogadores = new List<Jogador>();
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (Verificacoes<Time>.Exite(Tabelas.Times, id)) throw new UniqueIdentifierException();
            Time _time = new Time(id, name, createDate, mainShirtColor, secondaryShirtColor);
            Tabelas.Times.Add(_time);
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            Verificacoes<Jogador>.VerificaId(Tabelas.Jogadores, id);
            if (!Verificacoes<Time>.Exite(Tabelas.Times, teamId)) throw new TeamNotFoundException();
            Jogador _jogador = new Jogador(id, teamId, name, birthDate, skillLevel, salary);
            Tabelas.Jogadores.Add(_jogador);
        }

        public void SetCaptain(long playerId)
        {
            if (!Verificacoes<Jogador>.Exite(Tabelas.Jogadores, playerId)) throw new PlayerNotFoundException();
            Tabelas.Jogadores.Where(x => x.id == playerId).Single().DefineCapitao();
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!Verificacoes<Time>.Exite(Tabelas.Times, teamId)) throw new TeamNotFoundException();
            Jogador Capitao = Tabelas.Jogadores.Where(x => x.teamId == teamId && x.Capitao).SingleOrDefault();
            if (Capitao == null)
            {
                throw new Codenation.Challenge.Exceptions.CaptainNotFoundException();
            }
            else
            {
              return Capitao.id;
            }
        }

        public string GetPlayerName(long playerId)
        {
            if (!Verificacoes<Jogador>.Exite(Tabelas.Jogadores, playerId)) throw new PlayerNotFoundException();
            return Tabelas.Jogadores.Where(x => x.id == playerId).Select(x => x.name).SingleOrDefault();
        }

        public string GetTeamName(long teamId)
        {
            if (!Verificacoes<Time>.Exite(Tabelas.Times, teamId)) throw new TeamNotFoundException();
            return Tabelas.Times.Where(x => x.id == teamId).Select(x => x.name).SingleOrDefault();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (!Verificacoes<Time>.Exite(Tabelas.Times, teamId)) throw new TeamNotFoundException();
            var Players = Tabelas.Jogadores.Where(x => x.teamId == teamId).Select(x => x.id).ToList();
            Players.Sort();
            return Players;
        }

        public long GetBestTeamPlayer(long teamId)
        {
            if (!Verificacoes<Time>.Exite(Tabelas.Times, teamId)) throw new TeamNotFoundException();
            var BestPlayer = Tabelas.Jogadores.Where(x => x.teamId == teamId && x.skillLevel == Tabelas.Jogadores.Where(y => y.teamId == teamId).Max(y => y.skillLevel));
            if (BestPlayer.Count() > 1)
            {
               return BestPlayer.Where(x => x.id == BestPlayer.Min(y => y.id)).Select(x => x.id).Single();
            }
            else
            {
                return BestPlayer.Select(x => x.id).Single();
            }
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (!Verificacoes<Time>.Exite(Tabelas.Times, teamId)) throw new TeamNotFoundException();
            var OlderPlayer = Tabelas.Jogadores.Where(x => x.teamId == teamId && x.birthDate == Tabelas.Jogadores.Where(y => y.teamId == teamId).Min(y => y.birthDate)).Select(x => x.id).Min();
            
            return OlderPlayer;
        }

        public List<long> GetTeams()
        {
            return Tabelas.Times.Select(x => x.id).OrderBy(x => x).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            if (!Verificacoes<Time>.Exite(Tabelas.Times, teamId)) throw new TeamNotFoundException();
            var Players = Tabelas.Jogadores.Where(x => x.teamId == teamId).ToList();
            var MaxSalary = Players.Max(x => x.salary);
            return Players.Where(x => x.salary == MaxSalary).Select(x => x.id).SingleOrDefault();
        }
        public decimal GetPlayerSalary(long playerId)
        {
            if (!Verificacoes<Jogador>.Exite(Tabelas.Jogadores, playerId)) throw new PlayerNotFoundException();
            return Tabelas.Jogadores.Where(x => x.id == playerId).Select(x => x.salary).SingleOrDefault();
        }

        public List<long> GetTopPlayers(int top)
        {
            return Tabelas.Jogadores.OrderByDescending(x => x.skillLevel).Take(top).Select(x => x.id).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            if (!Verificacoes<Time>.Exite(Tabelas.Times, teamId)) throw new TeamNotFoundException();
            if (!Verificacoes<Time>.Exite(Tabelas.Times, visitorTeamId)) throw new TeamNotFoundException();
            var corCasa = Tabelas.Times.Where(x => x.id == teamId).Select(x => x.corUniformePrincipal).SingleOrDefault();
            var corVisitante = Tabelas.Times.Where(x => x.id == visitorTeamId).Select(x => x.corUniformePrincipal).SingleOrDefault();
            if(corCasa != corVisitante)
            {
                return corVisitante;
            }
            else
            {
                return Tabelas.Times.Where(x => x.id == visitorTeamId).Select(x => x.corUniformeSecundario).SingleOrDefault();
            }

        }

    }
}
