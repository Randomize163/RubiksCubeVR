using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

    private float startTime;
    private bool started;

    private void Start()
    {
        GetComponent<TextMesh>().text = "00:00.00";
    }

    void Update()
    {
        if (!started) return;

        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        GetComponent<TextMesh>().text = minutes + ":" + seconds;
    }

    public void StartTimer()
    {
        started = true;
        startTime = Time.time;
        //StartCoroutine(waiting(10));
    }

    public string StopTimer()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        started = false;
        return minutes + ":" + seconds; 

    }

    IEnumerator waiting(float secods)
    {
        yield return new WaitForSeconds(secods);
        started = false;
    }
}
