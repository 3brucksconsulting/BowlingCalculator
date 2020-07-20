using System.Linq;
using Xunit;
using FluentAssertions;

namespace BowlingCalculator.Tests
{
    public class CalculatorTests
    {
        private Calculator _sut;

        public CalculatorTests()
        {
            _sut = new Calculator();
        }

        [Fact]
        public void CalculateScore_GivenAllZeros_Returns0()
        {
            AddRepeatedRolls(0, 20);

            var result = _sut.CalculateScore();

            result.Should().Be(0);
        }

        [Fact]
        public void CalculateScore_GivenAllOnes_Returns20()
        {
            AddRepeatedRolls(1, 20);

            var result = _sut.CalculateScore();

            result.Should().Be(20);
        }

        [Fact]
        public void CalculateScore_GivenSpareNine_Returns28()
        {
            AddRolls(8, 2, 9);
            AddRepeatedRolls(0, 17);

            var result = _sut.CalculateScore();

            result.Should().Be(28);
        }


        private void AddRolls(params int[] rolls)
        {
            rolls.ToList().ForEach(x => _sut.AddRoll(x));
        }

        private void AddRepeatedRolls(int roll, int count)
        {
            Enumerable.Repeat(roll, count).ToList().ForEach(x => _sut.AddRoll(x));
        }

    }
}
