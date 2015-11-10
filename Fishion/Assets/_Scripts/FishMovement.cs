using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour
{
    //this script deals with the movement of the fish by detecting the obstacles by raycasting.
        
    public float detectionRange;
    public float speed;

    Vector3 direction;

        //ofset from the middle of the fish for both of the rays looking forwards
        //by doing so the fish have eyes so to speak were they can see depth on the x/z axis
    Vector3 leftOfset;
    Vector3 rightOfset;

    void Start()
    {
            //when spawed the fish needs a random direction to start with
        direction = Random.onUnitSphere;

        //Debug.Log(direction);
    }

	void Update ()
    {
            //rotating the fish to face the direciont it's swimming at
        transform.rotation = Quaternion.LookRotation(direction);
            //set the swimming direction to were you want it to go
        transform.Translate((direction * speed) * Time.deltaTime, Space.World);
			
            //set the distance from the middle
        leftOfset = transform.position + new Vector3(-0.1f, 0.0f, -0.4f);
        rightOfset = transform.position + new Vector3(0.1f, 0.0f, 0.4f);

            //Debug purposes, seeing wether the look rotation is working correctly.
        //Debug.DrawRay(transform.position, transform.TransformDirection(direction) * detectionRange, Color.cyan);

        CheckImpactWalls();
        CheckImpactFloorTop();
    }

    void CheckImpactWalls()
    {
        //when any of the raycasts detects an object the fish will have to turn in the opposite direction to avoid it.
        // the following two functions will make this happen.

        RaycastHit Hit;

        if (Physics.Raycast(leftOfset, Vector3.forward, out Hit, detectionRange))
        {	    //when activated turn right
			Quaternion myRotation = Quaternion.Euler(0.0f, 2.0f, 0.0f);
            direction = (myRotation * direction).normalized;
        }
        else if (Physics.Raycast(rightOfset, Vector3.forward, out Hit, detectionRange))
        {	    //wen activated turn left
			Quaternion myRotation = Quaternion.Euler(0.0f, -2.0f, 0.0f);
            direction = (myRotation * direction).normalized;
        }

            //showing the position of the rays in the scene window, 1st Left, 2nd Right
        Debug.DrawRay(leftOfset, transform.TransformDirection(Vector3.forward) * detectionRange, Color.red);
        Debug.DrawRay(rightOfset, transform.TransformDirection(Vector3.forward) * detectionRange, Color.red);
    }
    
    void CheckImpactFloorTop()
    {
        RaycastHit Hit;

        if (Physics.Raycast(transform.position, new Vector3(0.0f, 0.7f, 0.7f), out Hit, detectionRange))
        {	    //when activated tilt downwards
			Quaternion myRotation = Quaternion.Euler(-5.0f, 0.0f, 0.0f);
            direction = (myRotation * direction).normalized;
        }
        else if (Physics.Raycast(transform.position, new Vector3(0.0f, -0.7f, 0.7f), out Hit, detectionRange))
        {	    //when activated tilt upwards
			Quaternion myRotation = Quaternion.Euler(5.0f, 0.0f, 0.0f);
            direction = (myRotation * direction).normalized;
        }

            //showing the position of the rays in the scene window, 1st Top, 2nd Bottom
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.0f, 0.7f, 0.7f)) * detectionRange, Color.green);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.0f, -0.7f, 0.7f)) * detectionRange, Color.green);
    }
}