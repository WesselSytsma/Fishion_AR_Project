using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject levelSelect;
    public GameObject quitMenu;
    public Button playButton;
    public Button exitButton;
    
	// Use this for initialization
	void Start () {

        levelSelect.SetActive(false);
        quitMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ExitPress()
    {
        quitMenu.SetActive(true);
        levelSelect.SetActive(false);
        playButton.enabled = false;
        exitButton.enabled = false;
    }

    public void PlayPress()
    {
        quitMenu.SetActive(false);
        levelSelect.SetActive(true);
        playButton.enabled = false;
        exitButton.enabled = false;
    }

    public void BackAndNoPress()
    {
        quitMenu.SetActive(false);
        levelSelect.SetActive(false);
        playButton.enabled = true;
        exitButton.enabled = true;
    }

    public void StartEasy()
    {
        Application.LoadLevel(1);
    }

    public void StartNormal()
    {
        Application.LoadLevel(2);
    }

    public void StartHard()
    {
        Application.LoadLevel(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
