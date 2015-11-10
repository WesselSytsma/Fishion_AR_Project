using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackupFishMovement : MonoBehaviour
{
    //this script deals with the movement of the fish by giving them a set of waypoints to follow given by the spawnpoint
    //unfortunately the first concept of movement was bugged so I resulted to this concept

    public Transform parentObject;
    public CharacterController fish;
    public Transform[] waypoints;
    public float patrolSpeed;
    public bool looping;
    public float dampingLook;
    public float pauseDuration;

    float currentTime;
    int currentWaypoint;                
	
	void Start ()
    {
            //making sure the character controller is linked correctly
        fish = GetComponent<CharacterController>();

            //setting the fish as a child of the tracker image
        this.transform.parent = parentObject;
	}
	
	
	void Update ()
    {
        if (currentWaypoint < waypoints.Length)
        {
            Patrol();
        }
        else
        {
            if (looping)
            {
                currentWaypoint = 0;
            }
        }
	}

    void Patrol()
    { 
        //I made use of forums and tutorials for this section, so I mihgt not be entirely sure why some parts were needed.

            //the next waypoint to move towards
        Vector3 target = waypoints[currentWaypoint].position;
            //the diredtion needed to get there
        Vector3 moveDirection = target - transform.position;

            //I am not sure why this part is needed, but I presume it is to start rotating just before it reaches the next waypoint
        if (moveDirection.magnitude < 0.5)
        {
                //timer
            if (currentTime <= 0)
            {
                currentTime = Time.time;
            }

                //when waited longer than the given duration it continuous to the next waypoint and resets the timer
            if ((Time.time - currentTime) >= pauseDuration)
            {
                currentWaypoint++;
                currentTime = 0.0f;
            }
        }
        else
        {
                //otherwise set were to rotate towards
            Quaternion rotation = Quaternion.LookRotation(target - transform.position);
                
                //and slowly rotate towards that point
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
                //at last move the fish to it's new position
            fish.Move((moveDirection.normalized * patrolSpeed) * Time.deltaTime);
        }
    }
}
