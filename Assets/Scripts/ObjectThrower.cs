using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour {

    public GameObject thrownObject;
    public float throwForce = 5f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
            {
            GameObject table;
            table = Instantiate(thrownObject, transform);
            table.GetComponent<Rigidbody>().AddTorque(new Vector3(90f, 0f));
            table.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, throwForce), ForceMode.Impulse);
            }
	}
}
