﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
    {
    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody rBody;
    public float moveSpeed = 2f;

    public BoxCollider collider;
    public SphereCollider bhCollider;

    public GameObject glassCard;
    public GameObject normalCard;

    void Start()
        {
        rBody = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<BoxCollider>();
        }


    // Update is called once per frame
    void Update()
        {

        }

    private void OnTriggerEnter(Collider other)
        {
        if (other = bhCollider)
            {
            BlackHole();
            }
        }

    public void OnMouseDown()
        {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        rBody.useGravity = false;
        }

    public void OnMouseDrag()
        {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;

        //transform.position = cursorPos;

        
        //rb.velocity = Vector3.Lerp(rb.velocity, cursorPos - transform.position, drag * Time.deltaTime);
        rBody.velocity = (cursorPos - transform.position) * moveSpeed;
        }

    public void OnMouseUp()
        {
        rBody.useGravity = true;
        }

    public void BlackHole()
        {
        glassCard.SetActive(true);
        glassCard.transform.SetParent(null);

        normalCard.SetActive(false);
        gameObject.SetActive(false);
        }
    }
