using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Assets.ManusVR.Scripts.PhysicalInteraction;
//using Assets.ManusVR.Scripts;

public class MenuButton : MonoBehaviour {

    public bool triggered;

    private void OnTriggerExit(Collider other)
    {
        triggered = true;
    }
}
