using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public Transform mouseTarget;
    public GameObject tableCollision;
    public float offset;
    Camera cam;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mouseTarget.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z + offset));
        transform.LookAt(mouseTarget);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Table")) {
            Instantiate(tableCollision, transform.position, Quaternion.identity);
        }
    }
}
