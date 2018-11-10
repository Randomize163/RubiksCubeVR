using UnityEngine;
using System.Collections;

public class MouseHandler : MonoBehaviour {

	public Cube cube;
	public string face;

	private float mouseDistance = 0;
	private bool trackMouse = false;
	private Vector3 lastPosition;

		void OnMouseDown() {

				if(Input.GetButtonDown("Fire1"))
				{
						trackMouse = true;
						lastPosition = Input.mousePosition;
				}
		}
		void OnMouseUp() {

				if(Input.GetButtonUp("Fire1"))
				{


						char axis = 'x';
						if (face == "FrontFace" || face == "BackFace" ) {
								axis = 'z';
						}
						else if (face == "LeftFace" || face == "RightFace" ) {
								axis = 'x';
						}
						else if (face == "TopFace" || face == "BottomFace" ) {
								axis = 'y';
						}

						trackMouse = false;

						lastPosition = Input.mousePosition;
						float value = 0;
						mouseDistance %= 360;
						if (mouseDistance > 0) {
								if (mouseDistance < 45)
										value = 0;
								else if (mouseDistance < 135)
										value = 90;
								else if (mouseDistance < 215)
										value = 180;
								else if (mouseDistance < 305)
										value = 270;
								else
										value = 0;
						} else {
								if (mouseDistance > -45)
										value = 0;
								else if (mouseDistance > -135)
										value = -90;
								else if (mouseDistance > -215)
										value = -180;
								else if (mouseDistance > -305)
										value = -270;
								else
										value = 0;
						}
						mouseDistance = 0;
						cube.AnimateRotate (face, axis, value);
				}
		}

	void Update ()
		{
				
				if (trackMouse)
				{
						Debug.Log (transform.rotation);

						char axis = 'x';
						if (face == "FrontFace" || face == "BackFace" ) {
								axis = 'z';
						}
						else if (face == "LeftFace" || face == "RightFace" ) {
								axis = 'x';
						}
						else if (face == "TopFace" || face == "BottomFace" ) {
								axis = 'y';
						}



						var newPosition = Input.mousePosition;
						// If you just want the x-axis:
						mouseDistance += (newPosition.y - lastPosition.y);
						// If you just want the y-axis,change newPosition.x to newPosition.y and lastPosition.x to lastPosition.y
						// If you want the entire distance moved (not just the X-axis, use:
						//mouseDistance += (newPosition - lastPosition).magnitude;
//						Debug.Log("Distance: " + mouseDistance + " -- " + newPosition.ToString());
						lastPosition = newPosition;
						cube.DoRotate (face, axis, mouseDistance);

				}


				// 

	}
}
