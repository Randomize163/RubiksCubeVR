using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using projectIntefaces;

public class RotatorsController : MonoBehaviour {

    private GameObject[] topRotators;
    private GameObject[] topRevRotators;
    private GameObject[] bottomRotators;
    private GameObject[] bottomRevRotators;
    private GameObject[] leftRotators;
    private GameObject[] leftRevRotators;
    private GameObject[] rightRotators;
    private GameObject[] rightRevRotators;
    private GameObject[] frontRotators;
    private GameObject[] frontRevRotators;
    private GameObject[] backRotators;
    private GameObject[] backRevRotators;

    // Use this for initialization
    void Start () {
        topRotators         = GameObject.FindGameObjectsWithTag("RotatorTop");
        topRevRotators      = GameObject.FindGameObjectsWithTag("RotatorTopR");
        bottomRotators      = GameObject.FindGameObjectsWithTag("RotatorBottom");
        bottomRevRotators   = GameObject.FindGameObjectsWithTag("RotatorBottomR");
        leftRotators        = GameObject.FindGameObjectsWithTag("RotatorLeft");
        leftRevRotators     = GameObject.FindGameObjectsWithTag("RotatorLeftR");
        rightRotators       = GameObject.FindGameObjectsWithTag("RotatorRight");
        rightRevRotators    = GameObject.FindGameObjectsWithTag("RotatorRightR");
        frontRotators       = GameObject.FindGameObjectsWithTag("RotatorFront");
        frontRevRotators    = GameObject.FindGameObjectsWithTag("RotatorFrontR");
        backRotators        = GameObject.FindGameObjectsWithTag("RotatorBack");
        backRevRotators     = GameObject.FindGameObjectsWithTag("RotatorBackR");
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void SetHighlightValue(GameObject[] objects, bool highlight)
    {
        foreach (GameObject obj in objects)
        {
            obj.GetComponent<Animator>().SetBool("Highlight", highlight);
        }
    }

    private void OnHighlightMoveChange(Move m, bool highlight)
    {
        switch (m)
        {
            case Move.R:
                SetHighlightValue(rightRotators, highlight);
                break;
            case Move.L:
                SetHighlightValue(leftRotators, highlight);
                break;
            case Move.U:
                SetHighlightValue(topRotators, highlight);
                break;
            case Move.D:
                SetHighlightValue(bottomRotators, highlight);
                break;
            case Move.F:
                SetHighlightValue(frontRotators, highlight);
                break;
            case Move.B:
                SetHighlightValue(backRotators, highlight);
                break;
            case Move.RR:
                SetHighlightValue(rightRevRotators, highlight);
                break;
            case Move.LR:
                SetHighlightValue(leftRevRotators, highlight);
                break;
            case Move.UR:
                SetHighlightValue(topRevRotators, highlight);
                break;
            case Move.DR:
                SetHighlightValue(bottomRevRotators, highlight);
                break;
            case Move.FR:
                SetHighlightValue(frontRevRotators, highlight);
                break;
            case Move.BR:
                SetHighlightValue(backRotators, highlight);
                break;
        }
    }

    public void OnHighlightMoveStop(Move m)
    {
        OnHighlightMoveChange(m, false);
    }

    public void OnHighlightMoveStart(Move m)
    {
        OnHighlightMoveChange(m, true);
    }
}
