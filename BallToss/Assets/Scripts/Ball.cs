using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    private float yForce = 100f;
    [SerializeField]
    private float zForce = 100f;

    public float power = 50f;
    Rigidbody rb;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
	}

    public void Shoot()
    {
        rb.useGravity = true;
        Vector3 direction = new Vector3(0,1*yForce,1 * zForce);
        rb.AddForce(direction);

    }

    public void Shoot(Vector3 force)
    {
        //z ignored
        rb.useGravity = true;
        Vector3 direction = new Vector3(force.x * power, force.y * power, force.y * power);
        rb.AddForce(direction);
        Wind.windActive = true;
        //TODO remove later
        GetComponent<BallRecycle>().StartRecycle();
    }

    public void DisableGravity()
    {
        Wind.windActive = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Wind.windActive = false;
    }

}
