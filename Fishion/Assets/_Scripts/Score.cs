using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public static int score;
    public Text scoreText;
    public Text healthText;
    public static int health;

    // Use this for initialization
    void Start () {
        
        score = 0;
        health = 3;
    }
	
	// Update is called once per frame
	void Update () {

        scoreText.text = "Fished: " + score;
        healthText.text = "Health: " + health;

    }
}
