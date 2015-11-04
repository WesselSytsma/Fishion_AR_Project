using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class FishTargetDisplay : MonoBehaviour {

    private Sprite currentTarget;
    public Image fishDisplay;
    private List<string> fishSprites = new List<string>();
    public string currentTargetName;

    public GameObject[] fishprefabs;

    // Use this for initialization
    void Start () {
        PrefabsToString();
        NextTarget();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentTargetName);
	
	}

    public void NextTarget()
    {
        int targetNumber;
        targetNumber = Random.Range(0, (fishSprites.Count));
        currentTargetName = fishSprites[targetNumber];
        fishDisplay.sprite = Resources.Load<Sprite>("Sprites/" + currentTargetName);
        fishSprites.RemoveAt(targetNumber);
    }
    
    void PrefabsToString()
    {
        for (int i = 0; i < fishprefabs.Length; i++)
        {
            if (fishprefabs[i].name == "Fish")
            {
                fishSprites.Add("oval");
            }
            else if(fishprefabs[i].name == "OtherFish")
            {
                fishSprites.Add("rectancle");
            }
            else if(fishprefabs[i].name == "asd")
            {
                fishSprites.Add("round");
            }
            else if(fishprefabs[i].name == "anglefish")
            {
                fishSprites.Add("triangle");
            }
        }
    }
}
