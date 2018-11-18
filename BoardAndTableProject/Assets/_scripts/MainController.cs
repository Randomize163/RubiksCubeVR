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
    private scoreboard scoreboard;
    public GameController game;
    private GameObject timer;
    private bool finished;

    private int index = 0;

    // Use this for initialization
    void Start ()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        timer.SetActive(false);

        game = new GameController();

        board = (IBoardController)GameObject.FindGameObjectWithTag("Board").GetComponentInChildren(typeof(IBoardController));
        board.ActivateAnimation(false);
        board.DisplayMessage("Hello", new Color(1,1,0));


        studyingButton = GameObject.FindGameObjectWithTag("StudyingButton");
        freestyleButton = GameObject.FindGameObjectWithTag("FreestyleButton");
        exitButton = GameObject.FindGameObjectWithTag("ExitButton");

        exitButton.SetActive(false);

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
                finished = false;
                game.StartLearning();
            }
            if (((MenuButton)freestyleButton.GetComponent("MenuButton")).triggered)
            {
                currentState = GAME_STATE.FREESTYLE_STATE;
                ((MenuButton)freestyleButton.GetComponent("MenuButton")).triggered = false;
                studyingButton.SetActive(false);
                freestyleButton.SetActive(false);
                exitButton.SetActive(true);
                timer.SetActive(true);
                ((Timer)timer.GetComponent(typeof(Timer))).StartTimer();
                finished = false;
                game.StartFreestyle();
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
            }
            else if (game.IsFinished() && !finished)
            {
                finished = true;
                scoreboard.UpdateScoreInPlace(index++,((Timer)timer.GetComponent(typeof(Timer))).StopTimer());
                board.ActivateAnimation(false);
                board.Clear();
                board.DisplayMessage("DONE!", new Color(0, 1, 0));
            }
        }
        else
        {
            Debug.Assert(false);
        }
	}
}
