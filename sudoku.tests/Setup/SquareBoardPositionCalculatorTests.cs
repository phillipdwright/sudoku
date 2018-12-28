using System;
using System.Linq;
using AutoFixture;
using NUnit.Framework;

using Sudoku.Library.Setup;

namespace Sudoku.Tests.Setup
{
    public class SquareBoardPositionCalculatorTests : BaseTest
    {
        private SquareBoardPositionCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = Fixture.Create<SquareBoardPositionCalculator>();
        }

        [Test]
        public void IsSquare_GivenSquareNumber_ReturnsTrue()
        {
            var squareNumber = Given_SquareNumber();

            Assert.That(_calculator.IsSquare(squareNumber));
        }

        [Test]
        public void IsSquare_GivenNonSquareNumber_ReturnsFalse()
        {
            var nonSquareNumber = Given_NonSquareNumber();

            Assert.That(_calculator.IsSquare(nonSquareNumber), Is.False);
        }

        // http://oeis.org/A000037
        private int Given_NonSquareNumber()
        {
            var number = Fixture.Create<int>();
            return number + (int)Math.Floor(0.5 + Math.Sqrt(number));
        }

        private int Given_SquareNumber()
        {
            var number = Fixture.Create<int>();
            return number * number;
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(2, 0, 2, 0)]
        [TestCase(3, 0, 3, 3)]
        [TestCase(4, 0, 4, 3)]
        [TestCase(5, 0, 5, 3)]
        [TestCase(6, 0, 6, 6)]
        [TestCase(7, 0, 7, 6)]
        [TestCase(8, 0, 8, 6)]
        [TestCase(9, 1, 0, 0)]
        [TestCase(10, 1, 1, 0)]
        [TestCase(11, 1, 2, 0)]
        [TestCase(12, 1, 3, 3)]
        [TestCase(13, 1, 4, 3)]
        [TestCase(14, 1, 5, 3)]
        [TestCase(15, 1, 6, 6)]
        [TestCase(16, 1, 7, 6)]
        [TestCase(17, 1, 8, 6)]
        [TestCase(18, 2, 0, 0)]
        [TestCase(19, 2, 1, 0)]
        [TestCase(20, 2, 2, 0)]
        [TestCase(21, 2, 3, 3)]
        [TestCase(22, 2, 4, 3)]
        [TestCase(23, 2, 5, 3)]
        [TestCase(24, 2, 6, 6)]
        [TestCase(25, 2, 7, 6)]
        [TestCase(26, 2, 8, 6)]
        [TestCase(27, 3, 0, 1)]
        [TestCase(28, 3, 1, 1)]
        [TestCase(29, 3, 2, 1)]
        [TestCase(30, 3, 3, 4)]
        [TestCase(31, 3, 4, 4)]
        [TestCase(32, 3, 5, 4)]
        [TestCase(33, 3, 6, 7)]
        [TestCase(34, 3, 7, 7)]
        [TestCase(35, 3, 8, 7)]
        [TestCase(36, 4, 0, 1)]
        [TestCase(37, 4, 1, 1)]
        [TestCase(38, 4, 2, 1)]
        [TestCase(39, 4, 3, 4)]
        [TestCase(40, 4, 4, 4)]
        [TestCase(41, 4, 5, 4)]
        [TestCase(42, 4, 6, 7)]
        [TestCase(43, 4, 7, 7)]
        [TestCase(44, 4, 8, 7)]
        [TestCase(45, 5, 0, 1)]
        [TestCase(46, 5, 1, 1)]
        [TestCase(47, 5, 2, 1)]
        [TestCase(48, 5, 3, 4)]
        [TestCase(49, 5, 4, 4)]
        [TestCase(50, 5, 5, 4)]
        [TestCase(51, 5, 6, 7)]
        [TestCase(52, 5, 7, 7)]
        [TestCase(53, 5, 8, 7)]
        [TestCase(54, 6, 0, 2)]
        [TestCase(55, 6, 1, 2)]
        [TestCase(56, 6, 2, 2)]
        [TestCase(57, 6, 3, 5)]
        [TestCase(58, 6, 4, 5)]
        [TestCase(59, 6, 5, 5)]
        [TestCase(60, 6, 6, 8)]
        [TestCase(61, 6, 7, 8)]
        [TestCase(62, 6, 8, 8)]
        [TestCase(63, 7, 0, 2)]
        [TestCase(64, 7, 1, 2)]
        [TestCase(65, 7, 2, 2)]
        [TestCase(66, 7, 3, 5)]
        [TestCase(67, 7, 4, 5)]
        [TestCase(68, 7, 5, 5)]
        [TestCase(69, 7, 6, 8)]
        [TestCase(70, 7, 7, 8)]
        [TestCase(71, 7, 8, 8)]
        [TestCase(72, 8, 0, 2)]
        [TestCase(73, 8, 1, 2)]
        [TestCase(74, 8, 2, 2)]
        [TestCase(75, 8, 3, 5)]
        [TestCase(76, 8, 4, 5)]
        [TestCase(77, 8, 5, 5)]
        [TestCase(78, 8, 6, 8)]
        [TestCase(79, 8, 7, 8)]
        [TestCase(80, 8, 8, 8)]
        public void Position_GivenEightyOneSquareBoard_MatchesExpected(int cellIndex, int expectedRow, int expectedColumn, int expectedSquare)
        {
            var cellEntryCount = 9;

            var actualRow = _calculator.GetRow(cellIndex, cellEntryCount);
            var actualColumn = _calculator.GetColumn(cellIndex, cellEntryCount);
            var actualSquare = _calculator.GetSquare(cellIndex, cellEntryCount);

            Assert.That(actualRow, Is.EqualTo(expectedRow));
            Assert.That(actualColumn, Is.EqualTo(expectedColumn));
            Assert.That(actualSquare, Is.EqualTo(expectedSquare));
        }
    }
}
