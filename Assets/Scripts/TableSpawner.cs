using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSpawner : MonoBehaviour
{
    public GameObject table;
    public float spawnTime;
    public bool hasTable;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Table"))
        {

            if (!hasTable)
                StartCoroutine("SpawnTable");
            hasTable = true;
        }
    }

    IEnumerator SpawnTable()
    {

        yield return new WaitForSeconds(spawnTime);
        hasTable = false;
        Instantiate(table, transform.position, Quaternion.identity);
    }
}
