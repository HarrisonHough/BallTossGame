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
    private float yForceScale = 0.85f;
    [SerializeField]
    private float zForceScale = 0.65f;
    [SerializeField]
    private float power = 20f;

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
        if (force.sqrMagnitude < 1)
        {
            return;
        }
        hasScored = false;
        rigidbodyComponent.useGravity = true;
        Vector3 result = CalculateForce(force);
        rigidbodyComponent.AddForce(result);
        WindZone.windActive = true;
        GetComponent<BallRecycle>().StartRecycle();
    }


    private Vector3 CalculateForce(Vector3 force)
    {
        var maxY = 5;
        //force.y = Mathf.Clamp(force.y, 0, maxY);
        var maxX = 1.5f;
        //force.x = Mathf.Clamp(force.x, 0, maxX);
        Debug.Log($"force vector {force}");
        var finalForce = new Vector3(
            force.x * xForceScale * power,
            force.y * yForceScale * power,
            force.y * zForceScale * power);
        Debug.Log($"finalForce vector {finalForce}");

        return finalForce;
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
