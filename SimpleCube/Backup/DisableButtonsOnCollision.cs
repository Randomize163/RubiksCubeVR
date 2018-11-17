using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ManusVR.Scripts.PhysicalInteraction;
using Assets.ManusVR.Scripts;

public class DisableButtonsOnCollision : MonoBehaviour {

    private GameObject[] buttons;
    private InteractableItem rubik;

    // Use this for initialization
    void Start () {
        buttons = GameObject.FindGameObjectsWithTag("Button");
        rubik = (InteractableItem)GetComponent(typeof(InteractableItem));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<Phalange>())
        {
            return;
        }

        foreach (GameObject button in buttons)
        {
            button.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponentInParent<PhysicsHand>())
        {
            return;
        }

        if (other.gameObject.GetComponentInParent<PhysicsHand>().DeviceType == device_type_t.GLOVE_RIGHT)
        {
            return;
        }
        if (!rubik.IsGrabbed)
        {
            foreach (GameObject button in buttons)
            {
                button.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
