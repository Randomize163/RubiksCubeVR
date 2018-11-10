using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ManusVR.Scripts.PhysicalInteraction;

public class Rotation : MonoBehaviour {
    public GameObject face;
    public float rotateAngle = 80f;
    public float rotateResetTime = 0.5f;
    private Rigidbody rb;
    private Cube cube;
    private InteractableItem rubik;
    public string tag;
    public char axis;

    private float time = 0;
    private float lastRotateTime = 0;

    private bool wasGrabbed = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        GameObject c = GameObject.FindGameObjectWithTag("Cube");
        cube = (Cube)c.GetComponent(typeof(Cube));
        tag = face.tag;
        axis = GetAxisFromFaceTag(tag);
        c = GameObject.FindGameObjectWithTag("Rubik");
        rubik = (InteractableItem)c.GetComponent(typeof(InteractableItem));
	}
	
    private char GetAxisFromFaceTag(string tag)
    {
        switch (tag)
        {
            case "TopFace":
            case "BottomFace":
                return 'y';
            case "LeftFace":
            case "RightFace":
                return 'x';
            case "FrontFace":
            case "BackFace":
                return 'z';
        }
        
        return 'q';
    }

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (rubik.IsGrabbed)
        {
            wasGrabbed = true;
            return;
        }

        if (wasGrabbed)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            lastRotateTime = time;
            wasGrabbed = false;
        }

        float val = 0;
        switch (axis)
        {
            case 'x':
            {
                val = transform.localEulerAngles.x;
                transform.localRotation = Quaternion.Euler(val, 0, 0);
                break;
            }
            case 'y':
            {
                val = transform.localEulerAngles.y;
                transform.localRotation = Quaternion.Euler(0, val, 0);
                break;
            }
            case 'z':
            {
                val = transform.localEulerAngles.z;
                transform.localRotation = Quaternion.Euler(0, 0, val);
                break;
            }
        }

        val = (val > 180f) ? val - 360f : val;
       
        //float clockwiseTrigger = 360f - rotateAngle;
        //float cclockwiseTrigger = rotateAngle;
        //if (val < clockwiseTrigger && val > clockwiseTrigger - 10f)
        if (val < -rotateAngle)
        {
            rb.isKinematic = true;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            val = 0f;
            rb.isKinematic = false;
            Debug.Log(tag + ": ROTATING VAL: " + val);
            StartCoroutine(cube.RotateFace(tag, axis, -90f));
        }

        //if (val > cclockwiseTrigger && val < cclockwiseTrigger + 10f)
        if (val > rotateAngle)
        {
            rb.isKinematic = true;
            this.gameObject.transform.localRotation = Quaternion.Euler (0, 0, 0);
            val = 0f;
            rb.isKinematic = false;
            Debug.Log(tag + ": ROTATING VAL: " + val);
            StartCoroutine(cube.RotateFace(tag, axis, 90f));

        }

        if (Mathf.Abs(val) < 1f || Mathf.Abs(360f - val) < 1f)
        {
            lastRotateTime = time;
        }

        Debug.Log("Tag: "+ tag + " Val: " + val + " Time: " + time + " Last Rotate: " + lastRotateTime);

        if (time - lastRotateTime > rotateResetTime)
        {
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Reset " + tag);
        }
	}
}
