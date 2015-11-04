using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

    public GameObject pauseMenu;

	// Use this for initialization
	void Start ()
    {
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PausePress()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);       
        }

        else if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
    }

    public void ResumePress()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void RestartPress()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void QuitPress()
    {
        Application.LoadLevel(0);
    }
}
