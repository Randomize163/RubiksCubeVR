using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class boardAnimation : MonoBehaviour {

    public int index;  // current board instruction
    public int numInsrtuctions;    // number of instructions
    public int numCompleteInstructions; //
    List<string> moves;
    string done = "DONE!";
    Animator anim;
    Text[] texts;

    private boardAnimation board;

    // Use this for initialization
    void Start () {

        GameObject c = GameObject.FindGameObjectWithTag("Board");
        board = (boardAnimation)c.GetComponentInChildren(typeof(boardAnimation));

        index = 0;
        numCompleteInstructions = 0;
        anim = GetComponent<Animator>();
        texts = GetComponentsInChildren<Text>();

        texts[0].text = "L";
        texts[1].text = "R";
        texts[2].text = "D";
        texts[3].text = "U";
        texts[4].text = "F";

        moves = new List<string>();

        moves.Add("L");
        moves.Add("R");
        moves.Add("D");
        moves.Add("U");
        moves.Add("F");
        moves.Add("F");
        moves.Add("U");
        moves.Add("D");
        moves.Add("R");
        moves.Add("L");
        moves.Add("L");
        moves.Add("R");
        moves.Add("D");

        numInsrtuctions = moves.Count;
    }
	/*
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            anim.SetTrigger("firstLetter");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            texts[index].text = "A";
        }
    }
    */

    public void UpdateInstructions(List<string> _moves)
    {
        moves = _moves;
        numInsrtuctions = moves.Count;
        numCompleteInstructions = 0;
        for (int i = 0; i < Math.Min(5, numInsrtuctions); i++)
        {
            texts[index].text = moves[index];
        }
    }

    public void MakeMove(string move)
    {
        int i;
        if (texts[index].text == move)
        {
            index++;
            numCompleteInstructions++;

            if (index >= 5 || numCompleteInstructions >= numInsrtuctions)
            {
                if (numCompleteInstructions >= numInsrtuctions)
                {
                    anim.enabled = false;
                    for (i = 0; i < 5; i++)
                    {
                        texts[i].text = done[i].ToString();
                        texts[i].color = new Color(0, 1, 0);
                    }
                    return;
                }
                else
                {
                    index = 0;
                    int newInstruction = numCompleteInstructions;
                    for (i = 0; i < Math.Min(5, numInsrtuctions - numCompleteInstructions); i++)
                    {
                        texts[i].text = moves[newInstruction++];
                    }
                    for (; i < 5; i++)
                    {
                        texts[i].text = " ";

                    }
                    anim.ResetTrigger("nextMove");
                    anim.SetTrigger("toFirst");
                    return;
                }
            }

            anim.SetTrigger("nextMove");
        }
        else
        {

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            board.MakeMove("L");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            board.MakeMove("R");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            board.MakeMove("D");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            board.MakeMove("U");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            board.MakeMove("F");
        }
    }


}
