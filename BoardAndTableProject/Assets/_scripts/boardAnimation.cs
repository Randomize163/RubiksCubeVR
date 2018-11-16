using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using projectIntefaces;

public class boardAnimation : MonoBehaviour, IBoardController {

    public int index;  // current board instruction
    public int numInsrtuctions;    // number of instructions
    public int numCompleteInstructions; //
    List<string> instructions;
    string done = "DONE!";
    public Animator anim;
    Text[] texts;

    // Use this for initialization
    void Start() {

        index = 0;
        numCompleteInstructions = 0;
        anim = GetComponent<Animator>();
        texts = GetComponentsInChildren<Text>();

        /*
        texts[0].text = "L";
        texts[1].text = "R";
        texts[2].text = "D";
        texts[3].text = "U";
        texts[4].text = "F";
        */
        instructions = new List<string>();
        /*
        instructions.Add("L");
        instructions.Add("R");
        instructions.Add("D");
        instructions.Add("U");
        instructions.Add("F");
        instructions.Add("F");
        instructions.Add("U");
        instructions.Add("D");
        instructions.Add("R");
        instructions.Add("L");
        instructions.Add("L");
        instructions.Add("R");
        instructions.Add("D");
        */

        numInsrtuctions = instructions.Count;
    }

	// Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            board.MakeMove("L");
        }*/
    }

    public void UpdateInstructions(List<Move> moves)
    {
        instructions.Clear();
        foreach(Move m in moves)
        {
            instructions.Add(m.ToString());
        }
        numInsrtuctions = instructions.Count;
        numCompleteInstructions = 0;
        // fill first instructions
        for (int i = 0; i < Math.Min(5, numInsrtuctions); i++)
        {
            texts[index].text = instructions[index];
        }
    }

    public void HighlightNextMove()
    {
        int i;
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
                    texts[i].text = instructions[newInstruction++];
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

    public void DisplayMessage(string message, Color c)
    {
        for (int i = 0; i < Math.Min(5, message.Length); i++)
        {
            texts[i].text = message[i].ToString();
            texts[i].color = c;
        }
    }

    public void ActivateAnimation(bool enable)
    {
        anim.enabled = enable;
    }
}
