using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

    public GameObject pauseMenu; //the pause menu panel

	// Use this for initialization
    //disables the panel
	void Start ()
    {
        pauseMenu.SetActive(false);
	}

    //stops the time when the pause button is pressed
    //enables and disables the pause menu panel
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

    //resumes the game
    //disables the pause menu panel
    public void ResumePress()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    //reloads(resets) the current level
    public void RestartPress()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //brings the player back to the main menu scene
    public void QuitPress()
    {
        Application.LoadLevel(0);
    }
}
