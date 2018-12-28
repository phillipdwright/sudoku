using System.Linq;
using AutoFixture;
using Moq;
using NUnit.Framework;

using Sudoku.Library;
using Sudoku.Library.Validation;
using Sudoku.Tests.TestSupport.Extensions;

namespace Sudoku.Tests.Validation
{
    public class BoardValidatorTests : BaseTest
    {
        private BoardValidator _boardValidator;

        private Mock<ICellSetValidator> _mockCellSetValidator;

        [SetUp]
        public void Setup()
        {
            _mockCellSetValidator = Fixture.Mock<ICellSetValidator>();

            _boardValidator = Fixture.Create<BoardValidator>();
        }

        [Test]
        public void IsValid_GivenEmptyBoard_ReturnsTrue()
        {
            var board = Given_EmptyBoard();

            Assert.That(_boardValidator.IsValid(board));
        }

        [Test]
        public void IsValid_GivenNonEmptyBoardWithOneInvalidCellSet_ReturnsFalse()
        {
            var board = Given_NonEmptyBoardWithOneInvalidCellSet();

            Assert.That(_boardValidator.IsValid(board), Is.False);
        }

        [Test]
        public void IsValid_GivenNonEmptyBoardWithAllValidCellSets_ReturnsTrue()
        {
            var board = Given_NonEmptyBoardWithAllValidCellSets();

            Assert.That(_boardValidator.IsValid(board));
        }

        [Test]
        public void IsValid_GivenNonEmptyBoardWithMultipleInvalidCellSets_ReturnsFalse()
        {
            var board = Given_NonEmptyBoardWithMultipleInvalidCellSets();

            Assert.That(_boardValidator.IsValid(board), Is.False);
        }

        private Board Given_NonEmptyBoardWithMultipleInvalidCellSets()
        {
            var board = Given_NonEmptyBoardWithAllValidCellSets();
            foreach (var cellSet in board)
            {
                _mockCellSetValidator.Setup(csv => csv.IsValid(cellSet))
                    .Returns(false);
            }
            return board;
        }

        private Board Given_NonEmptyBoardWithOneInvalidCellSet()
        {
            var board = Given_NonEmptyBoardWithAllValidCellSets();
            _mockCellSetValidator.Setup(csv => csv.IsValid(board.First()))
                .Returns(false);
            return board;
        }

        private Board Given_NonEmptyBoardWithAllValidCellSets()
        {
            var board = Given_EmptyBoard();
            foreach (var cellSet in Fixture.CreateMany<CellSet>())
            {
                _mockCellSetValidator.Setup(csv => csv.IsValid(cellSet))
                    .Returns(true);
                board.Add(cellSet);
            }
            return board;
        }

        private Board Given_EmptyBoard()
        {
            return Fixture.Create<Board>();
        }
    }
}
