using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace projectIntefaces
{
    interface IBoardController
    {
        void UpdateInstructions(List<Move> moves);
        void HighlightNextMove();
        void DisplayMessage(string message, Color c);
        void ActivateAnimation(bool enable);
        void UpdateDescription(string desc);
        void Clear();
    }
}
