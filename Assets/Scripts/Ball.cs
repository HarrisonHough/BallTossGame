using System.Collections;
using System.Collections.Generic;
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

    public float power = 50f;
    private Rigidbody rigidbodyComponent;
    private ConstantForce constantForce;
    private const string GoalTag = "Goal";
    
	void Start () {

        rigidbodyComponent = GetComponent<Rigidbody>();
        constantForce = GetComponent<ConstantForce>();
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
        //Wind.windActive = true;
        constantForce.enabled = true;
        //TODO refactor
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
        //Wind.windActive = false;
        rigidbodyComponent.useGravity = false;
        rigidbodyComponent.velocity = Vector3.zero;
        constantForce.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Wind.windActive = false;
        constantForce.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(GoalTag))
        {
            GameManager.Instance.UpdateScore();
        }
    }

}
