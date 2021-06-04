using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Wind Class 
*/

public class Wind : MonoBehaviour 
{
    [SerializeField]
    private float minSpeed = 0f;
    [SerializeField]
    private float maxSpeed = 100f;

    [SerializeField]
    private Vector3 windDirection = Vector3.left;
    [SerializeField]
    private float windSpeed = 100;
    [SerializeField]
    private bool randomizeWindStrength = false;
    private List<Rigidbody> ballList = new List<Rigidbody>();

    public float WindSpeed
    {
        get => windSpeed;
        set => windSpeed = value;
    }
    public static bool windActive = false;

    void FixedUpdate () {
        if (windActive)
        {
            foreach (var ball in ballList)
            {
                ball.AddForce(CalculateForce());
                Debug.Log("Adding force");
            }
        }
    }

    public Vector3 CalculateForce()
    {
        return windDirection * (windSpeed * Time.fixedDeltaTime);
    }

    public void RandomWindStrength()
    {
        windSpeed = Random.Range(minSpeed,maxSpeed);

        if (Random.Range(0, 2) < 1)
        {
            windSpeed *= -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        Debug.Log("TRIGGER ENTER");
        if (ball && !ballList.Contains(ball.RigidbodyComponent))
        {
            ballList.Add(ball.RigidbodyComponent);
            Debug.Log("ADDING BALL");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        if (ball && ballList.Contains(ball.RigidbodyComponent))
        {
            ballList.Remove(ball.RigidbodyComponent);
            Debug.Log("REMOVING BALL");
        }
    }
}
