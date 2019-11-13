using MishMashWebApp.ViewModels.Channels;
using MishMashWebApp.ViewModels.Home;
using SIS.HTTP.Responses;
using System.Linq;

namespace MishMashWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == User.Username);

            if (user != null)
            {
                var viewModel = new LoggedInIndexViewModel();
                
                viewModel.YourChannels = this.Db.Channels
                    .Where(f => f.Followers.Any(u => u.User.Username == User.Username))
                    .Select(c => new BaseChannelViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = c.Type,
                        FollowersCount = c.Followers.Count
                    }).ToList();

                var followedChannelsTags = this.Db.Channels
                    .Where(f => f.Followers.Any(u => u.User.Username == User.Username))
                    .SelectMany(x => x.Tags.Select(t => t.Tag.Id))
                    .Distinct()
                    .ToList();

                viewModel.SuggestedChannels = this.Db.Channels
                    .Where(f => !f.Followers.Any(u => u.User.Username == User.Username) && f.Tags.Any(t => followedChannelsTags.Contains(t.Tag.Id)))
                    .Select(c => new BaseChannelViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = c.Type,
                        FollowersCount = c.Followers.Count
                    })
                    .ToList();

                var ids = viewModel.YourChannels.Select(x => x.Id).ToList();
                ids = ids.Concat(viewModel.SuggestedChannels.Select(x => x.Id)).ToList();
                ids = ids.Distinct().ToList();

                viewModel.SeeOtherChannels = this.Db.Channels.Where(x => !ids.Contains(x.Id))
                    .Select(x => new BaseChannelViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Type = x.Type,
                        FollowersCount = x.Followers.Count
                    })
                    .ToList();

                return this.View("Home/LoggedInIndex", viewModel);
            }
            else
            {
                return this.View();
            }
        }
    }
}
