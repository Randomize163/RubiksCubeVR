using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardButton : MonoBehaviour {

    private Keyboard keyboard;
    private string text;

    // Use this for initialization
    void Start () {
        keyboard = (Keyboard)(GameObject.FindGameObjectWithTag("Keyboard")).GetComponent(typeof(Keyboard));
        text = GetComponent<TextMesh>().text;
    }

    private void OnTriggerExit(Collider other)
    {
        keyboard.AddSymbol(text);
    }
}
