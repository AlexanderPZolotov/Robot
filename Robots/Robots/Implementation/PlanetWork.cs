using System;
using System.Collections.Generic;
using Robots.Contracts;

namespace Robots.Implementation
{
	public class PlanetWork : IPlanetWork
	{
		private static IRobot _robot;
		private IPosition _surfaceEndPoint;

		private readonly Dictionary<string,OrientationType> _byChar = new Dictionary<string, OrientationType>
		{
			{"N",OrientationType.N },
			{"S",OrientationType.S },
			{"E",OrientationType.E },
			{"W",OrientationType.W },
		};

		private readonly Dictionary<char,Action> _map = new Dictionary<char, Action>
		{
			{'F',Forward },
			{'L',Left },
			{'R',Right },
		};

		public bool IsSurfaceSet { get; set; }

		public PlanetWork()
		{
			IsSurfaceSet = false;
			_robot = null;
		}

		private static void Right()
		{
			_robot.Right();
		}

		private static void Left()
		{
			_robot.Left();
		}

		private static void Forward()
		{
			_robot.Forward();
		}

		public void SetSurface(string value)
		{
			_surfaceEndPoint = GetPosition(value);

			IsSurfaceSet = true;
		}

		public void SetRobot(string value)
		{
			if (!IsSurfaceSet)
			{
				throw new Exception($"Set surface end point first by SetSurface function !");
			} 

			var position = GetPosition(value);

			_robot = new Robot(_surfaceEndPoint.X, _surfaceEndPoint.Y,position);
		}

		public string Go(string value)
		{

			if (_robot == null)
			{
				throw new Exception("Set robot first by SetRobot function !");
			}

			if (value.Length >= 100)
			{
				throw new ArgumentOutOfRangeException("Command must be less than 100 characters in length !");
			}

			foreach (var command in value.ToCharArray())
			{
				if (!_map.ContainsKey(command))
				{
					throw new ArgumentOutOfRangeException($"Can't find command {command} !");
				}
				_map[command].Invoke();
			}

			return _robot.ToString();
		}

		

		private IPosition GetPosition(string value)
		{
			var positionArray = value.Split(' ');

			if (positionArray.Length > 3)
			{
				throw new ArgumentOutOfRangeException("Too many parameters");
			}

			if (positionArray.Length < 3)
			{
				if (!Int32.TryParse(positionArray[0], out var x))
				{
					throw new Exception($"Can't parse value {positionArray[0]}");
				}
				if (!Int32.TryParse(positionArray[1], out var y))
				{
					throw new Exception($"Can't parse value {positionArray[1]}");
				}

				if (x > Robot.GetMaxCoordinate() || y > Robot.GetMaxCoordinate())
				{
					throw new ArgumentOutOfRangeException();
				}

				return new Position(x,y,OrientationType.N);
			}
			else
			{
				if (!Int32.TryParse(positionArray[0], out var x))
				{
					throw new Exception($"Can't parse value {positionArray[0]}");
				}
				if (!Int32.TryParse(positionArray[1], out var y))
				{
					throw new Exception($"Can't parse value {positionArray[1]}");
				}

				if (!_byChar.ContainsKey(positionArray[2]))
				{
					throw new Exception($"Can't parse value {positionArray[2]}");
				}

				if (x > Robot.GetMaxCoordinate() || y > Robot.GetMaxCoordinate())
				{
					throw new ArgumentOutOfRangeException();
				}

				return new Position(x, y, _byChar[positionArray[2]]);
			}

		}
	}
}
