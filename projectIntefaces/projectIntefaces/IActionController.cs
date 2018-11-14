using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectIntefaces
{
    interface IActionController
    {
        void OnMove(Move m);
        void OnCubeGrabbed();
    }
}
