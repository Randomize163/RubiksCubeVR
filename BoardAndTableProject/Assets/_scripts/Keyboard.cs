using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {

    private string input;
    private bool end;

    public void AddSymbol(string symbol)
    {
        if(symbol == "Enter")
        {
            end = true;
            return;
        }
        input = input + symbol;
    }

    public void StartInput()
    {
        end = false;
        input = "";
    }

    public string GetInput()
    {
        return input;
    }

    public bool EndOfInput()
    {
        return end;
    }

}
