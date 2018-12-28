using AutoFixture;
using Moq;

namespace Sudoku.Tests.TestSupport.Extensions
{
    public static class FixtureExtensions
    {
        public static Mock<T> Mock<T>(this IFixture fixture)
            where T : class
        {
            var mock = fixture.Create<Mock<T>>();
            fixture.Register(() => mock.Object);
            return mock;
        }
    }
}
