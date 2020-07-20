using System;
using System.Linq;

namespace BowlingCalculator
{
    public class Calculator
    {
        private int[] _rolls = new int[21];
        private int _nextRoll = 0;

        public void AddRoll(int pin)
        {
            _rolls[_nextRoll++] = pin;
        }

        public int CalculateScore()
        {
            int rollIndex = 0;
            int score = 0;

            for (var frame = 0; frame < 10; frame++)
            {
                // Strike
                if (_rolls[rollIndex] == 10)
                {
                    score += 10 + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
                    rollIndex++;
                }
                // Spare
                else if (_rolls[rollIndex] + _rolls[rollIndex + 1] == 10)
                {
                    score += 10 + _rolls[rollIndex + 2];
                    rollIndex += 2;
                }
                else
                {
                    score += _rolls[rollIndex] + _rolls[rollIndex + 1];
                    rollIndex += 2;
                }
            }

            return score;
        }
    }
}
