using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class FaceTurn : MonoBehaviour {
    public int triggerExit = 0;
    public bool releaseMutex = false;
    public int contactSize = 0;
    public ContactPoint[] contactPoints;
    public GameObject[] contactPointReference;
	private Mutex rotationMutex = new Mutex();
	private BoxCollider col;
    private HashSet<Collider> contactsColliders = new HashSet<Collider>();

	// Use this for initialization
	void Start () {
		col = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        foreach (Collider c in contactsColliders)
        {
            if (i < contactPointReference.Length)
            {
                contactPointReference[i].GetComponent<Transform>().position = c.gameObject.GetComponent<Transform>().position;
            }
        }
	}
    
	private void OnTriggerEnter(Collider other)
	{

		//col.isTrigger = false;
        
		//rotationMutex.WaitOne ();

        /*if (!other.gameObject.CompareTag("FingerCollider"))
        {
            return;
        }*/

        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            contactPointReference.GetComponent<Transform>().position = hit.point;
            Debug.Log("Point of contact: " + hit.point);
        }*/


        //Vector3 tmpDirection = (col.transform.position - GetComponent<Transform>().position);
        //Vector3 tmpContactPoint = GetComponent<Transform>().position + tmpDirection;

        contactsColliders.Add(other);

        /*
        Debug.Log("Success");
		GameObject cube = GameObject.FindGameObjectWithTag("Cube");
		Cube c = (Cube)cube.GetComponent(typeof(Cube));
        switch(tag)
        {
			case "TopFace":
                StartCoroutine(c.RotateFace (tag, 'y', 90f));
				//StartCoroutine(RotateFace ("TopFace", 'y', 90f));
				break;
			//case 1:
				//StartCoroutine(RotateFace ("TopFace", 'y', -90f));
				//break;
			case "BottomFace":
                StartCoroutine(c.RotateFace (tag, 'y', 90f));
				//StartCoroutine(RotateFace ("BottomFace", 'y', -90f));
				break;
			//case 3:
				//StartCoroutine(RotateFace ("BottomFace", 'y', 90f));
				//break;
			case "LeftFace":
				StartCoroutine(c.RotateFace (tag, 'x', -90f));
				break;
			//case 5:
				//StartCoroutine(RotateFace ("LeftFace", 'x', 90f));
				//break;
			case "RightFace":
				StartCoroutine(c.RotateFace (tag, 'x', -90f));
				break;
			//case 7:
				//StartCoroutine(RotateFace ("RightFace", 'x', 90f));
				//break;
			case "FrontFace":
				StartCoroutine(c.RotateFace (tag, 'z', -90f));
				break;
			//case 9:
				//StartCoroutine(RotateFace ("FrontFace", 'z', 90f));
				//break;
			case "BackFace":
				StartCoroutine(c.RotateFace (tag, 'z', -90f));
				break;
			//case 11:
				//StartCoroutine(RotateFace ("BackFace", 'z', 90f));
				//break;
		}*/

	}
    /*
    void OnCollisionEnter(Collision c)
    {
        Debug.Log("CollisionEnter Entered");
        contactSize = c.contacts.Length;
        contactPoints = c.contacts;
        foreach (ContactPoint contact in c.contacts)
        {
            contactPointReference.GetComponent<Transform>().position = contact.point;
        }
    }
    */
	private void OnTriggerExit(Collider other)
	{
        contactsColliders.Remove(other);
        Debug.Log("Exit Success");
        triggerExit++;
		//col.isTrigger = true;
		//rotationMutex.ReleaseMutex ();
	}
     
}
