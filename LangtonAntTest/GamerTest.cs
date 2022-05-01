using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using LangtonAnt;
using LangtonAnt.DataModel;
using LangtonAnt.Interface;
using LangtonAnt.Rule;
using LangtonAnt.Utility;
using LangtonAntTest.Utility;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Xunit;
using Xunit.Sdk;

namespace LangtonAntTest
{
    public class GamerTest
    {

        private Gamer _sut;
        private readonly AntEqualityComparer _antEqualityComparer;
        private readonly CellEqualityComparer _cellEqualityComparer;
        private readonly MapEqualityComparer _mapEqualityComparer;

        public GamerTest()
        {
            var coordinateEqualityComparer = new CoordinateEqualityComparer();
            _cellEqualityComparer = new CellEqualityComparer(coordinateEqualityComparer);
            _antEqualityComparer = new AntEqualityComparer(coordinateEqualityComparer);
            _mapEqualityComparer = new MapEqualityComparer(_cellEqualityComparer);
        }
        [Fact]
        public void PlayWithAFakeRule()
        {

            _sut = new Gamer(new List<IRule>() { new DoNothingFakeRule() });

            var mapActual = new Map(new Coordinate(0,0), new Coordinate(40,40), new List<Tuple<Coordinate, Color>>());

            var antActual = new Ant(new Coordinate(20, 20), Direction.Up);

            var antExpected = new Ant(new Coordinate(20,20), Direction.Up);

            var mapExpected = new Map(new Coordinate(0, 0), new Coordinate(40, 40), new List<Tuple<Coordinate, Color>>());

            _sut.Play(antActual, mapActual);

            Assert.Equal(antExpected,antActual, _antEqualityComparer);

            Assert.Equal(mapExpected, mapActual, _mapEqualityComparer);

        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void ShouldThrowGameOverException(Ant ant)
        {
            var map = new Map(new Coordinate(0, 0), new Coordinate(40, 40), new List<Tuple<Coordinate, Color>>());

            _sut = new Gamer(new List<IRule>(){new MoveOnlyForwardFakeRule()});

            Assert.Throws <GameOverException> (() => _sut.Play(ant, map));

        }

        public static IEnumerable<object[]> GetData()
        {
            var allData = new List<object[]>
            {
                new object[] { new Ant(new Coordinate(0,0), Direction.Down)},
                new object[] { new Ant(new Coordinate(0,0), Direction.Left)},
                new object[] { new Ant(new Coordinate(0,10), Direction.Left)},
                new object[] { new Ant(new Coordinate(0,10), Direction.Left)},
                new object[] { new Ant(new Coordinate(0,40), Direction.Up)},
                new object[] { new Ant(new Coordinate(10,40), Direction.Up)},
                new object[] { new Ant(new Coordinate(40,40), Direction.Up)},
                new object[] { new Ant(new Coordinate(40,40), Direction.Right)},
                new object[] { new Ant(new Coordinate(40,20), Direction.Right)},
                new object[] { new Ant(new Coordinate(40,0), Direction.Right)},
                new object[] { new Ant(new Coordinate(40,0), Direction.Down)},
                new object[] { new Ant(new Coordinate(20,0), Direction.Down)}
            };

            return allData;
        }
    }
}
