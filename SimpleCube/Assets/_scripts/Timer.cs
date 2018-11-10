using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

	public GUIStyle titleStyle;
	public GUIStyle timeStyle;

	public int top = 0;
	public int left = 0;

	private string buttonText = "Play";
	private bool running = false;

	private float ticks = 0;
	private int hour = 0;
	private int minute = 0;
	private int second = 0;

	// Update is called once per frame
	void Update ()
	{
		if (running)
		{
			ticks += Time.deltaTime;
			second = (int) ticks % 60;
			minute = (int) ticks / 60;
			hour = (int) (ticks / 60) / 60;
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(left + 0, top + 0, 100, 25), "Time Elapsed", titleStyle);
		GUI.Label (
			new Rect (left + 0, top + 15, 100, 25), 
			hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00"),
			timeStyle
		);

		if (GUI.Button (new Rect (left + 20, top + 40, 60, 25), buttonText))
		{
			running = !running;
			if(running)
				buttonText = "Stop";
			else
				buttonText = "Play";
		}
	}
}
