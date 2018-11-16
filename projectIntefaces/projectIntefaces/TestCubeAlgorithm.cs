using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using RubiksCubeSolverCS;


namespace projectIntefaces
{
    class TestCubeAlgorithm
    {
        private ICubeAlgorithm cubeAlg;

        public void RunTest()
        {
            RubicsCubeSolver cube = new RubicsCubeSolver();
            cubeAlg = new SimpleCubeAlgorithm();

            List<Move> shuffleMoves = cube.ShuffleCube(200);
            cubeAlg.DoMoves(shuffleMoves);

            while (!cubeAlg.IsSolved())
            {
                List<Move> solution = cubeAlg.GetNextSolutionMoves();
                string description = cubeAlg.GetNextSolutionMovesDescription();

                Console.WriteLine(description);
                solution.ForEach(m => Console.Write("{0} ", m));
                Console.WriteLine();

                cubeAlg.DoMoves(solution);
                cube.DoMoves(solution);
            }

            Debug.Assert(cube.IsSolved());
        }

    }
}
