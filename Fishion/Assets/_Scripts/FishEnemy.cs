using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FishEnemy : MonoBehaviour {

    private Score score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            score.HealthDown();
        }
    }
}
