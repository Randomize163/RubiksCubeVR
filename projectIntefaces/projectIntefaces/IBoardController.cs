using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectIntefaces
{
    enum Color  
    {
        Red, Green, Blue
    };
    interface IBoardController
    {
        void UpdateInstructions(List<Move> moves);
        void HighlightNextMove();
        void DisplayMessage(string message, Color c);
    }
}
