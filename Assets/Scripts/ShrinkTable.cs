using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkTable : MonoBehaviour {
    public bool shrinking;
    public float smoothDur;
    Vector3 zeroVector = Vector3.zero;
    float zeroFloat;
    public Vector3 endPosition;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void OnCollisionExit(Collision collision)
    {
        print("Obama");
        if (collision.gameObject.CompareTag("Table")) shrinking = true;
    }

    // Update is called once per frame
    void Update () {
        if (shrinking) {
            transform.localScale = new Vector3(Mathf.SmoothDamp(transform.localScale.x,1,ref zeroFloat,smoothDur), Mathf.SmoothDamp(transform.localScale.y, 1, ref zeroFloat, smoothDur), Mathf.SmoothDamp(transform.localScale.z, 1, ref zeroFloat, smoothDur));
            transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref zeroVector, smoothDur);
            if (transform.localScale.y <= 1.05) { transform.localScale = new Vector3(1, 1, 1); shrinking = false; }
            
        }
        if (transform.localScale.x == 1) rb.isKinematic = false;
    }
}
