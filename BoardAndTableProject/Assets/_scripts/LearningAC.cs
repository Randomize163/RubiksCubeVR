using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace projectIntefaces
{
    class LearningAC : IActionController
    {
        private ICubeAlgorithm cubeAlgorithm;
        private IBoardController board;

        List<Move> moves;
        int currentMove;

        public LearningAC()
        {
            board = (IBoardController)GameObject.FindGameObjectWithTag("Board").GetComponentInChildren(typeof(IBoardController));

            //board.UpdateDescription(cubeAlgorithm.GetNextSolutionMovesDescription());!!!!!!!!!!!!
            board.UpdateDescription("Solving Cross:");

            //moves = cubeAlgorithm.GetNextSolutionMoves(); !!!!!!!!!!!
            List<Move> movess = new List<Move>();
            movess.Add(Move.B);
            movess.Add(Move.D);
            movess.Add(Move.F);
            movess.Add(Move.L);
            movess.Add(Move.U);
            movess.Add(Move.B);
            movess.Add(Move.D);

            moves = movess;

            board.UpdateInstructions(moves);
            board.ActivateAnimation(true);

            currentMove = 0;
        }

        public void OnMove(Move m)
        {
            if(m != moves[currentMove])
            {
                return;
            }

            currentMove++;
            board.HighlightNextMove();

            if(currentMove >= moves.Count)
            {
                //board.UpdateDescription(cubeAlgorithm.GetNextSolutionMovesDescription());
                board.UpdateDescription("Solving Corners :");
                List<Move> movess = new List<Move>();
                movess.Add(Move.U);
                movess.Add(Move.L);
                movess.Add(Move.F);
                movess.Add(Move.D);
                movess.Add(Move.B);
                
                moves = movess;

                currentMove = 0;
                board.UpdateInstructions(moves);
            }
        }

        public void OnCubeGrabbed()
        {

        }
    }
}
