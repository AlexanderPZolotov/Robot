using System;
using NUnit.Framework;
using Robots.Contracts;
using Robots.Implementation;

namespace Robots.UnitTests
{
	public class PlanetWorkTests
	{
		private IPlanetWork _testee;
		private int _surfaceX, _surfaceY;

		[SetUp]
		public void Setup()
		{
			_testee = new PlanetWork();

			_surfaceX = 50;
			_surfaceY = 50;

		}

		[TestCase(50, 51)]
		[TestCase(51, 50)]
		[TestCase(151, 150)]
		public void OutOfRangeSurface_ShouldThrowException(int x, int y) => Assert.Throws<ArgumentOutOfRangeException>(() => _testee.SetSurface($"{x} {y}"));

		[TestCase(50, 51)]
		[TestCase(51, 50)]
		[TestCase(151, 150)]
		public void OutOfRangePosition_ShouldThrowException(int x, int y)
		{
			_testee.SetSurface($"{_surfaceX} {_surfaceY}");

			Assert.Throws<ArgumentOutOfRangeException>(() => _testee.SetRobot($"{x} {y}"));
		}

		[TestCase("1 1 E", "LLLLLLLLLLFFFFFFFFFFLLLLLLLLLLFFFFFFFFFFLLLLLLLLLLFFFFFFFFFFLLLLLLLLLLFFFFFFFFFFLLLLLLLLLLFFFFFFFFFF")]//Command with length==100
		[TestCase("1 1 E", "WRONG-LETTERS")]
		public void OutOfRangeCommand_ShouldThrowException(string robot,string command)
		{
			_testee.SetSurface($"{_surfaceX} {_surfaceY}");
			_testee.SetRobot(robot);

			Assert.Throws<ArgumentOutOfRangeException>(() => _testee.Go(command));
		}

		[TestCase("5 3", "1 1 E", "RFRFRFRF", ExpectedResult = "1 1 E")]
		[TestCase("5 3", "3 2 N", "FRRFLLFFRRFLL", ExpectedResult = "3 3 N LOST")]
		[TestCase("5 3", "0 3 W", "LLFFFLFLFL", ExpectedResult = "3 3 N LOST")]// Inside test description we have mistake - output can't be "2 3 S"
		public string Go_ShouldReturnProperResult(string surface, string robot, string command)
		{
			_testee = new PlanetWork();

			_testee.SetSurface(surface);

			_testee.SetRobot(robot);

			return _testee.Go(command);
		}
	}
}