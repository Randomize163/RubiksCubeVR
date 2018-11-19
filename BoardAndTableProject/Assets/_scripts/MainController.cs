using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using projectIntefaces;

public class MainController : MonoBehaviour {

    enum GAME_STATE
    {
        START_STATE,
        STUDYING_STATE,
        FREESTYLE_STATE,
        KEYBOARD_STATE
    };

    private GameObject studyingButton;
    private GameObject freestyleButton;
    private GameObject exitButton;
    private GameObject keyboardButtons;
    private GAME_STATE currentState;
    private IBoardController board;
    private scoreboard scoreboard;
    public GameController game;
    private GameObject timer;
    private bool finished;
    private Keyboard keyboard;
    private string currentName;

    private int index = 0;

    // Use this for initialization
    void Start ()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        timer.SetActive(false);

        game = new GameController();

        board = (IBoardController)GameObject.FindGameObjectWithTag("Board").GetComponentInChildren(typeof(IBoardController));
        board.DisplayMessage("HELLO", new Color(1,1,0));
        //board.UpdateDescription("Hello", new Color(1, 1, 0));
        //board.AnimateDescription(true);

        studyingButton = GameObject.FindGameObjectWithTag("StudyingButton");
        freestyleButton = GameObject.FindGameObjectWithTag("FreestyleButton");
        exitButton = GameObject.FindGameObjectWithTag("ExitButton");
        keyboardButtons = GameObject.FindGameObjectWithTag("Keyboard");

        keyboard = (Keyboard)keyboardButtons.GetComponent(typeof(Keyboard));

        studyingButton.SetActive(true);
        freestyleButton.SetActive(true);
        exitButton.SetActive(false);
        keyboardButtons.SetActive(false);

        scoreboard = (scoreboard)GameObject.FindGameObjectWithTag("Scoreboard").GetComponentInChildren(typeof(scoreboard));

        currentState = GAME_STATE.START_STATE;

        finished = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(currentState == GAME_STATE.START_STATE)
        {
            if(((MenuButton)studyingButton.GetComponent("MenuButton")).triggered)
            {
                timer.SetActive(false);
                currentState = GAME_STATE.STUDYING_STATE;
                ((MenuButton)studyingButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(false);
                freestyleButton.SetActive(false);
                exitButton.SetActive(true);
                keyboardButtons.SetActive(false);
                finished = false;
                game.StartLearning();
            }
            if (((MenuButton)freestyleButton.GetComponent("MenuButton")).triggered)
            {
                currentState = GAME_STATE.KEYBOARD_STATE;
                ((MenuButton)freestyleButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(false);
                freestyleButton.SetActive(false);
                exitButton.SetActive(true);
                keyboardButtons.SetActive(true);
                keyboard.StartInput();
            }

        }
        else if(currentState == GAME_STATE.STUDYING_STATE)
        {
            if (((MenuButton)exitButton.GetComponent("MenuButton")).triggered)
            {
                timer.SetActive(false);
                currentState = GAME_STATE.START_STATE;
                ((MenuButton)exitButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(true);
                freestyleButton.SetActive(true);
                exitButton.SetActive(false);
                game.Exit();
                return;
            }
            else if(game.IsFinished() && !finished)
            {
                finished = true;
                board.ActivateAnimation(false);
                board.Clear();
                board.DisplayMessage("DONE!", new Color(0, 1, 0));
            }
        }
        else if(currentState == GAME_STATE.FREESTYLE_STATE)
        {
            if (((MenuButton)exitButton.GetComponent("MenuButton")).triggered)
            {
                timer.SetActive(false);
                currentState = GAME_STATE.START_STATE;
                ((MenuButton)exitButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(true);
                freestyleButton.SetActive(true);
                exitButton.SetActive(false);
                game.Exit();
                return;
            }
            else if (game.IsFinished() && !finished)
            {
                finished = true;
                scoreboard.UpdateScoreInPlace(index++, currentName + "       " + ((Timer)timer.GetComponent(typeof(Timer))).StopTimer());
                board.ActivateAnimation(false);
                board.Clear();
                board.DisplayMessage("DONE!", new Color(0, 1, 0));
            }
        }
        else if(currentState == GAME_STATE.KEYBOARD_STATE)
        {
            if(keyboard.EndOfInput())
            {
                keyboardButtons.SetActive(false);
                currentName = keyboard.GetInput(); 
                timer.SetActive(true);
                ((Timer)timer.GetComponent(typeof(Timer))).StartTimer();
                finished = false;
                game.StartFreestyle();
                currentState = GAME_STATE.FREESTYLE_STATE;
                return;
            }
            if (((MenuButton)exitButton.GetComponent("MenuButton")).triggered)
            {
                timer.SetActive(false);
                currentState = GAME_STATE.START_STATE;
                ((MenuButton)exitButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(true);
                freestyleButton.SetActive(true);
                exitButton.SetActive(false);
                game.Exit();
                return;
            }
        }
        else
        {
            Debug.Assert(false);
        }
	}
}
