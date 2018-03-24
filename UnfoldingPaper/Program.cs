using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnfoldingPaper
{
    public class Program
    {
        public static Config _Example = new Config()
        {
            N = 1,
            Expected = 5,
            PaperTemp = new List<string>()
            {
                "###",
                "#..",
                "#.#"
            }
        };

        public static Config _MultipleFolds = new Config()
        {
            N = 5,
            Expected = 290,
            PaperTemp = new List<string>()
            {
                "###",
                "#..",
                "#.#"
            }
        };

        public static Config _BigSheet = new Config()
        {
            N = 5,
            Expected = 1,
            PaperTemp = new List<string>()
            {
                "############################################",
                "#..........................................#",
                "#..........................................#",
                "#..........................................#",
                "#..........................................#",
                "#..........................................#",
                "#..........................................#",
                "#..........................................#",
                "#..........................................#",
                "#..........................................#",
                "############################################"
            }
        };

        public static Config _LongFolding = new Config()
        {
            N = 10000,
            Expected = 1,
            PaperTemp = new List<string>()
            {
                "###",
                ".#.",
                ".#."
            }
        };

        public static Config _ManyPieces = new Config()
        {
            N = 14,
            Expected = 268435456,
            PaperTemp = new List<string>()
            {
                ".....",
                ".###.",
                ".#.#.",
                ".###.",
                "....."
            }
        };

        public static Config _Random = new Config()
        {
            N = 4,
            Expected = 1168,
            PaperTemp = new List<string>()
            {
                ".#.......#.....#...####",
                "##..#.....####.#.......",
                "#...###....#...#.###.##",
                "###........#...#....#.."
            }
        };

        public static Config _Chessboard = new Config()
        {
            N = 5,
            Expected = 254337,
            PaperTemp = new List<string>()
            {
                "#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.",
                ".#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#",
                "#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.",
                ".#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#",
                "#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.",
                ".#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#",
                "#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.",
                ".#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#",
                "#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.",
                ".#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#",
                "#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.",
                ".#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#"
            }
        };

        public static void Main(string[] args)
        {
            Config config = _Random;            
            
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"\nPiece(s) : {Execute(config)} --- Expected : {config.Expected}");
            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey();
        }

        public static int Execute(Config current)
        {
            int pieces = 0;
            var paper = new Dictionary<Tuple<int, int>, bool>();

            for (int i = 0; i < current.N; i++)
            {
                current.PaperTemp = DownToUp(current.PaperTemp);
                current.PaperTemp = RightToLeft(current.PaperTemp);
            }

            var bounds = new Tuple<int, int>(current.PaperTemp.First().Length, current.PaperTemp.Count);
            for (int y = 0; y < bounds.Item2; y++)
            {
                for (int x = 0; x < bounds.Item1; x++)
                {
                    var coord = new Tuple<int, int>(x, y);
                    if (current.PaperTemp[y][x] == '#')
                        paper.Add(coord, true);
                }
            }

            while (paper.Count > 0)
            {
                CreateNewPiece(paper, paper.First().Key, bounds);
                pieces++;
            }
            return pieces;
        }

        #region unfolding
        public static List<string> DownToUp(List<string> paper_temp)
        {
            var new_paper = new List<String>();
            for (int i = paper_temp.Count - 1; i >= 0; i--)
            {
                new_paper.Add(paper_temp[i]);
            }

            new_paper.AddRange(paper_temp);

            return new_paper;
        }
        public static List<string> RightToLeft(List<string> paper_temp)
        {
            for (int i = 0; i < paper_temp.Count; i++)
            {
                paper_temp[i] = Reverse(paper_temp[i]) + paper_temp[i];
            }
            return paper_temp;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        #endregion

        public static void CreateNewPiece(Dictionary<Tuple<int, int>, bool> paper, Tuple<int, int> coords, Tuple<int, int> bounds)
        {
            Dictionary<Tuple<int, int>, bool> a_traiter = new Dictionary<Tuple<int, int>, bool>();
            Dictionary<Tuple<int, int>, bool> traitee = new Dictionary<Tuple<int, int>, bool>();
            
            var firstbool = paper[coords];
            a_traiter.Add(coords, firstbool);

            Console.SetCursorPosition(0, 0);
            Console.Write("A traiter : " + a_traiter.Count);

            while (a_traiter.Count != 0)
            {
                Tuple<int, int> actual_coords = a_traiter.First().Key;

                a_traiter.Remove(actual_coords);
                paper.Remove(actual_coords);

                List<Tuple<int, int>> possibleCases = GetAllPossiblesCases(actual_coords, bounds);
                foreach (Tuple<int, int> coord in possibleCases)
                {
                    if (IsANewCase(paper, coord, a_traiter)) a_traiter.Add(coord, true);
                }

                Console.SetCursorPosition(12, 0);
                Console.Write(a_traiter.Count);
            }
        }

        public static bool IsANewCase(Dictionary<Tuple<int, int>, bool> paper, Tuple<int, int> coords, Dictionary<Tuple<int, int>, bool> a_traiter)
        {
            if (a_traiter.Any(x => x.Key.Item1 == coords.Item1 && x.Key.Item2 == coords.Item2)) return false;
            if (paper.ContainsKey(coords)) return true;
            return false;
        }

        #region Coordinates
        public static bool HasTop(Tuple<int, int> coord, Tuple<int, int> bounds) => (coord.Item2 == 0) ? false : true;
        public static bool HasBottom(Tuple<int, int> coord, Tuple<int, int> bounds) => (coord.Item2 == bounds.Item2 - 1) ? false : true;
        public static bool HasLeft(Tuple<int, int> coord, Tuple<int, int> bounds) => (coord.Item1 == 0) ? false : true;
        public static bool HasRight(Tuple<int, int> coord, Tuple<int, int> bounds) => (coord.Item1 == bounds.Item1 - 1) ? false : true;

        public static Tuple<int, int> GetTop(Tuple<int, int> coord, Tuple<int, int> bounds)
        {
            if (!HasTop(coord, bounds)) return null;
            return new Tuple<int, int>(coord.Item1, coord.Item2 - 1);
        }
        public static Tuple<int, int> GetBottom(Tuple<int, int> coord, Tuple<int, int> bounds)
        {
            if (!HasBottom(coord, bounds)) return null;
            return new Tuple<int, int>(coord.Item1, coord.Item2 + 1);
        }
        public static Tuple<int, int> GetLeft(Tuple<int, int> coord, Tuple<int, int> bounds)
        {
            if (!HasLeft(coord, bounds)) return null;
            return new Tuple<int, int>(coord.Item1 - 1, coord.Item2);
        }
        public static Tuple<int, int> GetRight(Tuple<int, int> coord, Tuple<int, int> bounds)
        {
            if (!HasRight(coord, bounds)) return null;
            return new Tuple<int, int>(coord.Item1 + 1, coord.Item2);
        }

        public static List<Tuple<int, int>> GetAllPossiblesCases(Tuple<int, int> coord, Tuple<int, int> bounds)
        {
            List<Tuple<int, int>> cases = new List<Tuple<int, int>>();
            if (HasTop(coord, bounds)) cases.Add(GetTop(coord, bounds));
            if (HasBottom(coord, bounds)) cases.Add(GetBottom(coord, bounds));
            if (HasLeft(coord, bounds)) cases.Add(GetLeft(coord, bounds));
            if (HasRight(coord, bounds)) cases.Add(GetRight(coord, bounds));
            return cases;
        }
        #endregion        
    }

    public class Config
    {
        public int N { get; set; }
        public int Expected { get; set; }
        public List<string> PaperTemp { get; set; }
    }
}
