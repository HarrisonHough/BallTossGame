using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRecycle : MonoBehaviour {

    Vector3 startPosition;
    Quaternion startRotation;
    public float recycleTime = 3f;
    Ball ball;
	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
        startPosition = transform.position;
        startRotation = transform.rotation;
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
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
