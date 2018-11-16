using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using projectIntefaces;

public class MainController : MonoBehaviour {

    enum GAME_STATE
    {
        START_STATE,
        STUDYING_STATE,
        FREESTYLE_STATE
    };

    private GameObject studyingButton;
    private GameObject freestyleButton;
    private GameObject exitButton;
    private GAME_STATE currentState;
    private IBoardController board;
    private GameController game;

    // Use this for initialization
    void Start ()
    {
        board = (IBoardController)GameObject.FindGameObjectWithTag("Board").GetComponentInChildren(typeof(IBoardController));
        board.ActivateAnimation(false);
        board.DisplayMessage("Hello", new Color(1,1,0));


        studyingButton = GameObject.FindGameObjectWithTag("StudyingButton");
        freestyleButton = GameObject.FindGameObjectWithTag("FreestyleButton");
        exitButton = GameObject.FindGameObjectWithTag("ExitButton");

        exitButton.SetActive(false);

        currentState = GAME_STATE.START_STATE;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(currentState == GAME_STATE.START_STATE)
        {
            if(((MenuButton)studyingButton.GetComponent("MenuButton")).triggered)
            {
                currentState = GAME_STATE.STUDYING_STATE;
                ((MenuButton)studyingButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(false);
                freestyleButton.SetActive(false);
                exitButton.SetActive(true);
                game.StartLearning();
            }
            if (((MenuButton)freestyleButton.GetComponent("MenuButton")).triggered)
            {
                currentState = GAME_STATE.FREESTYLE_STATE;
                ((MenuButton)freestyleButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(false);
                freestyleButton.SetActive(false);
                exitButton.SetActive(true);
                game.StartFreestyle();
            }

        }
        else if(currentState == GAME_STATE.STUDYING_STATE)
        {
            if (((MenuButton)exitButton.GetComponent("MenuButton")).triggered)
            {
                currentState = GAME_STATE.START_STATE;
                ((MenuButton)exitButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(true);
                freestyleButton.SetActive(true);
                exitButton.SetActive(false);
                game.Exit();
            }
        }
        else if(currentState == GAME_STATE.FREESTYLE_STATE)
        {
            if (((MenuButton)exitButton.GetComponent("MenuButton")).triggered)
            {
                currentState = GAME_STATE.START_STATE;
                ((MenuButton)exitButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(true);
                freestyleButton.SetActive(true);
                exitButton.SetActive(false);
                game.Exit();
            }
        }
        else
        {
            Debug.Assert(false);
        }
	}
}
