using Robots.Contracts;

namespace Robots.Implementation
{
	public class Position :IPosition
	{
		public Position(int x, int y, OrientationType orientation)
		{
			X = x;
			Y = y;
			Orientation = orientation;
		}
		public int X { get; set; }
		public int Y { get; set; }
		public OrientationType Orientation { get; set; }
	}
}
