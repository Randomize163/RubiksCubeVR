using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    private bool start = false;
    private float startTime;

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "00:00.00";
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartTimer();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StopTimer();
        }
        if (!start) return;

        float t = Time.time - startTime;

        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f2");

        GetComponent<TextMesh>().text = min + ":" + sec;
	}

    public void StartTimer()
    {
        GetComponent<TextMesh>().text = "00:00.00";
        startTime = Time.time;
        start = true;
    }

    public string StopTimer()
    {
        start = false;

        float t = Time.time - startTime;

        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f2");

        return min + ":" + sec;
    }


}
