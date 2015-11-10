using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Score : MonoBehaviour {

    public static int score; //holds the current score
    public Text scoreText; //shows the payer's score when the game is over
    public Image healthIcon1; //first image of the health icon
    public Image healthIcon2; //second image of the health icon
    public Image healthIcon3; //third image of the health icon
    private int currentHealth = 3; //current amount of health
    public GameObject gameOverScreen; //game over panel
    public Text scoreTextPopUp; //score pop up
    private Color color; //color variable

    // Use this for initialization
    void Start ()
    {
        //sets the score to 0 and adds to the textfield
        score = 0;
        scoreText.text = score.ToString();

        //sets the color to have the scoreTextPopUp color and sets alpha to 0
        color = scoreTextPopUp.color;
        color.a = 0.0f;

        //sets panel to be not visable
        gameOverScreen.SetActive(false);
    }

    //decreases the players health
    //enables the game over panel when 0 health is left over
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

    //fades the aplpha channel of the score
    public IEnumerator ScoreFading()
    {
        for (float f = 0f; f <= 1.1; f += 0.1f)
        {
            color.a = f;
            scoreTextPopUp.color = color;
            yield return new WaitForSeconds(0.07f);
        }
        yield return new WaitForSeconds(1.5f);
        for (float f = 1f; f >= -1; f -= 0.1f)
        {
            color.a = f;
            scoreTextPopUp.color = color;
            yield return new WaitForSeconds(0.07f);
        }
    }
}
