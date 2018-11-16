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

        public GameController()
        {

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

        }
    }
}
