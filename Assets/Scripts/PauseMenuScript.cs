using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

    private bool isPaused = false;
    public GameObject pauseScreen;
    private int sceneIndex;

	// Use this for initialization
	void Start () {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("escape"))
        {
            isPaused = !isPaused;

            if (isPaused == true)
            {
                Paused();
            }
            else if (isPaused == false)
            {
                Resume();
            }
        }
	}

    public void Paused()
    {
        Time.timeScale = 0f;

        pauseScreen.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1f;

        pauseScreen.SetActive(false);
    }

    public void Restart(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void NextScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
