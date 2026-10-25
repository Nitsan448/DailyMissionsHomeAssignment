using System.Collections.Generic;
using HomeAssignment.Scoring;
using NUnit.Framework;

namespace HomeAssignment.Tests.EditMode
{
    public class ScoreServiceTests
    {
        [Test]
        public void AddPoints_AccumulatesAcrossCalls()
        {
            var scoreService = new ScoreService();

            scoreService.AddPoints(10);
            scoreService.AddPoints(15);

            Assert.That(scoreService.CurrentScore, Is.EqualTo(25));
        }

        [TestCase(0, 0)]
        [TestCase(7, 7)]
        [TestCase(-3, -3)]
        public void AddPoints_SetsCurrentScoreToPointsAdded(int points, int expectedScore)
        {
            var scoreService = new ScoreService();

            scoreService.AddPoints(points);

            Assert.That(scoreService.CurrentScore, Is.EqualTo(expectedScore));
        }

        [Test]
        public void AddPoints_RaisesScoreChangedWithNewScore()
        {
            var scoreService = new ScoreService();
            var reportedScores = new List<int>();
            scoreService.ScoreChanged += reportedScores.Add;

            scoreService.AddPoints(10);
            scoreService.AddPoints(5);

            Assert.That(reportedScores, Is.EqualTo(new[] { 10, 15 }));
        }

        [Test]
        public void ResetScore_ClearsCurrentScoreButKeepsHighScore()
        {
            var scoreService = new ScoreService();
            scoreService.AddPoints(40);

            scoreService.ResetScore();

            Assert.That(scoreService.CurrentScore, Is.Zero);
            Assert.That(scoreService.HighScore, Is.EqualTo(40));
        }

        [Test]
        public void HighScore_KeepsBestRunWhenLaterRunScoresLower()
        {
            var scoreService = new ScoreService();
            scoreService.AddPoints(40);
            scoreService.ResetScore();

            scoreService.AddPoints(25);

            Assert.That(scoreService.HighScore, Is.EqualTo(40));
        }
    }
}
