using AutoFixture;
using NUnit.Framework;

using Sudoku.Library;

namespace Sudoku.Tests
{
    public class CellTests : BaseTest
    {
        private Cell _cell;

        [SetUp]
        public void Setup()
        {
            _cell = Fixture.Build<Cell>()
                .OmitAutoProperties()
                .Create();
        }

        [Test]
        public void IsEmpty_GivenNoValueSpecified_ReturnsTrue()
        {
            Assert.That(_cell.IsEmpty);
        }

        [Test]
        public void IsEmpty_GivenAValueSpecified_ReturnsFalse()
        {
            SpecifyAValue(_cell);

            Assert.That(_cell.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_GivenAValueSpecifiedAndCleared_ReturnsTrue()
        {
            SpecifyAValue(_cell);
            ClearValue(_cell);

            Assert.That(_cell.IsEmpty);
        }

        private void SpecifyAValue(Cell cell)
            => cell.Value = Fixture.Create<CellValue>();

        private void ClearValue(Cell cell)
            => cell.Value = null;
    }
}
