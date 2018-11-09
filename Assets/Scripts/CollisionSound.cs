using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {
    public GameObject sfx;
    public GameObject sfx2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Table"))
        {
          GameObject tempSound =  Instantiate(sfx, transform.position, Quaternion.identity);
            tempSound.GetComponent<AudioSource>().volume = 0.1F + (0.9F * Mathf.Clamp(other.relativeVelocity.magnitude, 0, 100) / 100);
        }
        if (other.gameObject.CompareTag("Ground") && sfx2 != null)
        {
            GameObject tempSound2 = Instantiate(sfx2, transform.position, Quaternion.identity);
            tempSound2.GetComponent<AudioSource>().volume = 0.1F + (0.9F * Mathf.Clamp(other.relativeVelocity.magnitude, 0, 100) / 100);
        }
    }
}
