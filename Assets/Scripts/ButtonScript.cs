using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    public GameObject buttonSound;
    public GameObject buttonObject;
    public Animator anim;
    private bool active;

    void Start () {
       // anim.GetComponent<Animator>();
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
        anim.SetTrigger("ButtonPress");
        buttonObject.SetActive(true);
        active = true;
    }
}
