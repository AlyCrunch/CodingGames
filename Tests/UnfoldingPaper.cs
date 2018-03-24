using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnfoldingPaperTests
    {
        [TestMethod, Timeout(5000)]
        public void Example_1()
        {
            var config = new UnfoldingPaper.Config()
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
            int result = UnfoldingPaper.Program.Execute(config);
            Assert.AreEqual(result, config.Expected);
        }

        [TestMethod, Timeout(5000)]
        public void MultipleFolds_2()
        {
            var config = new UnfoldingPaper.Config()
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
            int result = UnfoldingPaper.Program.Execute(config);
            Assert.AreEqual(result, config.Expected);
        }
        
        [TestMethod, Timeout(5000)]
        public void BigSheet_3()
        {
            var config = new UnfoldingPaper.Config()
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
            int result = UnfoldingPaper.Program.Execute(config);
            Assert.AreEqual(result, config.Expected);
        }

        [TestMethod, Timeout(5000)]
        public void LongFolding_4()
        {
            var config = new UnfoldingPaper.Config()
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
            int result = UnfoldingPaper.Program.Execute(config);
            Assert.AreEqual(result, config.Expected);
        }

        [TestMethod, Timeout(5000)]
        public void ManyPieces_5()
        {
            var config = new UnfoldingPaper.Config()
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
            int result = UnfoldingPaper.Program.Execute(config);
            Assert.AreEqual(result, config.Expected);
        }

        [TestMethod, Timeout(5000)]
        public void Random_6()
        {
            var config = new UnfoldingPaper.Config()
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
            int result = UnfoldingPaper.Program.Execute(config);
            Assert.AreEqual(result, config.Expected);
        }

        [TestMethod, Timeout(5000)]
        public void Chessboard_7()
        {
            var config = new UnfoldingPaper.Config()
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
            int result = UnfoldingPaper.Program.Execute(config);
            Assert.AreEqual(result, config.Expected);
        }
    }
}
