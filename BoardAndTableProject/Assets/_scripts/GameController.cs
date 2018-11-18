using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace projectIntefaces
{
    public class GameController
    {
        private IActionController actionController;
        private IBoardController board;

        public GameController()
        {
            board = (IBoardController)GameObject.FindGameObjectWithTag("Board").GetComponentInChildren(typeof(IBoardController));
        }
        public void StartGame()
        {
            
        }
        public void StartLearning()
        {
            actionController = new LearningAC();
        }

        public void StartFreestyle()
        {
            actionController = new FreestyleAC();
        }

        public void OnMove(Move m)
        {
            actionController.OnMove(m);
        }

        public void OnCubeGrabbed()
        {

        }

        public void Exit()
        {
            board.ActivateAnimation(false);
            board.Clear();
        }

        public bool IsFinished()
        {
            return actionController.IsSolved();
        }
    }
}
