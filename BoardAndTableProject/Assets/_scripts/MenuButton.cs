using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Assets.ManusVR.Scripts.PhysicalInteraction;
//using Assets.ManusVR.Scripts;

public class MenuButton : MonoBehaviour {

    public bool triggered;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionExit(Collision collision)
    {
        Debug.LogError("TRIGGERED");
        /*
        if (!other.gameObject.GetComponentInParent<PhysicsHand>())
        {
            return;
        }*/

        //triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = true;
    }
}
