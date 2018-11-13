using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTableScript : MonoBehaviour {
    public GameObject tableSound;
    public GameObject tableRain;
    public GameObject winSound;
    public bool playedSound;
    public float waitTime;
    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ground") && !playedSound) {
            playedSound = true;
            Instantiate(tableSound, transform.position, Quaternion.identity);
            tableRain.SetActive(true);
            //    ManagerScript.sceneSwitch = true;
            StartCoroutine("PlaySound");
        }
    }
    IEnumerator PlaySound()
    { yield return new WaitForSeconds(waitTime);
        Instantiate(winSound, transform.position, Quaternion.identity);
    }
}
