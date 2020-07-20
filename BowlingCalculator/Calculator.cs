using System;

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

            Func<bool>
                isStrike = () => _rolls[rollIndex] == 10,
                isSpare = () => _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;

            Func<int>
                calculateStrike = () => 10 + _rolls[rollIndex + 1] + _rolls[rollIndex + 2],
                calculateSpare = () => 10 + _rolls[rollIndex + 2],
                calculateOpenFrame = () => _rolls[rollIndex] + _rolls[rollIndex + 1];

            for (var frame = 0; frame < 10; frame++)
            {
                if (isStrike())
                {
                    score += calculateStrike();
                    rollIndex++;
                }
                else if (isSpare())
                {
                    score += calculateSpare();
                    rollIndex += 2;
                }
                else
                {
                    score += calculateOpenFrame();
                    rollIndex += 2;
                }
            }

            return score;
        }
    }
}