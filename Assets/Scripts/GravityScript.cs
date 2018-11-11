using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
    {

    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 cursorPos;

    private Rigidbody rb;

    public float suckForce = -1f;
    public float suckRadius = 10f;

    // Use this for initialization
    void Start()
        {
        rb = gameObject.GetComponent<Rigidbody>();
        }

    // Update is called once per frame
    void Update()
        {

        }

    public void OnMouseDown()
        {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        cursorPos = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;

        rb.useGravity = false;
        rb.AddExplosionForce(suckForce, cursorPos, suckRadius);
        }

    public void OnMouseUp()
        {
        rb.useGravity = true;

        rb.AddExplosionForce(suckForce * -1f, cursorPos, suckRadius, 1f, ForceMode.Impulse);
        }
    }
