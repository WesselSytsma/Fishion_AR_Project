using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Score : MonoBehaviour {

    public static int score;
    public Text scoreText;
    public Image healthIcon1;
    public Image healthIcon2;
    public Image healthIcon3;
    private int currentHealth = 3;
    public GameObject gameOverScreen;
    public Text scoreTextPopUp;
    private Color color;

    // Use this for initialization
    void Start ()
    {        
        score = 0;
        color = scoreTextPopUp.color;
        color.a = 0.0f;
        gameOverScreen.SetActive(false);
        scoreText.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void HealthDown()
    {
        if (currentHealth == 3)
        {
            healthIcon1.enabled = false;
            currentHealth--;
        }
        else if (currentHealth == 2)
        {
            healthIcon2.enabled = false;
            currentHealth--;
        }
        else if (currentHealth == 1)
        {
            healthIcon3.enabled = false;
            currentHealth--;
            scoreText.text = score.ToString();
            gameOverScreen.SetActive(true);
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -1; f -= 0.1f)
        {
            color.a = f;
            scoreTextPopUp.color = color;
            yield return new WaitForSeconds(0.07f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float f = 0f; f <= 1.1; f += 0.1f)
        {
            color.a = f;
            scoreTextPopUp.color = color;
            yield return new WaitForSeconds(0.07f);
        }
    }

    IEnumerator ScoreFading()
    {
        StartCoroutine("FadeIn");
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("FadeOut");
    }

    public void StartScoreFading()
    {
        StartCoroutine("ScoreFading");
    }
}
