using System;
using System.Collections.Generic;
using LangtonAnt.DataModel;
using LangtonAnt.Interface;
using LangtonAnt.Rule;
using LangtonAnt.Utility;
using LangtonAntTest.Utility;
using Xunit;
using MoveOnlyForwardFakeRule = LangtonAntTest.Utility.MoveOnlyForwardFakeRule;

namespace LangtonAntTest
{
    public class GameTest
    {
        private Game _sut;
        private readonly CellEqualityComparer _cellEqualityComparer;
        private readonly Gamer _gamer;
        private readonly AntEqualityComparer _antEqualityComparer;
        private readonly MapEqualityComparer _mapEqualityComparer;
        public GameTest()
        {
            var coordinateEqualityComparer = new CoordinateEqualityComparer();
            _cellEqualityComparer = new CellEqualityComparer(coordinateEqualityComparer);
            _antEqualityComparer = new AntEqualityComparer(coordinateEqualityComparer);
            _mapEqualityComparer = new MapEqualityComparer(_cellEqualityComparer);

            var whiteRule = new WhiteRule();
            var blackRule = new BlackRule();
            var ruleList = new List<IRule>
                {
                    whiteRule, blackRule
                }
                ;

            _gamer = new Gamer(ruleList);

        }

        //private void FlipToBlack(Cell cell)
        //{
        //    cell.UpdateColor(Color.Black);
        //}

        //private void FlipToWhite(Cell cell)
        //{
        //    cell.UpdateColor(Color.White);
        //}

        [Fact]
        public void TestGameAfterFiveSteps()
        {
            var antActual = new Ant(new Coordinate(10, 10), Direction.Left);
            var mapActual = new Map(new Coordinate(0, 0), new Coordinate(20, 20), new List<Tuple<Coordinate, Color>>());

            var antExpected = new Ant(new Coordinate(10, 9), Direction.Down);

            _sut = new Game(_gamer);

            var blackCellExpectedList = new List<Tuple<Coordinate, Color>>()
                {
                    Tuple.Create(new Coordinate(10,11), Color.Black),
                Tuple.Create(new Coordinate(11,11), Color.Black),
                Tuple.Create(new Coordinate(11,10), Color.Black)
                }
                ;

            var mapExpected = new Map(new Coordinate(0, 0), new Coordinate(20, 20), blackCellExpectedList);
            
            _sut.Run(5, antActual, mapActual);

            Assert.Equal(mapExpected, mapActual, _mapEqualityComparer);

            Assert.Equal(antExpected, antActual,_antEqualityComparer);
        }
    }
}