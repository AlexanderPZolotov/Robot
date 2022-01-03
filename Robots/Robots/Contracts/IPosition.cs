namespace Robots.Contracts
{
	public interface IPosition
	{
		/// <summary>
		/// Horisontal coordinate
		/// </summary>
		int X { get; set; }

		/// <summary>
		/// Vertical coordinate
		/// </summary>
		int Y { get; set; }

		/// <summary>
		/// Orientation (north, south, east, and west)
		/// </summary>
		OrientationType Orientation { get; set; }

	}
}
