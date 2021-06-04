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
        rigidbodyComponent.useGravity = true;
        Vector3 result = CalculateForce(force);
        rigidbodyComponent.AddForce(result);
        WindZone.windActive = true;
        GetComponent<BallRecycle>().StartRecycle();
    }

    private Vector3 CalculateForce(Vector3 force)
    {
        return new Vector3(
            force.x * xForceScale * power,
            force.y * yForceScale * power,
            force.y * zForceScale * power);
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
        if (other.tag.Contains(GoalTag))
        {
            GameManager.Instance.UpdateScore();
        }
    }

}
