using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            this.ParticipatingUsers = new List<UserTeam>();
            this.EventTeams = new List<EventTeam>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(3)]
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<UserTeam> ParticipatingUsers { get; set; }

        public ICollection<EventTeam> EventTeams { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
    }
}
