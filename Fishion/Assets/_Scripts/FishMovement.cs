using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float DetectionRange;
    public float Speed;

    Vector3 Direction;
    int layerMask;
    RaycastHit Hit;

    void Start()
    {
        Direction = Random.onUnitSphere;
        layerMask = 1 << 8;
    }

	void Update ()
    {
        //transform.Translate((Direction * Speed) * Time.deltaTime);

        if (rb.velocity != new Vector3(0.0f, 0.0f, 0.0f))
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }

        if(Physics.Raycast(transform.position, Vector3.left, out Hit, DetectionRange, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * DetectionRange, Color.blue);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * DetectionRange, Color.yellow);
        }

        OnImpact();
	}

    void OnImpact()
    {
        
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.75f, 0.0f, 0.0f)) * DetectionRange, Color.green);

    }
}
