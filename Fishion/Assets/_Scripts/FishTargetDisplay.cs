using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

//this class does not work
//there is a bug where some of the names of the fishes that are spawned contain an extra (Clone)
//since this code uses this name, it does not work properly

public class FishTargetDisplay : MonoBehaviour {

    private Sprite currentTarget; //the sprite of the current target
    public string currentTargetName; //the name of the current target
    public Image fishDisplay; //the image display for the sprite of a fish
    private List<string> fishSprites = new List<string>(); //list that contains the sprite of the fishes (based on which fish has spawned)

    public GameObject spawnerBehaviourScript; //the game object that holds the SpawnerBehaviour script
    private List<GameObject> neutralFish = new List<GameObject>(); //list of the spawned fishes

    // Use this for initialization
    //converts the names of the 
    //refrence to the list
    void Start ()
    {
        neutralFish = spawnerBehaviourScript.GetComponent<SpawnerBehaviour>().neutralFish;
        PrefabsToString(); 
        NextTarget();
	}
	
    //choses a random fish to be displayed
    //deletes that fish from the list so it can not be chosen again
    public void NextTarget()
    {
        int targetNumber;
        targetNumber = Random.Range(0, (fishSprites.Count));
        currentTargetName = fishSprites[targetNumber];
        fishDisplay.sprite = Resources.Load<Sprite>("Sprites/" + currentTargetName);
        fishSprites.RemoveAt(targetNumber);
    }

    //uses the name of the fish to add the name of a sprite in the array, so it can be shown on the display
    //does not work because some of the names of the fishes spawned contain irregular names, some of their names contain extra (Clone)   
    public void PrefabsToString()
    {
        for (int i = 0; i < neutralFish.Count; i++)
        {
            if(neutralFish[i].name == "BoxFish(Clone)")
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
