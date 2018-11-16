using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectIntefaces
{
    interface IActionController
    {
        void OnMove(Move m);
        void OnCubeGrabbed();
    }
}
