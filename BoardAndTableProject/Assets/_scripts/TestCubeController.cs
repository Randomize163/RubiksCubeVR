using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectIntefaces
{
    class TestCubeController : ICubeController
    {
        private List<Move> moves;

        public TestCubeController()
        {
            moves = new List<Move>();
        }

        public void DoMove(Move m)
        {
            moves.Add(m);
        }
        public List<Move> GetMoves()
        {
            return moves;
        }
    }
}
