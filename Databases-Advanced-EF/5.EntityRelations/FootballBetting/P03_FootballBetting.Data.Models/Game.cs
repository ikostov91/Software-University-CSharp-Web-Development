using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public int AwayTeamBetRate { get; set; }

        public int AwayTeamGoals { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int DrawBetRate { get; set; }

        public int HomeTeamBetRate { get; set; }

        public int HomeTeamGoals { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public string Result { get; set; }

        public DateTime GameDate { get; set; }

        public ICollection<Bet> Bets { get; set; }

        public ICollection<PlayerStatistic> Players { get; set; }
    }
}
