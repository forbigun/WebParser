using Parser.Core.RedSquare;
using System;
using System.Threading.Tasks;

namespace ConsoleParser

{
	internal class Program
	{
		private async static Task Main(string[] args)
		{
			var parser = new RedSquareWorker<string>(
				new RedSquareParser())
			{
				Settings = new RedSquareSettings()
			};

			var result = await parser.Start();

			Console.WriteLine(result);
		}
	}
}