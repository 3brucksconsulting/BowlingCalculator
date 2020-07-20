using System;
using System.Linq;

namespace BowlingCalculator
{
    public class Frame
    {
        private int[] _rolls = new int[21];
        private int _nextRoll = 0;

        public void AddRoll(int pin)
        {
            _rolls[_nextRoll++] = pin;
        }

        public int GetScore()
        {
            return _rolls.Sum();
        }
    }
}
