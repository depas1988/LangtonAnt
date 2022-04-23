using System;
using System.Collections.Generic;
using LangtonAnt.DataModel;
using LangtonAnt.Interface;
using LangtonAnt.Rule;
using LangtonAnt.Utility;
using LangtonAntTest.Utility;
using Xunit;

namespace LangtonAntTest
{
    public class GameTest
    {
        private Game _sut;
        private readonly CellEqualityComparer _cellEqualityComparer;
        private readonly Gamer _gamer;
        private readonly AntEqualityComparer _antEqualityComparer;
        public GameTest()
        {
            var coordinateEqualityComparer = new CoordinateEqualityComparer();
            _cellEqualityComparer = new CellEqualityComparer(coordinateEqualityComparer);
            _antEqualityComparer = new AntEqualityComparer(coordinateEqualityComparer);

            var whiteRule = new WhiteRule();
            var blackRule = new BlackRule();
            var ruleList = new List<IRule>
                {
                    whiteRule, blackRule
                }
                ;

            _gamer = new Gamer(ruleList);

        }

        private void FlipToBlack(Cell cell)
        {
            cell.UpdateColor(Color.Black);
        }

        private void FlipToWhite(Cell cell)
        {
            cell.UpdateColor(Color.White);
        }

        [Fact]
        public void TestGameAfterFiveSteps()
        {
            var antActual = new Ant(new Coordinate(10, 10), Direction.Left);
            var mapActual = new Map(new Coordinate(0, 0), new Coordinate(20, 20));

            var antExpected = new Ant(new Coordinate(10, 9), Direction.Down);

            _sut = new Game(_gamer, antActual, mapActual);

            var mapExpected = new MapEmulator(new Coordinate(0, 0), new Coordinate(20, 20), _cellEqualityComparer);
            
            mapExpected.UpdateCell(new Coordinate(10,10),FlipToBlack);
            mapExpected.UpdateCell(new Coordinate(10, 11), FlipToBlack);
            mapExpected.UpdateCell(new Coordinate(11, 11), FlipToBlack);
            mapExpected.UpdateCell(new Coordinate(11, 10), FlipToBlack);
            mapExpected.UpdateCell(new Coordinate(10, 10), FlipToWhite);

            _sut.Run(5);

            Assert.Equal(0,mapExpected.CompareTo(mapActual));

            Assert.Equal(antExpected, antActual,_antEqualityComparer);
        }

        [Fact]
        public void TestExceptionWithANonPositiveNumberOfIterations()
        {
            var antActual = new Ant(new Coordinate(10, 10), Direction.Left);
            var mapActual = new Map(new Coordinate(0, 0), new Coordinate(20, 20));

            _sut = new Game(_gamer, antActual, mapActual);

            Assert.Throws<GameOverException>(() => _sut.Run(0));
        }

    }
}