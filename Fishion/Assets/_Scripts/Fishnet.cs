using UnityEngine;
using System.Collections;

public class Fishnet : MonoBehaviour {

    public GameObject fishnet; //the fish net
    public bool fishInNet = false; //bool if there is a fish in the net
    private string fishedName; //name of the current fish in the net
    private GameObject catchedFish; //the game object of the current fish in the net
    public GameObject canvas; //the canvas of the scene
    public int scoreValue = 10; //amount of score each fish gives

    //when the fishnet hits a collider with a trigger
    void OnTriggerEnter(Collider other)
    {
        //if the trigger has the tag Fish and there is no fish in the net:
        //it sets the current fish's name
        //it it adds the fish as a child to the net
        if (other.tag == "Fish" && fishInNet == false)
        {
            other.transform.parent = fishnet.transform;
            fishedName = other.name;
            fishInNet = true;
            catchedFish = other.gameObject;
        }

        //if it hits the releaser with a fish it gives the player points and empties out the fishnet
        //sections have been commented out
        //reasons for this is because we did not get it working in time (see FishTargetDisplay for further explanations)
        else if (other.name == "Releaser")
        {
            //changeNames();
            if (/*currentFish == canvas.GetComponent<FishTargetDisplay>().currentTargetName &&*/ fishInNet == true)
            {
                Score.score += scoreValue;
                canvas.GetComponent<Score>().ScoreFading();
                //canvas.GetComponent<FishTargetDisplay>().NextTarget();
            }
            /*else
            {
                canvas.GetComponent<Score>().HealthDown();
            }*/
            Destroy(catchedFish);
            fishInNet = false;
        }

        //if it hits an enemy fish(dangerous fish) the player losses health
        else if(other.tag == "Enemy")
        {
            canvas.GetComponent<Score>().HealthDown();
        }
    }

    //changes the names of the fished fish so it can compared to the target fish from FishTargetDisplay
    //does not work because some of the names of the fishes spawned contain irregular names, some of their names contain extra (Clone)
    void changeNames()
    { 
        if (fishedName == "BoxFish(Clone)")
        {
            fishedName = "rectancle";
        }
        else if (fishedName == "SilverhatchetFish(Clone)")
        {
            fishedName = "round";
        }
        else if (fishedName == "Anglefish(Clone)")
        {
            fishedName = "triangle";
        }
    }
}
