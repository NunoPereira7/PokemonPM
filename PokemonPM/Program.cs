using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace PokemonPM {
    class Program {
        static void Main(string[] args) {
            
            //just a watch to count the time elapsed
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //read file path
            string filePath = args[0];

            char[] inputArray = null;
            
            //read file
            try {
                using (StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))) {
                    inputArray = reader.ReadLine().ToCharArray();
                }
            }
            catch (Exception e) {
                Console.WriteLine("File could not be read: " + e.Message);
            }

            //show number of movements
            Console.WriteLine("Processing " + inputArray.Length + " movement(s)...\n");

            //starting positions
            Point position = new Point(0, 0);

            //List of positions where Ash passed by
            HashSet<Point> positions = new HashSet<Point>();

            //insert starting position
            positions.Add(position);

            //read movements
            foreach (char d in inputArray) {
                switch (d) {
                    case 'N':
                        position.Y += 1;
                        break;

                    case 'S':
                        position.Y -= 1;
                        break;

                    case 'E':
                        position.X += 1;
                        break;

                    case 'O':
                        position.X -= 1;
                        break;

                    default:
                        break;
                }
                positions.Add(position);
            }

            //show results
            Console.WriteLine("Pokemons caught: " + positions.Count + ". Gotta catch 'em all!\n");
            
            //show timer
            watch.Stop(); 
            Console.WriteLine("Time elapsed: " + watch.Elapsed);
        }
    }
}
