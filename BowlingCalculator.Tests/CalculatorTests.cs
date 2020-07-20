using FluentAssertions;
using System.Linq;
using Xunit;

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
        public void CalculateScore_GivenAllGutters_Returns0()
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
            AddRolls(8, 2, 9, 0);
            AddRepeatedRolls(0, 17);

            var result = _sut.CalculateScore();

            result.Should().Be(28);
        }

        [Fact]
        public void CalculateScore_GivenStrikeEight_Returns26()
        {
            AddRolls(10, 6, 2);
            AddRepeatedRolls(0, 16);

            var result = _sut.CalculateScore();

            result.Should().Be(26);
        }

        [Fact]
        public void CalculateScore_GivenAPerfectGame_Returns300()
        {
            AddRepeatedRolls(10, 12);

            var result = _sut.CalculateScore();

            result.Should().Be(300);
        }

        [Fact]
        public void CalculateScore_GivenRandomCompleteGame_Returns174()
        {
            AddRolls(8, 1, 10, 10, 10, 8, 2, 3, 6, 9, 0, 9, 1, 9, 1, 7, 3, 10);

            var result = _sut.CalculateScore();

            result.Should().Be(174);
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