using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCloneScript : MonoBehaviour
{
    public GameObject realTable;
    public GameObject tableSound;
    public Vector3 startPos;
    public Vector3 realTableStartPos;
    public float randomRange;
    Rigidbody rb;
    TableScript tableScript;
    public bool flipped;
    public float flipMultiplier;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        realTableStartPos = realTable.transform.position;
        tableScript = realTable.GetComponent<TableScript>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (tableScript.triggerEnter && !flipped) {
            float magnitude = tableScript.throwVelocity.magnitude;
            rb.velocity = (tableScript.throwVelocity.normalized + new Vector3(Random.Range(-randomRange,randomRange), Random.Range(0, randomRange), Random.Range(0, randomRange))) * magnitude * flipMultiplier; flipped = true; }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Table") || other.gameObject.CompareTag("Ground"))
        {
            Instantiate(tableSound, transform.position, Quaternion.identity);
        }
    }
}
