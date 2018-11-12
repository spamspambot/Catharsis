using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {
    Rigidbody rb;
    public GameObject tableSound;
    public bool triggerEnter;
    public float velocityThreshold;
    public Vector3 throwVelocity;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void OnTriggerEnter(Collider other) {
    //   if(other.CompareTag) throwVelocity = rb.velocity;
    }

    void OnTriggerExit(Collider other) {
        if (!triggerEnter && other.CompareTag("Arm"))
        {
            throwVelocity = rb.velocity;
            triggerEnter = true;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Table") || other.gameObject.CompareTag("Ground"))
        {
            if (other.relativeVelocity.magnitude > velocityThreshold)
            {
                GameObject tempSound = Instantiate(tableSound, transform.position, Quaternion.identity);
                tempSound.GetComponent<AudioSource>().volume = 0.1F + (0.9F * Mathf.Clamp(other.relativeVelocity.magnitude, 0, 100) / 100);
            }

        }
    }

}
