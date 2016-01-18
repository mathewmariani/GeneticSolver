using System;

namespace GeneticSolver {
    public class Solver	{

        // http://stackoverflow.com/questions/2444447/string-that-contains-all-ascii-characters
        private readonly string ascii = " !\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        private readonly Random random = new Random();

        public string GetBest(int length, Func<string, int> getFitness) {
            var generation = 1;
            var parent = GenerateString(length);
            var parentFitness = getFitness(parent);

            while (parentFitness != 0) {
                var child = Mutate(parent);
                var childFitness = getFitness(child);

                if (childFitness < parentFitness) {
                    Console.WriteLine("Generation: {0} | Fitness: {1} | {2}",
                        generation, childFitness, child
                    );

                    parent = child;
                    parentFitness = childFitness;
                }

                generation++;
            }

            return parent;
        }

        private string Mutate(string parent) {
            var index = random.Next(0, parent.Length);
            var child = parent.ToCharArray();
            child[index] = ascii[random.Next(0, ascii.Length)];

            return new String(child);
        }

        private string GenerateString(int size) {
            char[] chars = new char[size];
            for (int i=0; i < size; i++)
            {
                chars[i] = ascii[random.Next(ascii.Length)];
            }

            return new string(chars);
        }
    }
}

