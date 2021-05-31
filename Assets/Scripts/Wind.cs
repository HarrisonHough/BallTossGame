using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Wind Class 
*/

public class Wind : MonoBehaviour {

    [SerializeField]
    private float minSpeed = 0f;
    [SerializeField]
    private float maxSpeed = 100f;
    [SerializeField]
    private Rigidbody ball;

    private float windSpeed;
    public float WindSpeed
    {
        get => windSpeed;
        set => windSpeed = value;
    }
    public static bool windActive = false;

    void FixedUpdate () {
        if (windActive)
        {
            ball.AddForce(Vector3.left * (windSpeed * Time.deltaTime));
        }
    }

    public void RandomWindStrength()
    {
        windSpeed = Random.Range(minSpeed,maxSpeed);

        if (Random.Range(0, 2) < 1)
        {
            windSpeed *= -1;
        }
    }
}
