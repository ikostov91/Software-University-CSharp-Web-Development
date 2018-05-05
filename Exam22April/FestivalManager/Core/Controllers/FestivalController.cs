using System.Collections.Generic;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;

	public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

	    private IPerformerFactory performerFactory;
	    private IInstrumentFactory instrumentFactory;
	    private ISetFactory setFactory;
	    private ISongFactory songFactory;
		private readonly IStage stage;

		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.performerFactory = new PerformerFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
		}

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

		    result += ($"Festival length: {string.Format("{0:D2}:{1:D2}", (int)totalFestivalLength.TotalMinutes, totalFestivalLength.Seconds)}") + "\n";

            foreach (var set in this.stage.Sets)
			{
			    result += ($"--{set.Name} ({string.Format("{0:D2}:{1:D2}", (int)set.ActualDuration.TotalMinutes, set.ActualDuration.Seconds)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.TrimEnd();
		}

		public string RegisterSet(params string[] parameters)
		{
		    string name = parameters[0];
		    string type = parameters[1];

		    ISet set = setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

		    return $"Registered {type} set";
		}

		public string SignUpPerformer(string[] parameters)
		{
		    string name = parameters[0];
			int age = int.Parse(parameters[1]);

			var instrumentsList = parameters.Skip(2).ToArray();

			IInstrument[] instruments = instrumentsList
                .Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
			var songName = args[0];
			var durationArgs = args[1].Split(':');
		    var minutes = int.Parse(durationArgs[0]);
		    var seconds = int.Parse(durationArgs[1]);
		    var duration = new TimeSpan(0, minutes, seconds);

            var song = songFactory.CreateSong(songName, duration);
            this.stage.AddSong(song);

            return $"Registered song {songName} ({duration:mm\\:ss})";
		}

		public string AddPerformerToSet(string[] args)
		{
		    var performerName = args[0];
		    var setName = args[1];

		    if (!this.stage.HasPerformer(performerName))
		    {
                throw new InvalidOperationException("Invalid performer provided");
            }

		    if (!this.stage.HasSet(setName))
		    {
                throw new InvalidOperationException("Invalid set provided");
            }

		    var performer = this.stage.GetPerformer(performerName);
		    var set = this.stage.GetSet(setName);

		    set.AddPerformer(performer);

		    return $"Added {performer.Name} to {set.Name}";
        }

		public string RepairInstruments(string[] args)
		{
		    int count = 0;
		    foreach (var performer in this.stage.Performers)
		    {
		        foreach (var instrument in performer.Instruments.Where(w => w.Wear < 100))
		        {
                    instrument.Repair();
		            count++;
		        }
		    }

			return $"Repaired {count} instruments";
		}

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var set = this.stage.Sets.FirstOrDefault(n => n.Name == setName);

            if (!this.stage.HasSong(songName))
            {
               throw new InvalidOperationException("Invalid song provided");
            }

            var song = this.stage.Songs.FirstOrDefault(n => n.Name == songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }

        public object Report()
        {
            StringBuilder sb = new StringBuilder();

            return sb;
        }
    }
}