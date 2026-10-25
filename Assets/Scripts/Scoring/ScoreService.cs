using System;

namespace HomeAssignment.Scoring
{
    public class ScoreService
    {
        public int CurrentScore { get; private set; }
        public int HighScore { get; private set; }

        public event Action<int> ScoreChanged;

        public void AddPoints(int points)
        {
            CurrentScore += points;

            if (CurrentScore > HighScore)
            {
                HighScore = CurrentScore;
            }

            ScoreChanged?.Invoke(CurrentScore);
        }

        public void ResetScore()
        {
            CurrentScore = 0;
            ScoreChanged?.Invoke(CurrentScore);
        }
    }
}
