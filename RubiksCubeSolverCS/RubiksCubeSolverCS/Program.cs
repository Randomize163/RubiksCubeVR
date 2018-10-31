using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSolverCS
{
    class Program
    {
        static void Main(string[] args)
        {
            RubicsCubeSolver cube = new RubicsCubeSolver();
            cube.ShuffleCube(200);

            Console.WriteLine("1 stage");
            while (!cube.CrossIsSolved())
            {
                List<Move> moves = cube.SolveEdgeMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }
            }
            Console.WriteLine("2 stage");
            while (!cube.WhiteCornersOnTop())
            {
                List<Move> moves = cube.WhiteCornersToTopMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }
            }
            Console.WriteLine("3 stage");
            while (!cube.CornersAreSolved())
            {
                List<Move> moves = cube.SolveCornersMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }
            }
            Console.WriteLine("4 stage");
            while (!cube.MidLayerIsSolved())
            {
                List<Move> moves = cube.SolveMidLayerMoves();
                foreach (Move m in moves)
                {
                    Console.WriteLine("{0}", m.ToString());
                    cube.DoMove(m);
                }
            }
            Console.WriteLine("5 stage");
        }
    }
}
