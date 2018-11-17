using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ManusVR.Scripts.PhysicalInteraction;
using Assets.ManusVR.Scripts;

public class ButtonRotator : MonoBehaviour {

    private Cube cube;
    public float angle;
    public GameObject faceObject;
    private string face;
    private char axis;
    private InteractableItem rubik;

    // Use this for initialization
    void Start () {
        GameObject c = GameObject.FindGameObjectWithTag("Cube");
        cube = (Cube)c.GetComponent(typeof(Cube));
        face = faceObject.tag;
        axis = GetAxisFromFaceTag(face);

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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponentInParent<PhysicsHand>())
        {
            return;
        }

        if (other.gameObject.GetComponentInParent<PhysicsHand>().DeviceType == device_type_t.GLOVE_LEFT)
        {
            return;
        }

        if (rubik.IsGrabbed)
        {
            return;
        }

        StartCoroutine(cube.RotateFace(face, axis, angle));
    }
}
