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
        private ICubeController cubeController;

        List<Move> instructions;
        int currentInstr;

        public LearningAC()
        {
            cubeAlgorithm = new TestCubeAlgorithm();
            board = (IBoardController)GameObject.FindGameObjectWithTag("Board").GetComponentInChildren(typeof(IBoardController));
            cubeController = new TestCubeController();
            UpdateData();
            board.ActivateAnimation(true);
        }

        public void OnMove(Move m)
        {
            cubeController.DoMove(m);

            if (m != instructions[currentInstr])
            {
                // TBD : what we are doing in case of incorrect move
                cubeAlgorithm.DoMoves(cubeController.GetMoves());
                UpdateData();

                return;
            }

            currentInstr++;
            board.HighlightNextMove();
            
            if(currentInstr >= instructions.Count)
            {
                UpdateData();
            }
        }

        public void OnCubeGrabbed()
        {

        }

        public bool IsSolved()
        {
            return cubeAlgorithm.IsSolved();
        }

        private void UpdateData()
        {
            board.UpdateDescription(cubeAlgorithm.GetNextSolutionMovesDescription(), new Color(1,1,0));

            instructions = cubeAlgorithm.GetNextSolutionMoves();
            board.UpdateInstructions(instructions);
            currentInstr = 0;
        }
    }

}
