using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingCollider : MonoBehaviour {

    public SphereCollider collider;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 cursorPos;
    private float radius = 0.1f;
    private float timeScale = 1f;

    private bool expanding = false;

	void Start () {
        collider = gameObject.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            
            expanding = !expanding;

            timeScale = 0.6f;
        }

        if (expanding)
        {
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            cursorPos = Camera.main.ScreenToWorldPoint(cursorScreenPoint);
            Expand(cursorPos);
        }

        Time.timeScale = timeScale;
	}

    public void Expand(Vector3 pos)
    {
        
        if (timeScale > 0.1f)
        {
            timeScale -= 0.8f * Time.deltaTime;
        }

        if (radius < 2)
        {
            radius += 0.7f * Time.deltaTime;
        }

        transform.position = pos;
        collider.radius = radius;
        
        if (radius >= 2)
        {
            expanding = !expanding;
            timeScale = 1f;
        }
    }
}
