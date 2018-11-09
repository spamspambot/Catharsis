using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    public float radius = 5.0F;
    public float power = 10.0F;
    public GameObject explosionSound;
    public float bombDelay;
    void Start()
    {
        StartCoroutine("BombStart");
    }

    IEnumerator BombStart()
    {
        yield return new WaitForSeconds(bombDelay);
        Instantiate(explosionSound, transform.position, Quaternion.identity);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb == null && hit.transform.parent != null) { rb = hit.transform.parent.GetComponent<Rigidbody>(); }
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                
                print(rb);
            }
        }


    }
}
