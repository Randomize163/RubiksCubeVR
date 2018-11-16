using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using RubiksCubeSolverCS;

namespace projectIntefaces
{
    class SimpleCubeAlgorithm : ICubeAlgorithm
    {
        private RubicsCubeSolver cubeSolver;

        public SimpleCubeAlgorithm()
        {
            cubeSolver = new RubicsCubeSolver();
        }

        public List<Move> GetNextSolutionMoves()
        {
            if (!cubeSolver.CrossIsSolved())
            {
                return cubeSolver.SolveEdgeMoves();
            }
            
            if (!cubeSolver.WhiteCornersOnTop())
            {
                return cubeSolver.WhiteCornersToTopMoves();
            }
 
            if (!cubeSolver.CornersAreSolved())
            {
                return cubeSolver.SolveCornersMoves();
            }
   
            if (!cubeSolver.MidLayerIsSolved())
            {
                return cubeSolver.SolveMidLayerMoves();
            }

            if (!cubeSolver.IsOLLSolved())
            {
                return cubeSolver.SolveOLLMoves();
            }

            if (!cubeSolver.IsSolved())
            {
                return cubeSolver.SolvePLLMoves();
            }

            Debug.Assert(cubeSolver.IsSolved());

            return new List<Move>();
        }

        public void DoMoves(List<Move> moves)
        {
            cubeSolver.DoMoves(moves);
        }

        public bool IsSolved()
        {
            return cubeSolver.IsSolved();
        }

        public string GetNextSolutionMovesDescription()
        {
            if (!cubeSolver.CrossIsSolved())
            {
                return "Stage I, Part I: \"Solving White Cross moves\"";
            }

            if (!cubeSolver.WhiteCornersOnTop())
            {
                return "Stage I, Part II: \"Bringing white corner to top moves\"";
            }

            if (!cubeSolver.CornersAreSolved())
            {
                return "Stage I, Part III: \"Solving white corners\"";
            }

            if (!cubeSolver.MidLayerIsSolved())
            {
                return "Stage II, Part I: \"Solving mid layer\"";
            }

            if (!cubeSolver.IsOLLSolved())
            {
                return "Stage III, Part I: \"Solving OLL\"";
            }

            if (!cubeSolver.IsSolved())
            {
                return "Stage III, Part II: \"Solving PLL\"";
            }

            return "Congratulations, Rubiks Cube is solved!";
        }
    }
}
