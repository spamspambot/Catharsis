using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTableScript : MonoBehaviour {
    public GameObject tableSound;
    public GameObject tableRain;
    public bool playedSound;
    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ground") && !playedSound) {
            playedSound = true;
            Instantiate(tableSound, transform.position, Quaternion.identity);
            tableRain.SetActive(true);
        //    ManagerScript.sceneSwitch = true;
        }
    }

}
