using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Button's Style
	public GUIStyle style;
	
	// Button's Position
	public int width = 200;
	public int height = 45;
	private int halfWidth = 0;
	private int x = 0;
	private int y = 0;

	void OnGUI() {

		x = Screen.width / 2;
		y = Screen.height / 2;
		halfWidth = width / 2;

		if (GUI.Button (new Rect (x - halfWidth, y - 70, width, height), "Help", style))
			Application.LoadLevel (1);
		if (GUI.Button (new Rect (x - halfWidth, y - 23, width, height), "Free Solve", style))
			Application.LoadLevel (2);
		if (GUI.Button (new Rect (x - halfWidth, y + 23, width, height), "Speed Solve", style))
			Application.LoadLevel (3);
		if (GUI.Button (new Rect (x - halfWidth, y + 70, width, height), "Quit", style))
			Application.Quit ();

	}
}
