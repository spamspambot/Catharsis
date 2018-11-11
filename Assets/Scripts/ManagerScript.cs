using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public static int escalationLevel = 0;
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;
    public GameObject scene6;
    public List<GameObject> scenes;
    // Use this for initialization
    void Start()
    {
        switch (escalationLevel)
        {
            case 0:
                scene1.SetActive(true);
                break;
            case 1:
                scene2.SetActive(true);
                break;
            case 2:
                scene3.SetActive(true);
                break;
            case 3:
                scene4.SetActive(true);
                break;
            case 4:
                scene5.SetActive(true);
                break;
            case 5:
                scene6.SetActive(true);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReloadScene(int i)
    {
        SceneManager.LoadScene(1);
        escalationLevel++;
    }
}
