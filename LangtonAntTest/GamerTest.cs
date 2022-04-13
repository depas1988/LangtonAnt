using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using LangtonAnt;
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
            var map = new Map(40);

            var actualCoordinate = new Coordinate(20, 20);

            var ant = new Ant(actualCoordinate, Direction.Up);

            var antExpected = new Ant(new Coordinate(21,20), Direction.Right);

            var cellExpected = new Cell(Color.Black, new Coordinate(20, 20));

            _sut.Play(ant, map);

            var cellActual = map.GetCellOfCoordinate(actualCoordinate);

            Assert.Equal(antExpected,ant, _antEqualityComparer);

            Assert.Equal(cellExpected, cellActual, _cellEqualityComparer);


        }

        [Fact]
        public void ShouldEndWithGameOverException()
        {
            var map = new Map(40);

            var actualCoordinate = new Coordinate(39, 20);

            var ant = new Ant(actualCoordinate, Direction.Up);

            Assert.Throws <GameOverException> (() => _sut.Play(ant, map));

        }
    }
}
