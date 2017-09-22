using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    [SerializeField]
    private float minSpeed = 0f;
    [SerializeField]
    private float maxSpeed = 100f;
    [SerializeField]
    private Rigidbody ball;
    public float windSpeed = 1f;
    public static bool windActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(windActive)
            ball.AddForce(Vector3.left * windSpeed * Time.deltaTime);
	}

    public void RandomWindStrength()
    {
        windSpeed = Random.Range(minSpeed,maxSpeed);

        if (Random.Range(0, 2) < 1)
        {
            //make negative (wind in opposite direction
            windSpeed *= -1;
        }
    }
}
