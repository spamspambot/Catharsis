using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTable : MonoBehaviour {

    public SphereCollider bhCollider;

    public GameObject glassTable;
    public GameObject normalTable;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
        {
        if (other == bhCollider)
            {
            BlackHole();
            Debug.Log("Black Hole");
            }
        }

    public void BlackHole()
        {
        glassTable.SetActive(true);
        glassTable.transform.SetParent(null);

        normalTable.SetActive(false);
        gameObject.SetActive(false);
        }
    }
