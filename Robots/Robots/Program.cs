using System;
using Robots.Contracts;
using Robots.Implementation;

namespace Robots
{
	class Program
	{
		static void Main(string[] args)
		{
				var planetWork = new PlanetWork();

				PrepareEnviroment(planetWork);

				Do(planetWork);
		}

		static void PrepareEnviroment(IPlanetWork planetWork)
		{
			while (!planetWork.IsSurfaceSet)
			{
				try
				{
					Console.WriteLine($"Enter surface parameters:");

					var surface = Console.ReadLine();

					planetWork.SetSurface(surface);

				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}

		static void Do(IPlanetWork planetWork)
		{
			while (true)
			{
				try
				{
					Console.WriteLine($"Enter robot parameters:");

					var robot = Console.ReadLine();

					planetWork.SetRobot(robot);

					Console.WriteLine($"Enter commands:");

					var command = Console.ReadLine();

					var result = planetWork.Go(command);

					ShowResult(result);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}

		private static void ShowResult(string result)
		{
			var old = Console.ForegroundColor;

			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine($"{result}");

			Console.ForegroundColor = old;
		}
	}
}
