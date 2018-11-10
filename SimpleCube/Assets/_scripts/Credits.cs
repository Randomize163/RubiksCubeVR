using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GUIStyle style;

	// Credits
	public string credits;
	public string underline;

	// URL
	public string url;

	// Label's Position
	public int width = 0;
	public int height = 0;
	public int left = 0;
	public int top = 0;
	private Rect rect;

	void Start() {
		rect = new Rect (left, top, width, height);
	}

	void OnGUI() {

		if(rect.Contains(Event.current.mousePosition))
			GUI.Label (rect, underline, style);

		if (GUI.Button (rect, credits, style))
			Application.OpenURL (url);

	}
}
