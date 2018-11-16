using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectIntefaces
{
    interface ICubeController
    {
        void DoMove(Move m);
        List<Move> GetMoves();
    }
}
