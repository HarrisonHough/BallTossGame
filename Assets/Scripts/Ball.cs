﻿using System;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Ball Class 
*/

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour 
{

    [SerializeField]
    private float xForceScale = 1f;
    [SerializeField]
    private float yForceScale = 0.85f;
    [SerializeField]
    private float zForceScale = 0.65f;
    [SerializeField]
    private float power = 20f;

    [SerializeField] private int pointValue = 1;

    private Rigidbody rigidbodyComponent;
    public Rigidbody RigidbodyComponent => rigidbodyComponent;
    private ConstantForce constantForce;
    private const string GoalTag = "Goal";
    private bool hasScored = false;
    
    Vector3 startPosition;
    Quaternion startRotation;
    
	void Awake () 
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        rigidbodyComponent.useGravity = true;
        Vector3 direction = new Vector3(0,1*yForceScale,1 * zForceScale);
        rigidbodyComponent.AddForce(direction);
    }

    private void FixedUpdate()
    {
        if (Wind.windActive && rigidbodyComponent.useGravity)
        {
            AddForce(Wind.windForce);
        }
    }

    public void Shoot(Vector3 force)
    {
        if (force.sqrMagnitude < 1)
        {
            return;
        }
        hasScored = false;
        rigidbodyComponent.useGravity = true;
        AddForce(CalculateForce(force));
        Wind.windActive = true;
        var ballRecycle = GetComponent<BallRecycle>();
        if (ballRecycle)
        {
            ballRecycle.StartRecycle();
        }
    }

    public void AddForce(Vector3 force)
    {
        rigidbodyComponent.AddForce(force);
    }

    private Vector3 CalculateForce(Vector3 force)
    {
        var finalForce = new Vector3(
            force.x * xForceScale * power,
            force.y * yForceScale * power,
            force.y * zForceScale * power);
        return finalForce;
    }

    public void DisableGravity()
    {
        Wind.windActive = false;
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
            GameManager.Instance.UpdateScore(pointValue);
        }
    }

    public void ResetPosition()
    {
        DisableGravity();
        rigidbodyComponent.angularVelocity = Vector3.zero;
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
