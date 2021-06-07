using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Ball Class 
*/

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

    [SerializeField]
    private float xForceScale = 1f;
    [SerializeField]
    private float yForceScale = 1f;
    [SerializeField]
    private float zForceScale = 1f;
    [SerializeField]
    private float power = 50f;

    private Rigidbody rigidbodyComponent;
    public Rigidbody RigidbodyComponent => rigidbodyComponent;
    private ConstantForce constantForce;
    private const string GoalTag = "Goal";
    private bool hasScored = false;
    
	void Start () 
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        rigidbodyComponent.useGravity = true;
        Vector3 direction = new Vector3(0,1*yForceScale,1 * zForceScale);
        rigidbodyComponent.AddForce(direction);
    }

    public void Shoot(Vector3 force)
    {
        hasScored = false;
        rigidbodyComponent.useGravity = true;
        Vector3 result = CalculateForce(force);
        rigidbodyComponent.AddForce(result);
        WindZone.windActive = true;
        GetComponent<BallRecycle>().StartRecycle();
    }

    private void Calculate()
    {
        var rigid = GetComponent<Rigidbody>();
        var test = Vector3.one;
        Vector3 p = test;
 
        float gravity = Physics.gravity.magnitude;
        // Selected angle in radians
        float angle = 45 * Mathf.Deg2Rad;
 
        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(p.x, 0, p.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);
 
        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distance along the y axis between objects
        float yOffset = transform.position.y - p.y;
 
        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
 
        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));
 
        // Rotate our velocity to match the direction between the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
 
        // Fire!
        //rigid.velocity = finalVelocity;
 
        // Alternative way:
        rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);
    }


    private Vector3 CalculateForce(Vector3 force)
    {
        Debug.Log($"force vector {force}");
        return new Vector3(
            force.x * xForceScale * power,
            force.y * yForceScale * 0.75f * power,
            force.y * zForceScale * 0.75f * power);
    }

    public void DisableGravity()
    {
        WindZone.windActive = false;
        rigidbodyComponent.useGravity = false;
        rigidbodyComponent.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //WindZone.windActive = false;
        //constantForce.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(GoalTag) && !hasScored)
        {
            hasScored = true;
            GameManager.Instance.UpdateScore();
        }
    }

}
