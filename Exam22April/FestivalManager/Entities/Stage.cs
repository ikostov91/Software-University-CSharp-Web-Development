using System;
using System.Linq;

namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
	    private readonly List<ISong> songs;
	    private readonly List<IPerformer> performers;

	    public Stage()
	    {
	        this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
	    }

        IReadOnlyCollection<ISet> IStage.Sets => sets;

        IReadOnlyCollection<ISong> IStage.Songs => songs;

        IReadOnlyCollection<IPerformer> IStage.Performers => performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            if (!HasPerformer(name))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            return this.performers.FirstOrDefault(n => n.Name == name);
        }

        public ISet GetSet(string name)
        {
            if (!HasSet(name))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            return this.sets.FirstOrDefault(n => n.Name == name);
        }

        public ISong GetSong(string name)
        {
            if (!HasSong(name))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            return this.songs.FirstOrDefault(n => n.Name == name);
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Exists(n => n.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.sets.Exists(n => n.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.songs.Exists(n => n.Name == name);
        }
    }
}
