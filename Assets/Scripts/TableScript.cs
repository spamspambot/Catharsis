using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {
    Rigidbody rb;
    public bool triggerEnter;
    public Vector3 throwVelocity;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void OnTriggerEnter(Collider other) {
        throwVelocity = rb.velocity;
    }

    void OnTriggerExit(Collider other) {
        if (!triggerEnter)
        {
            throwVelocity = rb.velocity;
            triggerEnter = true;
        }
    }
}
