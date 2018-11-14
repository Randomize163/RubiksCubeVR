using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectIntefaces
{
    interface ICubeAlgorithm
    {
        List<Move> GetNextSolutionMoves();
        void DoMoves(List<Move> moves);
        bool IsSolved();
        string GetNextSolutionMovesDescription();
    }
}
