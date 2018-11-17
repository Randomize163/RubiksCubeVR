using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using projectIntefaces;

public class Cube : MonoBehaviour, ICubeModel {
    public float floatPrecision = 0.1f;
    public float rotationSpeed = 0.1f;
    public bool keyboardInputEnabled = true;

    private CoroutineQueue queue;

    void Start()
    {
        queue = new CoroutineQueue(1, StartCoroutine);
    }

    public void HighlightMove(Move m)
    {}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (keyboardInputEnabled)
        {
            if (Input.GetKeyDown(KeyCode.R))
                AnimateMove(Move.U);

            if (Input.GetKeyDown(KeyCode.T))
                AnimateMove(Move.UR);

            if (Input.GetKeyDown(KeyCode.Y))
                AnimateMove(Move.B);

            if (Input.GetKeyDown(KeyCode.U))
                AnimateMove(Move.BR);

            if (Input.GetKeyDown(KeyCode.F))
                AnimateMove(Move.L);

            if (Input.GetKeyDown(KeyCode.G))
                AnimateMove(Move.LR);

            if (Input.GetKeyDown(KeyCode.H))
                AnimateMove(Move.R);

            if (Input.GetKeyDown(KeyCode.J))
                AnimateMove(Move.RR);

            if (Input.GetKeyDown(KeyCode.V))
                AnimateMove(Move.F);

            if (Input.GetKeyDown(KeyCode.B))
                AnimateMove(Move.FR);

            if (Input.GetKeyDown(KeyCode.N))
                AnimateMove(Move.D);

            if (Input.GetKeyDown(KeyCode.M))
                AnimateMove(Move.DR);
        }
    }

    public int GetAnimateMoveTimeMs()
    {
        return 500;
    }

    public void AnimateMove(Move m)
    {
        switch (m)
        {
            case Move.R:
                AnimateRotate("RightFace", 'y', 90);
                break;
            case Move.L:
                AnimateRotate("LeftFace", 'y', -90);
                break;
            case Move.U:
                AnimateRotate("TopFace", 'x', -90);
                break;
            case Move.D:
                AnimateRotate("BottomFace", 'x', 90);
                break;
            case Move.F:
                AnimateRotate("FrontFace", 'z', -90);
                break;
            case Move.B:
                AnimateRotate("BackFace", 'z', 90);
                break;
            case Move.RR:
                AnimateRotate("RightFace", 'y', -90);
                break;
            case Move.LR:
                AnimateRotate("LeftFace", 'y', 90);
                break;
            case Move.UR:
                AnimateRotate("TopFace", 'x', 90);
                break;
            case Move.DR:
                AnimateRotate("BottomFace", 'x', -90);
                break;
            case Move.FR:
                AnimateRotate("FrontFace", 'z', 90);
                break;
            case Move.BR:
                AnimateRotate("BackFace", 'z', -90);
                break;
            default:
                Debug.Assert(false);
                break;
        }
    }
        
    private void AnimateRotate(string faceTag, char axisName, float angle)
	{
        queue.Run(RotateFace(faceTag, axisName, angle));
    }

    private bool FloatEquals(float a, float b)
    {
        return Mathf.Abs(a - b) <= floatPrecision;
    }

    private IEnumerator RotateFace(string faceTag, char axisName, float angle)
	{
        Debug.Log("------------------------------- ROTATING: " + faceTag + " -------------------------------");
      
        GameObject face = GameObject.FindGameObjectWithTag(faceTag);
		GameObject[] slices = GameObject.FindGameObjectsWithTag("Slice");
		
        foreach (GameObject slice in slices)
		{


			switch(axisName)
			{
				case 'x':
                    if (FloatEquals(slice.transform.localPosition.x, face.transform.localPosition.x))
                    {
                        slice.transform.parent = face.transform;
                    }
					break;
				case 'y':
                    if (FloatEquals(slice.transform.localPosition.y, face.transform.localPosition.y))
                    {
                        slice.transform.parent = face.transform;
                    }
                    break;
				case 'z':
                    if (FloatEquals(slice.transform.localPosition.z, face.transform.localPosition.z))
                    {
                        slice.transform.parent = face.transform;
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
    }
}
