using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace projectIntefaces
{
    class FreestyleAC : IActionController
    {
        private ICubeAlgorithm cubeAlgorithm;
        private IBoardController board;
        private ICubeController cubeController;

        private List<Move> moves;

        public FreestyleAC()
        {
            cubeController = new TestCubeController();
            board = (IBoardController)GameObject.FindGameObjectWithTag("Board").GetComponentInChildren(typeof(IBoardController));
            board.DisplayMessage("DoIt!", new Color(0, 1, 0));
            moves = new List<Move>();
        }

        public void OnMove(Move m)
        {
            moves.Add(m);
            cubeController.DoMove(m);
        }
        public void OnCubeGrabbed()
        {

        }
        public bool IsSolved()
        {
            return (moves.Count == 2);
        }
    }
}
