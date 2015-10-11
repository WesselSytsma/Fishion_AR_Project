using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public Canvas levelSelect;
    public Canvas quitMenu;
    public Button playButton;
    public Button exitButton;
    
	// Use this for initialization
	void Start () {

        levelSelect = levelSelect.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        levelSelect.enabled = false;
        quitMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        levelSelect.enabled = false;
        playButton.enabled = false;
        exitButton.enabled = false;
    }

    public void PlayPress()
    {
        quitMenu.enabled = false;
        levelSelect.enabled = true;
        playButton.enabled = false;
        exitButton.enabled = false;
    }

    public void BackAndNoPress()
    {
        quitMenu.enabled = false;
        levelSelect.enabled = false;
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
