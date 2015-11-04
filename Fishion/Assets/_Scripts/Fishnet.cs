using UnityEngine;
using System.Collections;

public class Fishnet : MonoBehaviour {

    public GameObject fishnet;
    public bool fishInNet = false;
    private string fishedName;
    private string currentFish;
    public GameObject canvas;
    public int scoreValue = 10;
    private GameObject catchedFish;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish" && fishInNet == false)
        {
            other.transform.parent = fishnet.transform;
            fishedName = other.name;
            fishInNet = true;
            catchedFish = other.gameObject;
        }
        else if (other.name == "Releaser")
        {
            changeNames();
            if (currentFish == canvas.GetComponent<FishTargetDisplay>().currentTargetName && fishInNet == true)
            {
                Score.score += scoreValue;
                canvas.GetComponent<Score>().StartScoreFading();
                canvas.GetComponent<FishTargetDisplay>().NextTarget();
            }
            else
            {
                canvas.GetComponent<Score>().HealthDown();
            }
            Destroy(catchedFish);
            fishInNet = false;
        }
        else if(other.tag == "Enemy")
        {
            canvas.GetComponent<Score>().HealthDown();
        }
    }
    
    /**public string getFishName()
    {
        return fishedName;
    }*/

    void changeNames()
    { 
        if (fishedName == "Fish")
        {
            currentFish = "oval";
        }
        else if (fishedName == "sad")
        {
            currentFish = "rectancle";
        }
        else if (fishedName == "asd")
        {
            currentFish = "round";
        }
        else if (fishedName == "anglefish")
        {
            currentFish = "triangle";
        }
    }
}
