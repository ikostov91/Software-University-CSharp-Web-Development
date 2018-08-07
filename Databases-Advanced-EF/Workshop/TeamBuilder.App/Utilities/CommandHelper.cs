using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Utilities
{
    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(x => x.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Users.Any(x => x.Username == username);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Invitations.Any(x => x.Team.Name == teamName && x.InvitedUserId == user.Id && x.IsActive);
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams
                           .Single(x => x.Name == teamName)
                           .Creator.Username == user.Username;
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Events
                           .Single(x => x.Name == eventName)
                           .Creator.Username == user.Username;
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams
                    .Single(x => x.Name == teamName)
                    .ParticipatingUsers.Any(x => x.User.Username == username);
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Events.Any(x => x.Name == eventName);
            }
        }
    }
}
