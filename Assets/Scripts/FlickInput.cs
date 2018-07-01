using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickInput : MonoBehaviour
{
    [SerializeField]
    private Ball ball;

    // Use this for initialization
    void Start () {

        if (ball == null)
        {
            ball = FindObjectOfType<Ball>();
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            Grab();

        }
        else if(Input.GetMouseButtonUp(0)) {

            Release();

        }
	}


    private void Grab()
    {
        
    }

    private void Release() {
        ball.Shoot();
    }
}
