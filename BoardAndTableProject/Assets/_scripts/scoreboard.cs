using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour {

    Text[] texts;

    // Use this for initialization
    void Start () {
        texts = GetComponentsInChildren<Text>();
    }
	
    public void UpdateScoreInPlace(int place, string score)
    {
        texts[(place + 1) % 7].text = score + " ";
    }
}
