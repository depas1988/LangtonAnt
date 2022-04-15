using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using LangtonAnt;
using LangtonAnt.DataModel;
using LangtonAnt.Interface;
using LangtonAnt.Rule;
using LangtonAnt.Utility;
using LangtonAntTest.Utility;
using Xunit;
using Xunit.Sdk;

namespace LangtonAntTest
{
    public class GamerTest
    {

        private readonly Gamer _sut;
        private readonly AntEqualityComparer _antEqualityComparer;
        private readonly CellEqualityComparer _cellEqualityComparer;

        public GamerTest()
        {
            var ruleList = new List<IRule>();
            var whiteRule = new WhiteRule();
            var blackRule = new BlackRule();
            ruleList.Add(whiteRule);
            ruleList.Add(blackRule);
            _sut = new Gamer(ruleList);
            var coordinateEqualityComparer = new CoordinateEqualityComparer();
            _cellEqualityComparer = new CellEqualityComparer(coordinateEqualityComparer);
            _antEqualityComparer = new AntEqualityComparer(coordinateEqualityComparer);
        }
        [Fact]
        public void PlayStartingFromACompletelyWhiteMap()
        {
            var map = new Map(new Coordinate(0,0), new Coordinate(40,40));

            var actualCoordinate = new Coordinate(20, 20);

            var ant = new Ant(actualCoordinate, Direction.Up);

            var antExpected = new Ant(new Coordinate(21,20), Direction.Right);

            var cellExpected = new Cell(Color.Black, new Coordinate(20, 20));

            _sut.Play(ant, map);

            var cellActual = map.GetCell(actualCoordinate);

            Assert.Equal(antExpected,ant, _antEqualityComparer);

            Assert.Equal(cellExpected, cellActual, _cellEqualityComparer);

        }

        [Fact]
        public void ShouldEndWithGameOverException()
        {
            var map = new Map(new Coordinate(0, 0), new Coordinate(40, 40));

            var actualCoordinate = new Coordinate(40, 20);

            var ant = new Ant(actualCoordinate, Direction.Up);

            Assert.Throws <GameOverException> (() => _sut.Play(ant, map));

        }
    }

    public class GameTest
    {
        private readonly MapEqualityComparer _mapEqualityComparer;
        private readonly Game _sut;
        public GameTest()
        {
            var coordinateEqualityComparer = new CoordinateEqualityComparer();
            var cellEqualityComparer = new CellEqualityComparer(coordinateEqualityComparer);
            _mapEqualityComparer = new MapEqualityComparer(cellEqualityComparer);

            var ant = new Ant(new Coordinate(20, 20), Direction.Up);
            var map = new Map(new Coordinate(0, 0), new Coordinate(40, 40));

            var whiteRule = new WhiteRule();
            var blackRule = new BlackRule();

            var ruleList = new List<IRule>
                {
                    whiteRule, blackRule
                }
                ;

            var gamer = new Gamer(ruleList);

            _sut = new Game(gamer,ant, map);
        }

        [Fact]
        public void Test()
        {
            var map1 = new Map(new Coordinate(0, 0), new Coordinate(30, 30));
            var map2 = new Map(new Coordinate(0, 0), new Coordinate(30, 30));
            
            Assert.Equal(map1,map2,_mapEqualityComparer);
        }
    }
}
