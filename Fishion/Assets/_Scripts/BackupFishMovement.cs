using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackupFishMovement : MonoBehaviour
{
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
        fish = GetComponent<CharacterController>();
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
        Vector3 target = waypoints[currentWaypoint].position;
        Vector3 moveDirection = target - transform.position;

        if (moveDirection.magnitude < 0.5)
        {
            if (currentTime <= 0)
            {
                currentTime = Time.time;
            }

            if ((Time.time - currentTime) >= pauseDuration)
            {
                currentWaypoint++;
                currentTime = 0.0f;
            }
        }
        else
        {
            Quaternion rotation = Quaternion.LookRotation(target - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
            fish.Move((moveDirection.normalized * patrolSpeed) * Time.deltaTime);
        }
    }
}
