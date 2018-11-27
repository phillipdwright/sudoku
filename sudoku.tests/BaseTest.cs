using AutoFixture;
using NUnit.Framework;

namespace Sudoku.Tests
{
    public class BaseTest
    {
        protected Fixture Fixture { get; private set; }

        [SetUp]
        public void BaseSetup()
        {
            Fixture = new Fixture();
        }
    }
}
