// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

using System;
using FestivalManager.Core.Controllers;
using FestivalManager.Entities;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
    using FestivalManager.Entities.Contracts;
    using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void EmptySetCannotPerform()
	    {
	        string expected = "1. shortSet:" + Environment.NewLine + "-- Did not perform";

            IStage stage = new Stage();
	        string setName = "shortSet";
            ISet set = new Short(setName);
            stage.AddSet(set);

            var setController = new SetController(stage);
	        string result = setController.PerformSets();

            Assert.That(result, Is.EqualTo(expected));
	    }

        [Test]
        public void SetWithSongAndPerformer()
        {
            string expected = "1. mediumSet:" + Environment.NewLine + "-- 1. Song1 (05:00)" + Environment.NewLine + "-- Set Successful";

            string songName = "Song1";
            var duration = new TimeSpan(0, 5, 0);
            ISong song = new Song(songName, duration);

            string performerName = "Pesho";
            int age = 20;
            var performer = new Performer(performerName, age);
            var guitar = new Guitar();
            performer.AddInstrument(guitar);

            IStage stage = new Stage();

            string setName = "mediumSet";
            ISet set = new Medium(setName);

            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddSet(set);

            var setController = new SetController(stage);
            string result = setController.PerformSets();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void OneSuccesfulSetAndOneFailed()
        {
            string expected = "1. mediumSet:" + Environment.NewLine + "-- 1. Song1 (05:00)" + Environment.NewLine + "-- Set Successful" + Environment.NewLine +
            "2. shortSet:" + Environment.NewLine + "-- Did not perform";

            IStage stage = new Stage();

            string firstSetName = "shortSet";
            ISet set1 = new Short(firstSetName);
            stage.AddSet(set1);

            string songName = "Song1";
            var duration = new TimeSpan(0, 5, 0);
            ISong song = new Song(songName, duration);

            string performerName = "Pesho";
            int age = 20;
            var performer = new Performer(performerName, age);
            var guitar = new Guitar();
            performer.AddInstrument(guitar);

            string secondSetName = "mediumSet";
            ISet set2 = new Medium(secondSetName);

            set2.AddPerformer(performer);
            set2.AddSong(song);
            stage.AddSet(set2);

            var setController = new SetController(stage);
            string result = setController.PerformSets();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MoreThanOneSuccesfulSet()
        {
            string expected = "1. mediumSet:" + Environment.NewLine + "-- 1. Song1 (05:00)" + Environment.NewLine + "-- Set Successful" + Environment.NewLine +
                              "2. shortSet:" + Environment.NewLine + "-- Did not perform";

            IStage stage = new Stage();

            string firstSetName = "shortSet";
            ISet set1 = new Short(firstSetName);
            stage.AddSet(set1);

            string songName = "Song1";
            var duration = new TimeSpan(0, 5, 0);
            ISong song = new Song(songName, duration);

            string performerName = "Pesho";
            int age = 20;
            var performer = new Performer(performerName, age);
            var guitar = new Guitar();
            performer.AddInstrument(guitar);

            string secondSetName = "mediumSet";
            ISet set2 = new Medium(secondSetName);

            set2.AddPerformer(performer);
            set2.AddSong(song);
            stage.AddSet(set2);

            var setController = new SetController(stage);
            string result = setController.PerformSets();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}