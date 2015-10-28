using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FishTargetDisplay : MonoBehaviour {

    public Sprite[] fishTargets;
    private Sprite currentTarget;
    public Image fishDisplay;


    // Use this for initialization
    void Start () {
        RandomizeTargets();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void RandomizeTargets()
    {
        int targetNumber;
        string targetName;
        targetNumber = Random.Range(0, (fishTargets.Length));
        targetName = fishTargets[targetNumber].name;
        fishDisplay.sprite = Resources.Load<Sprite>("Sprites/" + targetName);
    }
}
