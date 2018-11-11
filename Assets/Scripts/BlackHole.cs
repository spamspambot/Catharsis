using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public SphereCollider collider;

    public float radius = 20f;
    public float power = -10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
            {
            collider.enabled = true;
            }
	}

    public void OnMouseDown()
        {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
            {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                {
                ReduceClutter(hit);
                }
            }
        }

    public void OnMouseDrag()
        {
        ActivateBlackHole();
        }

    public void ActivateBlackHole()
        {
        

        Debug.Log("clicked");

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
            {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                {
                rb.useGravity = false;
                rb.AddExplosionForce(power, explosionPos, radius, 0f, ForceMode.Impulse);
                }
            }
        }

    public void ReduceClutter(Collider hit)
        {
        bool destroy = (Random.Range(0, 2) == 0);
        if (destroy)
            {
            hit.gameObject.SetActive(false);
            }
        }
    }
