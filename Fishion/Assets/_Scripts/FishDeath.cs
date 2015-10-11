using UnityEngine;
using System.Collections;

public class FishDeath : MonoBehaviour {

    public int scoreValue = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Releaser")
        {
            Destroy(gameObject);
            Score.score += scoreValue;
        }
    }
}
