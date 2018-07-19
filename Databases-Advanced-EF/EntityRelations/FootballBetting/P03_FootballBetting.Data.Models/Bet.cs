using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        public int BetId { get; set; }

        public decimal Ammount { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public string Prediction { get; set; }

        public DateTime BetDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
