using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectIntefaces
{
    interface ICubeModel
    {
        void AnimateMove(Move m);
        void HighlightMove(Move m);
    }
}
