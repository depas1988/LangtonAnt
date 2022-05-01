using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LangtonAnt.DataModel;
using LangtonAnt.Interface;
using LangtonAnt.Rule;
using LangtonAnt.Utility;
using LangtonAntTest.Utility;
using Xunit;

namespace LangtonAntTest.Rule
{
    public class WhiteRuleTest
    {
        private readonly WhiteRule _sut;
        private readonly AntEqualityComparer _antEqualityComparer;
        private readonly CellEqualityComparer _cellEqualityComparer;

        public WhiteRuleTest()
        {
            _sut = new WhiteRule();
            var coordinateEqualityComparer = new CoordinateEqualityComparer();
            _cellEqualityComparer = new CellEqualityComparer(coordinateEqualityComparer);
            _antEqualityComparer = new AntEqualityComparer(coordinateEqualityComparer);
        }
        
        [Theory]
        [MemberData(nameof(GetData), parameters: 8)]
        public void TestWhiteRuleForAnyAntDirectionForAnyCellColor(Coordinate initialCoordinate
            ,Direction antInitialDirection, Color initialColor, Coordinate finalCoordinate,
            Direction antFinalDirection, Color finalColor)
        {

            var antActual = new Ant(initialCoordinate, antInitialDirection);

            var antExpected = new Ant(finalCoordinate, antFinalDirection);

            var cellActual = new Cell(initialColor, initialCoordinate);

            var cellExpected = new Cell(finalColor, initialCoordinate);

            if (_sut.IsApplicable(cellActual))
                _sut.Apply(cellActual, antActual);

            Assert.Equal(antExpected, antActual, _antEqualityComparer);

            Assert.Equal(cellExpected, cellActual, _cellEqualityComparer);

        }


        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] { new Coordinate(20,20), Direction.Up, Color.White,  new Coordinate(21, 20),Direction.Right,Color.Black},
                new object[] { new Coordinate(20,20), Direction.Right, Color.White,  new Coordinate(20, 19),Direction.Down,Color.Black},
                new object[] { new Coordinate(20,20), Direction.Down, Color.White,  new Coordinate(19, 20),Direction.Left,Color.Black},
                new object[] { new Coordinate(20,20), Direction.Left, Color.White,  new Coordinate(20, 21),Direction.Up,Color.Black},
                new object[] { new Coordinate(20,20), Direction.Up, Color.Black, new Coordinate(20, 20), Direction.Up,Color.Black},
            new object[] { new Coordinate(20,20), Direction.Right, Color.Black, new Coordinate(20, 20), Direction.Right, Color.Black},
            new object[] { new Coordinate(20,20), Direction.Down, Color.Black, new Coordinate(20, 20), Direction.Down, Color.Black},
            new object[] { new Coordinate(20,20), Direction.Left, Color.Black, new Coordinate(20, 20), Direction.Left, Color.Black}
            };

            return allData.Take(numTests);
        }
    }
}
