using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject levelSelect; //the level Select panel
    public GameObject quitMenu; //the quit menu panel
    public Button playButton; //the play button
    public Button exitButton; //the exit button
    
	// Use this for initialization
    //Sets the other panels to be not visable
	void Start ()
    {
        levelSelect.SetActive(false);
        quitMenu.SetActive(false);
	}

    //enables the quit menu panel when exit is pressed
    //disables the play and exit button
    public void ExitPress()
    {
        quitMenu.SetActive(true);
        levelSelect.SetActive(false);
        playButton.enabled = false;
        exitButton.enabled = false;
    }

    //enables the level select panel when play is pressed
    //disables the play and exit button
    public void PlayPress()
    {
        quitMenu.SetActive(false);
        levelSelect.SetActive(true);
        playButton.enabled = false;
        exitButton.enabled = false;
    }

    //makes the other panels not visable
    //enables the play and exit button
    public void BackAndNoPress()
    {
        quitMenu.SetActive(false);
        levelSelect.SetActive(false);
        playButton.enabled = true;
        exitButton.enabled = true;
    }

    //loads the first game scene
    public void StartEasy()
    {
        Application.LoadLevel(1);
    }

    //loads the second game scene
    //for future implementations 
    public void StartNormal()
    {
        Application.LoadLevel(2);
    }

    //loads the thrid game scene
    //for future implementations 
    public void StartHard()
    {
        Application.LoadLevel(3);
    }

    //stops the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
