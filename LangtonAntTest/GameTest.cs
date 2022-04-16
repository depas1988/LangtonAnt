using System;
using System.Collections.Generic;
using LangtonAnt.DataModel;
using LangtonAnt.Interface;
using LangtonAnt.Rule;
using LangtonAntTest.Utility;
using Xunit;

namespace LangtonAntTest
{
    public class GameTest
    {
        
        private Game _sut;
        private readonly CellEqualityComparer _cellEqualityComparer;
        private Gamer _gamer;
        public GameTest()
        {
            var coordinateEqualityComparer = new CoordinateEqualityComparer();
            _cellEqualityComparer = new CellEqualityComparer(coordinateEqualityComparer);
            
            var whiteRule = new WhiteRule();
            var blackRule = new BlackRule();

            var ruleList = new List<IRule>
                {
                    whiteRule, blackRule
                }
                ;

            _gamer = new Gamer(ruleList);

            
        }

        [Fact]
        public void TestGame()
        {
            var ant = new Ant(new Coordinate(10, 10), Direction.Left);
            var map = new Map(new Coordinate(0, 0), new Coordinate(20, 20));

            _sut = new Game(_gamer, ant, map);

            Action<Cell> flipToBlack = delegate(Cell cell)
            {
                cell.UpdateColor(Color.Black);
            };

            Action<Cell> flipToWhite = delegate (Cell cell)
            {
                cell.UpdateColor(Color.White);
            };


            var mapExpected = new MapEmulator(new Coordinate(0, 0), new Coordinate(20, 20), _cellEqualityComparer);
            
            mapExpected.UpdateCell(new Coordinate(10,10),flipToBlack);
            mapExpected.UpdateCell(new Coordinate(10, 11), flipToBlack);
            mapExpected.UpdateCell(new Coordinate(11, 11), flipToBlack);
            mapExpected.UpdateCell(new Coordinate(11, 10), flipToBlack);
            mapExpected.UpdateCell(new Coordinate(10, 10), flipToWhite);

            _sut.Run(5);

            Assert.Equal(0,mapExpected.CompareTo(map));
        }
    }
}