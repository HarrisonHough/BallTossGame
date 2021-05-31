using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Ball Recycle Class 
*/

public class BallRecycle : MonoBehaviour {

    Vector3 startPosition;
    Quaternion startRotation;
    public float recycleTime = 3f;
    Rigidbody rigidbody;
    Ball ball;
	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
        startPosition = transform.position;
        startRotation = transform.rotation;
        rigidbody = GetComponent<Rigidbody>();
	}

    public void StartRecycle()
    {
        StartCoroutine(RecycleTimer());
    }

    IEnumerator RecycleTimer()
    {

        yield return new WaitForSeconds(recycleTime);
        Recycle();

    }

    void Recycle()
    {
        ball.DisableGravity();
        rigidbody.angularVelocity = Vector3.zero;
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
