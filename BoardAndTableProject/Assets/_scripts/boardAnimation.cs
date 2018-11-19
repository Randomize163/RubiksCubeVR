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
    public Animator anim;
    //public Animator descriptionAnim;
    Text[] texts;
    Text description;

    // DEBUG!!!
    GameController controller;

    // Use this for initialization
    void Start() {

        index = 0;
        numCompleteInstructions = 0;
        anim = GetComponent<Animator>();
        //descriptionAnim = GetComponentInChildren<Animator>();
        texts = GetComponentsInChildren<Text>();
        description = texts[5];

        instructions = new List<string>();

        //descriptionAnim.enabled = false;
        anim.enabled = false;
        numInsrtuctions = instructions.Count;

    }

	// Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.L))
        {
            if(controller == null)
            {
                MainController mc = (MainController)FindObjectOfType(typeof(MainController));
                controller = mc.game;
            }
            controller.OnMove(Move.L);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (controller == null)
            {
                MainController mc = (MainController)FindObjectOfType(typeof(MainController));
                controller = mc.game;
            }
            controller.OnMove(Move.R);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (controller == null)
            {
                MainController mc = (MainController)FindObjectOfType(typeof(MainController));
                controller = mc.game;
            }
            controller.OnMove(Move.D);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (controller == null)
            {
                MainController mc = (MainController)FindObjectOfType(typeof(MainController));
                controller = mc.game;
            }
            controller.OnMove(Move.U);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (controller == null)
            {
                MainController mc = (MainController)FindObjectOfType(typeof(MainController));
                controller = mc.game;
            }
            controller.OnMove(Move.F);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (controller == null)
            {
                MainController mc = (MainController)FindObjectOfType(typeof(MainController));
                controller = mc.game;
            }
            controller.OnMove(Move.B);
        }
    }

    public void UpdateInstructions(List<Move> moves)
    {
        instructions.Clear();
        foreach(Move m in moves)
        {
            string temp;
            temp =  (m < Move.LR ) ?  m.ToString() : ((m - 6).ToString() + "i");
            instructions.Add(temp);
        }
        numInsrtuctions = instructions.Count;
        numCompleteInstructions = 0;
        index = 0;
        // fill first instructions
        for (int i = 0; i < Math.Min(5, numInsrtuctions); i++)
        {
            texts[i].text = instructions[i];
            texts[i].color = new Color(1, 0, 0);
        }
    }

    public void HighlightNextMove()
    {
        int i;
        index++;
        numCompleteInstructions++;

        if (index >= 5 || numCompleteInstructions >= numInsrtuctions)
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

        anim.SetTrigger("nextMove");
    }

    public void DisplayMessage(string message, Color color)
    {
        for (int i = 0; i < Math.Min(5, message.Length); i++)
        {
            texts[i].text = message[i].ToString();
            texts[i].color = color;
        }
    }

    public void ActivateAnimation(bool enable)
    {
        anim.enabled = enable;
    }

    public void Clear()
    {
        foreach(Text t in texts)
        {
            t.text = "";
        }
    }

    public void UpdateDescription(string desc, Color color)
    {
        description.text = desc;
        description.color = color;
    }
    /*
    public void AnimateDescription(bool enable)
    {
        description.enabled = enable;
    }*/
}
