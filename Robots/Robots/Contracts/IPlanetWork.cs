namespace Robots.Contracts
{
	public interface IPlanetWork
	{
		/// <summary>
		/// Set rectangular grid around which robots are able to move
		/// according to instructions provided from Earth
		/// </summary>
		/// <param name="value"></param>
		void SetSurface(string value);

		/// <summary>
		/// Set robot position consists of a grid coordinate (a pair of integers: x-coordinate followed by y-coordinate)
		/// and an orientation (N, S, E, W for north, south, east, and west).
		/// </summary>
		/// <param name="value"></param>
		void SetRobot(string value);

		/// <summary>
		/// Move robot by instructions
		/// </summary>
		/// <param name="value">A robot instruction is a string of the letters “L”, “R”, and “F” which represent, respectively, the instructions:
		/// 
		/// Left: the robot turns left 90 degrees and remains on the current grid point.
		/// Right: the robot turns right 90 degrees and remains on the current grid point.
		/// 
		/// Forward: the robot moves forward one grid point in the direction of the current orientation and maintains the same orientation.
		/// The direction North corresponds to the direction from grid point (x, y) to grid point (x, y+1).
		/// There is also a possibility that additional command types maybe required in the future and provision should be made for this.</param>
		/// <returns></returns>
		string Go(string value);

		/// <summary>
		/// True if surface set successfully
		/// </summary>
		bool IsSurfaceSet { get; set; }
	}
}