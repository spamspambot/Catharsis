﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
    {
    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody rb;

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
        }

    public void OnMouseDrag()
        {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;

        transform.position = cursorPos;
        
        }
    }