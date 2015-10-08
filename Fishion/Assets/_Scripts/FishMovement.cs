using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour
{
    public float DetectionRange;

	void Update ()
    {
        int layerMask = 1 << 8;
        RaycastHit Hit;

        if(Physics.Raycast(transform.position, Vector3.left, out Hit, DetectionRange, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * DetectionRange, Color.blue);
            Debug.Log(Hit.collider.tag);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * DetectionRange, Color.yellow);
        }
	}
}
