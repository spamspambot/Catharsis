using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public SphereCollider collider;

    public float radius = 20f;
    public float power = -10f;

    private bool reduceClutter = false;
    private bool holeActive = false;

    public int colliderCount;
	
	void Start () {
		
	}
	
	
	void Update () {
	    if (Input.GetMouseButtonDown(0))
            {
            collider.enabled = true;
            if (holeActive)
                {
                gameObject.GetComponent<AudioSource>().Stop();
                holeActive = !holeActive;
                }
            else
                {
                gameObject.GetComponent<AudioSource>().Play();
                reduceClutter = !reduceClutter;
                }
            }

        if (reduceClutter)
            {
            ReduceClutter();
            }

        if (holeActive)
            {
            ActivateBlackHole();
            
        }
        
	}

    public void ReduceClutter()
        {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, 100f);

        foreach (Collider hit in colliders)
            {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                {
                DestroyShard(hit);
                }
            }

        if (holeActive == false)
            {
            reduceClutter = !reduceClutter;
            holeActive = !holeActive;
            }
        
        }

    public void OnMouseDrag()
        {
        ActivateBlackHole();
        }

    public void ActivateBlackHole()
        {
        

       // Debug.Log("clicked");

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

        colliderCount = colliders.Length;

        if (colliderCount > 350)
            {
            ReduceClutter();
            }
        }

    public void DestroyShard(Collider hit)
        {
        bool destroy = (Random.Range(0, 6) == 0);
        if (destroy)
            {
            hit.gameObject.SetActive(false);
            }
        }
    }
