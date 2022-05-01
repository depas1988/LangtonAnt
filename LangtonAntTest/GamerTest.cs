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
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Xunit;
using Xunit.Sdk;

namespace LangtonAntTest
{
    //TODO fare una regola (test double) che non fa niente che è applicabile (1 sola volta)
    //TODO fare una regola (test double) che fa andare avanti di 1000 volte di modo che 
    //TODO vada fuori dai boundaries (uno per lato e due per corner) 
    public class GamerTest
    {

        private readonly Gamer _sut;
        private readonly AntEqualityComparer _antEqualityComparer;
        private readonly CellEqualityComparer _cellEqualityComparer;

        public GamerTest()
        {
            
           
            var coordinateEqualityComparer = new CoordinateEqualityComparer();
            _cellEqualityComparer = new CellEqualityComparer(coordinateEqualityComparer);
            _antEqualityComparer = new AntEqualityComparer(coordinateEqualityComparer);
        }
        [Fact]
        public void PlayStartingFromACompletelyWhiteMap()
        {
         


         //   _sut = new Gamer(ruleList);

            var map = new Map(new Coordinate(0,0), new Coordinate(40,40), new List<Tuple<Coordinate, Color>>());

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
            var map = new Map(new Coordinate(0, 0), new Coordinate(40, 40), new List<Tuple<Coordinate, Color>>());

            var actualCoordinate = new Coordinate(40, 20);

            var ant = new Ant(actualCoordinate, Direction.Up);

            Assert.Throws <GameOverException> (() => _sut.Play(ant, map));

        }
    }
}
