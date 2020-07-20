using System.Linq;
using Xunit;
using FluentAssertions;

namespace BowlingCalculator.Tests
{
    public class FrameTests
    {
        [Fact]
        public void CreateNewFrame()
        {
            var sut = new Frame();
        }

        [Fact]
        public void GetScore_GivenAllZeros_Returns0()
        {
            var sut = new Frame();

            Enumerable.Repeat(0, 20).ToList().ForEach(x => sut.AddRoll(x));

            var result = sut.GetScore();

            result.Should().Be(0);
        }
    }
}
