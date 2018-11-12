using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRain : MonoBehaviour
{
    public GameObject table;
    public int tableNumber;
    public float tableSpacing;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < tableNumber; i++)
        {
            for (int j = 0; j < tableNumber; j++)
            {
                Instantiate(table, transform.position + new Vector3(tableSpacing * i, 0, tableSpacing * j), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
