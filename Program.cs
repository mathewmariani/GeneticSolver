using System;
using System.Diagnostics;

namespace GeneticSolver {
	class MainClass {
		public static void Main(string[] args) {
			Console.Write("Enter a String using only ASCII characters: ");
			string source = Console.ReadLine();
			Solver solver = new Solver();

			// Hamming Distance
			Func<string, int> getFitness = target => {
				var distance = 0;
				for (var i = 0; i < source.Length; i++) {
					distance += source[i] == target[i] ? 0 : 1;
				}

				return distance;
			};


			var watch = Stopwatch.StartNew();

			solver.GetBest(source.Length, getFitness);

			watch.Stop();
			var elapsed = watch.ElapsedMilliseconds;

			Console.WriteLine("Elapsed time is {0} ms", elapsed/1000f);
		}
	}
}
