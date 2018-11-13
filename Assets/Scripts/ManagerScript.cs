using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public static int escalationLevel = 0;
    public static bool sceneSwitch;
    public bool switchingScene;
    public float sceneSwitchTime;
    public List<GameObject> scenes;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        sceneSwitch = false;
        if (escalationLevel < scenes.Count)
        {
            scenes[escalationLevel].SetActive(true);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneSwitch && !switchingScene)
        {
            switchingScene = true;
            StartCoroutine("SceneSwitchDelay");
        }
        if (Input.GetKeyDown("r")) ReloadScene(1);
    }

    IEnumerator SceneSwitchDelay() {
        yield return new WaitForSeconds(sceneSwitchTime);
        ReloadScene(1);
    }

    public void ReloadScene(int i)
    {
        SceneManager.LoadScene(1);
        if (escalationLevel < scenes.Count)
            escalationLevel++;
        else escalationLevel = 0;
    }
}
