namespace Robots.Contracts
{
	public interface IRobot
	{
		/// <summary>
		/// Turn left
		/// </summary>
		/// <returns></returns>
		IPosition Left();

		/// <summary>
		/// Turn right
		/// </summary>
		/// <returns></returns>
		IPosition Right();

		/// <summary>
		/// Go forward
		/// </summary>
		/// <returns></returns>
		IPosition Forward();

	}
}
