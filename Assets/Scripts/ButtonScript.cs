using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    public GameObject buttonSound;
    public GameObject buttonObject;
    bool active;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arm") && !active) {
            ButtonPressed();
        }
    }

    void ButtonPressed() {
        Instantiate(buttonSound, transform.position, Quaternion.identity);
        buttonObject.SetActive(true);
        active = true;
    }
}
