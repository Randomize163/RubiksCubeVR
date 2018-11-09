using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RubiksCubeSolverCS
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRandom(10000);

            RubicsCubeSolver cube = new RubicsCubeSolver();
            cube.DoMoves("FLUULFRFLL"); // F L U U L F R F L L

            //Console.Write("Initial shuffle: ");
            //shuffle.ForEach(m => Console.Write("{0} ", m.ToString()));
            //Console.WriteLine();

            Console.WriteLine("Solving cross:");
            while (!cube.CrossIsSolved())
            {
                List<Move> moves = cube.SolveEdgeMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }
            }
            Console.WriteLine("Bringing white corners on top:");
            while (!cube.WhiteCornersOnTop())
            {
                List<Move> moves = cube.WhiteCornersToTopMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }
            }
            Console.WriteLine("Fixing white corners:");
            while (!cube.CornersAreSolved())
            {
                List<Move> moves = cube.SolveCornersMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }
            }
            Console.WriteLine("Solving second layer:");
            while (!cube.MidLayerIsSolved())
            {
                List<Move> moves = cube.SolveMidLayerMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }
            }

            Console.WriteLine("OLL Moves:");
            {
                List<Move> moves = cube.SolveOLLMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }

                Debug.Assert(cube.IsOLLSolved());
            }

            Console.WriteLine("PLL Moves:");
            {
                List<Move> moves = cube.SolvePLLMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }   
            }

            Debug.Assert(cube.IsSolved());
        }

        static void TestRandom(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                if (i % 100 == 0)
                {
                    Console.WriteLine("Iteration #{0}", i);
                }

                RubicsCubeSolver cube = new RubicsCubeSolver();
                Random rnd = new Random();

                cube.ShuffleCube((uint)rnd.Next() % 1000);

                while (!cube.CrossIsSolved())
                {
                    List<Move> moves = cube.SolveEdgeMoves();
                    cube.DoMoves(moves);
                }

                while (!cube.WhiteCornersOnTop())
                {
                    List<Move> moves = cube.WhiteCornersToTopMoves();
                    cube.DoMoves(moves);
                }

                while (!cube.CornersAreSolved())
                {
                    List<Move> moves = cube.SolveCornersMoves();
                    cube.DoMoves(moves);
                }

                while (!cube.MidLayerIsSolved())
                {
                    List<Move> moves = cube.SolveMidLayerMoves();
                    cube.DoMoves(moves);
                }

                {
                    List<Move> moves = cube.SolveOLLMoves();
                    cube.DoMoves(moves);

                    Debug.Assert(cube.IsOLLSolved());
                }

                {
                    List<Move> moves = cube.SolvePLLMoves();
                    cube.DoMoves(moves);
                }

                Debug.Assert(cube.IsSolved());
            }
        }
    }
}
