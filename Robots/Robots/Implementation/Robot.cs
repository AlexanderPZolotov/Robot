using System;
using System.Collections.Generic;
using Robots.Contracts;

namespace Robots.Implementation
{
	public class Robot : IRobot
	{
		private static readonly int MaxCoordinate = 50;

		private readonly Dictionary<OrientationType,int> _byOrientation = new Dictionary<OrientationType, int>
		{
			{OrientationType.N,1 },
			{OrientationType.E,2 },
			{OrientationType.S,3 },
			{OrientationType.W,4 }
		};

		private readonly Dictionary<int, OrientationType> _byNumber = new Dictionary<int,OrientationType>
		{
			{1,OrientationType.N },
			{2,OrientationType.E },
			{3,OrientationType.S },
			{4,OrientationType.W }
		};

		private IPosition _position;
		private IPosition _lostBorderPoint;
		private bool _isLost;
		public Robot(int upperX, int upperY, IPosition start)
		{
			CheckMaxValue(upperX);
			CheckMaxValue(upperY);
			CheckMaxValue(start);

			_lostBorderPoint = new Position(upperX,upperY,OrientationType.N);
			_position = start;

			_isLost = false;
		}

		private static void CheckMaxValue(int value)
		{
			if (value > MaxCoordinate )
			{
				throw new ArgumentOutOfRangeException($"Coordinate cannot be more {MaxCoordinate} (given value is {value})");
			}
		}
		private static void CheckMaxValue(IPosition value)
		{
			if (value.X > MaxCoordinate)
			{
				throw new ArgumentOutOfRangeException($"Coordinate cannot be more {MaxCoordinate} (given value is {value.X})");
			}

			if (value.Y > MaxCoordinate)
			{
				throw new ArgumentOutOfRangeException($"Coordinate cannot be more {MaxCoordinate} (given value is {value.Y})");
			}
		}

		public IPosition Left()
		{
			var position = new Position(_position.X, _position.Y, _position.Orientation);

			if (_isLost)
			{
				return _position;
			}

			if (position.Orientation == OrientationType.N)
			{
				position.Orientation = OrientationType.W;
			}
			else
			{
				var number = _byOrientation[position.Orientation];

				position.Orientation = _byNumber[--number];
			}
			_position = position;

			return position;
		}

		public IPosition Right()
		{
			var position = new Position(_position.X, _position.Y, _position.Orientation);

			if (_isLost)
			{
				return _position;
			}

			if (position.Orientation == OrientationType.W)
			{
				position.Orientation = OrientationType.N;
			}
			else
			{
				var number = _byOrientation[position.Orientation];

				position.Orientation = _byNumber[++number];
			}

			_position = position;

			return position;
		}

		public IPosition Forward()
		{
			if (_isLost)
			{
				return _position;
			}

			var position = new Position(_position.X, _position.Y, _position.Orientation);

			if (position.Orientation == OrientationType.S)
			{
				position.Y--;
			}

			if (position.Orientation == OrientationType.N)
			{
				position.Y++;
			}

			if (position.Orientation == OrientationType.E)
			{
				position.X++;
			}

			if (position.Orientation == OrientationType.W)
			{
				position.X--;
			}

			

			if (
				position.Y > _lostBorderPoint.Y || position.X > _lostBorderPoint.X
				|| position.X==-1 || position.Y==-1
			)

			{
				_isLost = true;

			}
			else
			{
				_position = position;
			}

			return _position;
		}

		/// <summary>
		/// The maximum value for any coordinate
		/// </summary>
		public static  int GetMaxCoordinate()
		{
			return MaxCoordinate;
		}

		public override string ToString()
		{
			return _isLost ?
				$"{_position.X} {_position.Y} {_position.Orientation} LOST" 
				: $"{_position.X} {_position.Y} {_position.Orientation}";
		}
	}
}
