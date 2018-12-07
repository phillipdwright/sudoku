using System.Linq;
using AutoFixture;
using NUnit.Framework;

using Sudoku.Library;
using Sudoku.Library.Validation;

namespace Sudoku.Tests.Validation
{
    public class CellSetValidatorTests : BaseTest
    {
        private CellSetValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = Fixture.Create<CellSetValidator>();
        }

        [Test]
        public void IsValid_GivenEmptyCellSet_ReturnsTrue()
        {
            var cellSet = Given_EmptyCellSet();

            Assert.That(_validator.IsValid(cellSet));
        }

        [Test]
        public void IsValid_GivenNonEmptyCellSetWithAllEmptyCells_ReturnsTrue()
        {
            var cellSet = Given_NonEmptyCellSetWithAllEmptyCells();

            Assert.That(_validator.IsValid(cellSet));
        }

        [Test]
        public void IsValid_GivenCellSetWithExactlyOneNonemptyCell_ReturnsTrue()
        {
            var cellSet = Given_CellSetWithExactlyOneNonemptyCell();

            Assert.That(_validator.IsValid(cellSet));
        }

        [Test]
        public void IsValid_GivenCellSetWithMultipleNonemptyCellsAllWithDifferentValues_ReturnsTrue()
        {
            var cellSet = Given_CellSetWithMultipleNonemptyCellsAllWithDifferentValues();

            Assert.That(_validator.IsValid(cellSet));
        }

        [Test]
        public void IsValid_GivenCellSetWithMultipleNonemptyCellsWithTheSameValue_ReturnsFalse()
        {
            var cellSet = Given_CellSetWithMultipleNonemptyCellsWithTheSameValue();

            Assert.That(_validator.IsValid(cellSet), Is.False);
        }

        private CellSet Given_CellSetWithMultipleNonemptyCellsWithTheSameValue()
        {
            var cellSet = Given_NonEmptyCellSetWithAllEmptyCells();
            cellSet.First().Value = Fixture.Create<CellValue>();
            cellSet.Skip(1).First().Value = cellSet.First().Value;
            return cellSet;
        }

        private CellSet Given_CellSetWithMultipleNonemptyCellsAllWithDifferentValues()
        {
            var cellSet = Given_NonEmptyCellSetWithAllEmptyCells();
            cellSet.First().Value = Fixture.Create<CellValue>();
            do
            {
                cellSet.Skip(1).First().Value = Fixture.Create<CellValue>();
            }
            while (cellSet.First().Value == cellSet.Skip(1).First().Value);
            return cellSet;
        }

        private CellSet Given_CellSetWithExactlyOneNonemptyCell()
        {
            var cellSet = Given_NonEmptyCellSetWithAllEmptyCells();
            cellSet.First().Value = Fixture.Create<CellValue>();
            return cellSet;
        }

        private CellSet Given_NonEmptyCellSetWithAllEmptyCells()
        {
            var cellSet = Given_EmptyCellSet();
            foreach (var cell in Fixture.Build<Cell>()
                .OmitAutoProperties()
                .CreateMany())
            {
                cellSet.Add(cell);
            }
            return cellSet;
        }

        private CellSet Given_EmptyCellSet()
        {
            return Fixture.Create<CellSet>();
        }
    }
}
