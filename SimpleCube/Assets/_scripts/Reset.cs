using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	public int top = 0;
	public int left = 0;
	public int width = 0;
	public int height = 0;
	public int levelToLoad = 0;

	void OnGUI()
	{
		if (GUI.Button (new Rect (left, top, width, height), "Reset"))
			Application.LoadLevel(levelToLoad);
	}
}
