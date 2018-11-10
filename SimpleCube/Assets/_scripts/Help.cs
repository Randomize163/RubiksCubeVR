using UnityEngine;
using System.Collections;
using System;

public class Help : MonoBehaviour {

	public GUIStyle titleStyle;
	public GUIStyle labelStyle;
	public GUIStyle buttonStyle;

	// Label's Position
	public int width = 300;
	public int height = 30;
	private int halfWidth = 0;
	private int left = 0;
	private int top = 0;

	void OnGUI() {

		left = Screen.width / 2;
		top = Convert.ToInt32(Screen.height * 0.30);
		halfWidth = width / 2;

		GUI.Label (new Rect(left - 60, top - 105, 120, 30), "Rotate Face", titleStyle);

		GUI.Label (new Rect(left - width, top - 75, width, height), "R -> Top (clockwise)", labelStyle);
		GUI.Label (new Rect(left - width, top - 45, width, height), "T -> Top (counterclockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top - 75, width, height), "Y -> Down (clockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top - 45, width, height), "U -> Down (counterclockwise)", labelStyle);
		GUI.Label (new Rect(left - width, top - 15, width, height), "F -> Left (clockwiseo)", labelStyle);
		GUI.Label (new Rect(left - width, top + 15, width, height), "G -> Left (counterclockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top - 15, width, height), "H -> Right (clockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top + 15, width, height), "J -> Right (counterclockwise)", labelStyle);
		GUI.Label (new Rect(left - width, top + 45, width, height), "V -> Front (clockwise)", labelStyle);
		GUI.Label (new Rect(left - width, top + 75, width, height), "B -> Front (counterclockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top + 45, width, height), "M -> Back (clockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top + 75, width, height), "N -> Back (counterclockwiseo)", labelStyle);

		GUI.Label (new Rect (left - 60, top + 105, 120, 30), "Rotate Cube Around", titleStyle);

		GUI.Label (new Rect(left - width, top + 135, width, height), "S -> X Axis (clockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top + 135, width, height), "W -> X Axis (counterclockwise)", labelStyle);
		GUI.Label (new Rect(left - width, top + 165, width, height), "A -> Y Axis(clockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top + 165, width, height), "D -> Y Axis (counterclockwise)", labelStyle);
		GUI.Label (new Rect (left - width, top + 195, width, height), "Q -> Z Axis (clockwise)", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top + 195, width, height), "E -> Z Axis (counterclockwise)", labelStyle);

		GUI.Label (new Rect (left - 60, top + 225, 120, 30), "Change Camera", titleStyle);

		GUI.Label (new Rect(left - width, top + 255, width, height), "1 -> Front Camera", labelStyle);
		GUI.Label (new Rect(left + halfWidth, top + 255, width, height), "2 -> Side Camera", labelStyle);

		if (GUI.Button (new Rect (left - 100, top + 300, 200, 45), "Back", buttonStyle))
			Application.LoadLevel (0);
	}

}
