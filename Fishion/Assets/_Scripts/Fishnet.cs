using UnityEngine;
using System.Collections;

public class Fishnet : MonoBehaviour {

    public GameObject fishnet;
    public bool fishInNet = false;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    { 
        if(other.tag == "Fish" && fishInNet == false)
        {
            other.transform.parent = fishnet.transform;
            fishInNet = true;
        }
    }
    
    public void EmptyOutNet()
    {
        fishInNet = false;
    }
}
