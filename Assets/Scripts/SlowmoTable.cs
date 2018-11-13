using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmoTable : MonoBehaviour {
    public bool slowmo;
    public float slowMoScale;
    public float dur;
    public float velThreshold;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Arm") && rb.velocity.magnitude > velThreshold) {
            StartCoroutine("SlowMo");
        }
    }

    IEnumerator SlowMo() {
        Time.timeScale = slowMoScale;
        slowmo = true;
        yield return new WaitForSeconds(dur);
        Time.timeScale = 1F;
        slowmo = false;
    }
}
