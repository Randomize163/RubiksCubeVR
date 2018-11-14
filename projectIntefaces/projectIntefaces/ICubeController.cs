using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectIntefaces
{
    interface ICubeController
    {
        void DoMove(Move m);
        List<Move> GetMoves();
    }
}
