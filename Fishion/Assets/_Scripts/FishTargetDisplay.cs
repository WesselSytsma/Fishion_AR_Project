using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class FishTargetDisplay : MonoBehaviour {

    private Sprite currentTarget;
    public Image fishDisplay;
    private List<string> fishSprites = new List<string>();
    public string currentTargetName;

    public GameObject spawnerBehaviourScript;
    private List<GameObject> neutralFish = new List<GameObject>();

    // Use this for initialization
    void Start () {
        PrefabsToString();
        NextTarget();
        neutralFish = spawnerBehaviourScript.GetComponent<SpawnerBehaviour>().neutralFish;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextTarget()
    {
        int targetNumber;
        targetNumber = Random.Range(0, (fishSprites.Count));
        currentTargetName = fishSprites[targetNumber];
        fishDisplay.sprite = Resources.Load<Sprite>("Sprites/" + currentTargetName);
        fishSprites.RemoveAt(targetNumber);
    }
    
    public void PrefabsToString()
    {
        for (int i = 0; i < neutralFish.Count; i++)
        {
            if (neutralFish[i].name == "TakenOutInModeling")
            {
                fishSprites.Add("oval");
            }
            else if(neutralFish[i].name == "BoxFish(Clone)")
            {
                fishSprites.Add("rectancle");
            }
            else if(neutralFish[i].name == "SilverhatchetFish(Clone)")
            {
                fishSprites.Add("round");
            }
            else if(neutralFish[i].name == "Anglefish(Clone)")
            {
                fishSprites.Add("triangle");
            }
        }
    }
}
