using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class Cube : MonoBehaviour {
	
	public Camera[] cameras;
	public GUIStyle labelStyle;
    public float ScaleFloat = 0.01f;
    public float waitBeforeNextRotate = 1;

    private float time = 0;
    private float lastHitTime = 0;
	private float horizontalSlider = 5;
	private float rotationSpeed = 0;
	private int rotationCounter = 0;
	private Mutex rotationMutex = new Mutex();
	private volatile bool shuffleLocked = false;
	private volatile bool rotationLocked = false;

	void OnGUI()
	{
		if (GUI.Button(new Rect(33, 15, 80, 25), "Shuffle") && !this.shuffleLocked)
			StartCoroutine(ShuffleCube());

		/*if (GUI.Button (new Rect (Screen.width - 112, Screen.height - 40, 80, 25),"Menu"))
			Application.LoadLevel (0);
            */
		// Controla a velocidade de rotaçao das faces do cubo
		GUI.Label(new Rect((Screen.width / 2) - 55, 5, 100, 15), "Rotation Speed: " + horizontalSlider, labelStyle);
		horizontalSlider = Mathf.Round (GUI.HorizontalSlider (new Rect ((Screen.width / 2) - 50, 25, 100, 100), horizontalSlider, 1, 10));

		// Converte o intervalo de [1, 10] para [0.1,0.3]
		// Formula
		// NewValue = (((OldValue - OldMin) * (NewMax - NewMin)) / (OldMax - OldMin)) + NewMin
		rotationSpeed = (((horizontalSlider - 1f) * (0.35f - 0.1f)) / (10f - 1f)) + 0.1f;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        time += Time.deltaTime;

		if(Input.GetKeyDown(KeyCode.Alpha1))
			SelectCamera ("Camera1");
		
		if(Input.GetKeyDown(KeyCode.Alpha2))
			SelectCamera ("Camera2");

		if(Input.GetKeyDown (KeyCode.W) && !this.rotationLocked)
			StartCoroutine(RotateCube('x', 90));
		
		if(Input.GetKeyDown (KeyCode.S) && !this.rotationLocked)
			StartCoroutine(RotateCube('x', -90));
		
		if(Input.GetKeyDown (KeyCode.A) && !this.rotationLocked)
			StartCoroutine (RotateCube ('y', 90));
		
		if(Input.GetKeyDown (KeyCode.D) && !this.rotationLocked)
			StartCoroutine (RotateCube ('y', -90));
		
		if(Input.GetKeyDown (KeyCode.Q) && !this.rotationLocked)
			StartCoroutine (RotateCube ('z', 90));
		
		if(Input.GetKeyDown (KeyCode.E) && !this.rotationLocked)
			StartCoroutine (RotateCube ('z', -90));
		
		if(Input.GetKeyDown(KeyCode.R) && !this.rotationLocked)
			StartCoroutine(RotateFace ("TopFace", 'y', 90));
		
		if(Input.GetKeyDown(KeyCode.T) && !this.rotationLocked)
			StartCoroutine(RotateFace ("TopFace", 'y', -90));
		
		if(Input.GetKeyDown(KeyCode.Y) && !this.rotationLocked)
			StartCoroutine(RotateFace ("BottomFace", 'y', 90));
		
		if(Input.GetKeyDown(KeyCode.U) && !this.rotationLocked)
			StartCoroutine(RotateFace ("BottomFace", 'y', -90)); 
		
		if(Input.GetKeyDown(KeyCode.F) && !this.rotationLocked)
			StartCoroutine(RotateFace ("LeftFace", 'x', -90));
		
		if(Input.GetKeyDown(KeyCode.G) && !this.rotationLocked)
			StartCoroutine(RotateFace ("LeftFace", 'x', 90));
		
		if(Input.GetKeyDown(KeyCode.H) && !this.rotationLocked)
			StartCoroutine(RotateFace ("RightFace", 'x', -90));
		
		if(Input.GetKeyDown(KeyCode.J) && !this.rotationLocked)
			StartCoroutine(RotateFace ("RightFace", 'x', 90));
		
		if(Input.GetKeyDown(KeyCode.V) && !this.rotationLocked)
			StartCoroutine(RotateFace ("FrontFace", 'z', -90));
		
		if(Input.GetKeyDown(KeyCode.B) && !this.rotationLocked)
			StartCoroutine(RotateFace ("FrontFace", 'z', 90));
		
		if(Input.GetKeyDown(KeyCode.N) && !this.rotationLocked)
			StartCoroutine(RotateFace ("BackFace", 'z', -90));
		
		if(Input.GetKeyDown(KeyCode.M) && !this.rotationLocked)
			StartCoroutine(RotateFace ("BackFace", 'z', 90));
	}

    private bool FloatEquals(float a, float b)
    {
        return Mathf.Abs(a - b) <= ScaleFloat;
    }

	public void DoRotate(string faceTag, char axisName, float angle)
	{
		GameObject face = GameObject.FindGameObjectWithTag(faceTag);
		GameObject[] slices = GameObject.FindGameObjectsWithTag("Slice");

		foreach(GameObject slice in slices)
		{
				switch(axisName)
				{
				case 'x':
						if(FloatEquals(slice.transform.position.x, face.transform.position.x))
								slice.transform.parent = face.transform;
						break;
				case 'y':
                    if (FloatEquals(slice.transform.position.y, face.transform.position.y))
                        slice.transform.parent = face.transform;
						break;
				case 'z':
                    if (FloatEquals(slice.transform.position.z, face.transform.position.z))
                        slice.transform.parent = face.transform;
						break;
				}
		}

		Quaternion rotation;
		switch(axisName)
		{
		case 'x':
				rotation = Quaternion.Euler(angle, 0, 0);
				break;
		case 'y':
				rotation = Quaternion.Euler(0, angle, 0);
				break;
		case 'z':
				rotation = Quaternion.Euler(0, 0, angle);
				break;
		default:
				rotation = Quaternion.Euler(0, 0, 0);
				break;
		}
		face.transform.rotation = rotation;
	}

	public void AnimateRotate(string faceTag, char axisName, float angle)
	{
		StartCoroutine (RotateFace(faceTag, axisName, angle));
	}
	
	IEnumerator ShuffleCube()
	{
		this.shuffleLocked = true;
		int i = 0;
		while(i < 25)
		{
			if(!this.rotationLocked)
			{
				switch(Random.Range(0, 11))
				{
					case 0:
						StartCoroutine(RotateFace ("TopFace", 'y', 90f));
						break;
					case 1:
						StartCoroutine(RotateFace ("TopFace", 'y', -90f));
						break;
					case 2:
						StartCoroutine(RotateFace ("BottomFace", 'y', -90f));
						break;
					case 3:
						StartCoroutine(RotateFace ("BottomFace", 'y', 90f));
						break;
					case 4:
						StartCoroutine(RotateFace ("LeftFace", 'x', -90f));
						break;
					case 5:
						StartCoroutine(RotateFace ("LeftFace", 'x', 90f));
						break;
					case 6:
						StartCoroutine(RotateFace ("RightFace", 'x', -90f));
						break;
					case 7:
						StartCoroutine(RotateFace ("RightFace", 'x', 90f));
						break;
					case 8:
						StartCoroutine(RotateFace ("FrontFace", 'z', -90f));
						break;
					case 9:
						StartCoroutine(RotateFace ("FrontFace", 'z', 90f));
						break;
					case 10:
						StartCoroutine(RotateFace ("BackFace", 'z', -90f));
						break;
					case 11:
						StartCoroutine(RotateFace ("BackFace", 'z', 90f));
						break;
					}
					i++;
			}
			else
				yield return null;
		}
		this.shuffleLocked = false;
	}

	public IEnumerator RotateFace(string faceTag, char axisName, float angle)
	{
        Debug.Log("------------------------------- ROTATING: " + faceTag + " -------------------------------");
        rotationMutex.WaitOne();

        if (time - lastHitTime < waitBeforeNextRotate)
        {
            yield break;   
        }
       
        lastHitTime = time;

		GameObject face = GameObject.FindGameObjectWithTag(faceTag);
		GameObject[] slices = GameObject.FindGameObjectsWithTag("Slice");
		
		if(!this.shuffleLocked)
			this.rotationCounter++;

		this.rotationLocked = true;

        foreach (GameObject slice in slices)
		{
			switch(axisName)
			{
				case 'x':
                    if (FloatEquals(slice.transform.localPosition.x, face.transform.localPosition.x))
                    {
                        slice.transform.parent = face.transform;
                        //slice.gameObject.SetActive(false);
                    }
					break;
				case 'y':
                    if (FloatEquals(slice.transform.localPosition.y, face.transform.localPosition.y))
                    {
                        slice.transform.parent = face.transform;
                        //slice.gameObject.SetActive(false);
                    }
                    break;
				case 'z':
                    if (FloatEquals(slice.transform.localPosition.z, face.transform.localPosition.z))
                    {
                        slice.transform.parent = face.transform;
                        //slice.gameObject.SetActive(false);
                    }
                    break;
			}
		}
		
		float i = 0.0f;
		while(i < 1.0f)
		{
			i += rotationSpeed;
			Quaternion rotation;
			switch(axisName)
			{
				case 'x':
					rotation = Quaternion.Euler(angle, 0, 0);
					break;
				case 'y':
					rotation = Quaternion.Euler(0, angle, 0);
					break;
				case 'z':
					rotation = Quaternion.Euler(0, 0, angle);
					break;
				default:
					rotation = Quaternion.Euler(0, 0, 0);
					break;
			}
			face.transform.localRotation = Quaternion.Lerp(face.transform.localRotation, rotation, i);
			yield return null;
		}
		
		foreach(GameObject slice in slices)
		{
			slice.transform.parent = this.gameObject.transform;	
		}
		
		face.transform.localRotation = Quaternion.Euler (0, 0, 0);

        this.rotationLocked = false;
        rotationMutex.ReleaseMutex();
	}
	
	IEnumerator RotateCube(char axis, float axisValue)
	{
		GameObject innerPoint = GameObject.FindGameObjectWithTag("InnerPoint");
		GameObject[] slices = GameObject.FindGameObjectsWithTag("Slice");

        Quaternion oldInnerPointRotation = innerPoint.transform.localRotation;

        this.rotationLocked = true;
		rotationMutex.WaitOne();

		foreach(GameObject slice in slices)
			slice.transform.parent = innerPoint.transform;
			
		float i = 0.0f;
		Quaternion rotation;
		while(i < 1.0f)
		{
			i += 0.1f;
			switch(axis)
			{
				case 'x':
					rotation = Quaternion.Euler (axisValue, 0, 0);
					break;
				case 'y':
					rotation = Quaternion.Euler (0, axisValue, 0);
					break;
				case 'z':
					rotation = Quaternion.Euler (0, 0, axisValue);
					break;
				default:
					rotation = Quaternion.Euler (0, 0, 0);
					break;
			}
			innerPoint.transform.localRotation = Quaternion.Lerp (innerPoint.transform.localRotation, rotation, i);
			yield return null;
		}
		
		foreach(GameObject slice in slices)
			slice.transform.parent = this.gameObject.transform;

        innerPoint.transform.localRotation = oldInnerPointRotation;

        this.rotationLocked = false;
		rotationMutex.ReleaseMutex();
	}
	
	private void SelectCamera(string cameraTag)
	{
		foreach(Camera camera in this.cameras)
		{
			if(camera.tag == cameraTag)
				camera.gameObject.SetActive(true);
			else
				camera.gameObject.SetActive(false);
		}
	}
}
