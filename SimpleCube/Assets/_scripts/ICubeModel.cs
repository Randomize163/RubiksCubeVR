using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectIntefaces
{
    interface ICubeModel
    {
        void AnimateMove(Move m);
        void HighlightMove(Move m);
        int GetAnimateMoveTimeMs();
    }
}
