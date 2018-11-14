using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace projectIntefaces
{
    public enum Move { L, R, U, D, F, B, LR, RR, UR, DR, FR, BR };

    static class MoveMethods
    {
        public static Move CharToMove(char c)
        {
            switch (c)
            {
                case 'R':
                    return Move.R;
                case 'L':
                    return Move.L;
                case 'U':
                    return Move.U;
                case 'D':
                    return Move.D;
                case 'F':
                    return Move.F;
                case 'B':
                    return Move.B;
                default:
                    Debug.Assert(false);
                    break;
            }

            return Move.LR;
        }

        public static List<Move> StringToMovesList(string movesStr)
        {
            List<Move> moves = new List<Move>();

            foreach (char c in movesStr)
            {
                moves.Add(CharToMove(c));
            }

            return moves;
        }

        public static Move Reverse(this Move m)
        {
            switch (m)
            {
                case Move.R:
                    return Move.RR;
                case Move.L:
                    return Move.LR;
                case Move.U:
                    return Move.UR;
                case Move.D:
                    return Move.DR;
                case Move.F:
                    return Move.FR;
                case Move.B:
                    return Move.BR;
                case Move.RR:
                    return Move.R;
                case Move.LR:
                    return Move.L;
                case Move.UR:
                    return Move.U;
                case Move.DR:
                    return Move.D;
                case Move.FR:
                    return Move.F;
                case Move.BR:
                    return Move.B;
                default:
                    Debug.Assert(false);
                    return Move.B;
            }
        }
    }
}
