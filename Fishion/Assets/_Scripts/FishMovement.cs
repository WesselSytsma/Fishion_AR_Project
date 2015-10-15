using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour
{
    public float detectionRange;
    public float speed;

    int layerMask;
    Vector3 direction;

    Vector3 leftOfset;
    Vector3 rightOfset;

    void Start()
    {
        direction = Random.onUnitSphere;
        layerMask = 1 << 8;

        Debug.Log(direction);
    }

	void Update ()
    {
        transform.Translate((direction * speed) * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(direction);
			
        leftOfset = transform.position + new Vector3(-0.1f, 0.0f, -0.2f);
        rightOfset = transform.position + new Vector3(0.1f, 0.0f, 0.2f);

        CheckImpactWalls();
        CheckImpactFloorTop();

		Debug.Log(direction);
    }

    void CheckImpactWalls()
    {
        RaycastHit Hit;

        if (Physics.Raycast(leftOfset, Vector3.forward, out Hit, detectionRange, layerMask))
        {	//needs to turn right
			Quaternion myRotation = Quaternion.Euler(0.0f, 10.0f, 0.0f);
			direction = myRotation * direction;
        }
        else if (Physics.Raycast(rightOfset, Vector3.forward, out Hit, detectionRange, layerMask))
        {	//needs to turn left
			Quaternion myRotation = Quaternion.Euler(0.0f, -10.0f, 0.0f);
			direction = myRotation * direction;
        }

        //showing the position of the rays in the scene window, 1st Left, 2nd Right
        Debug.DrawRay(leftOfset, transform.TransformDirection(Vector3.forward) * detectionRange, Color.red);
        Debug.DrawRay(rightOfset, transform.TransformDirection(Vector3.forward) * detectionRange, Color.red);
    }
    
    void CheckImpactFloorTop()
    {
        RaycastHit Hit;

        if (Physics.Raycast(transform.position, new Vector3(0.0f, 0.7f, 0.7f), out Hit, detectionRange, layerMask))
        {	//needs to tilt downwards
            //int RandomDegreesDown = Random.Range(-40, -15);
			Quaternion myRotation = Quaternion.Euler(-30.0f, 0.0f, 0.0f);
			direction = myRotation * direction;
        }
        else if (Physics.Raycast(transform.position, new Vector3(0.0f, -0.7f, 0.7f), out Hit, detectionRange, layerMask))
        {	//nees to tilt upwards
            //int RandomDegreesUp = Random.Range(15, 40);
			Quaternion myRotation = Quaternion.Euler(30.0f, 0.0f, 0.0f);
			direction = myRotation * direction;
        }

        //showing the position of the rays in the scene window, 1st Top, 2nd Bottom
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.0f, 0.7f, 0.7f)) * detectionRange, Color.green);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.0f, -0.7f, 0.7f)) * detectionRange, Color.green);
    }
}
