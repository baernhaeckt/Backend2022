using FluentAssertions;
using Xunit;

namespace Web.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            true.Should().BeTrue();
        }
    }
}