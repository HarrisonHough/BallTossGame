using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    private float xForceScale = 1f;
    [SerializeField]
    private float yForceScale = 1f;
    [SerializeField]
    private float zForceScale = 1f;

    public float power = 50f;
    Rigidbody rb;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
	}

    public void Shoot()
    {
        rb.useGravity = true;
        Vector3 direction = new Vector3(0,1*yForceScale,1 * zForceScale);
        
        rb.AddForce(direction);

    }

    public void Shoot2(Vector3 force)
    {
     
        //z ignored
        rb.useGravity = true;
        //Vector3 direction = new Vector3(force.x * power, force.y * power, -force.y * power);

        //rb.AddForce(Camera.main.transform.TransformDirection(direction));
        //rb.AddForce(transform.TransformDirection(direction));
        //rb.AddForce(force.x * power, force.y * power, -force.y * power, ForceMode.Impulse);
        
        rb.AddForce(transform.forward * force.y * power);
        rb.AddForce(transform.up * force.y * power);
        rb.AddForce(transform.right * force.x * power);
        Wind.windActive = true;

        //TODO remove later
        GetComponent<BallRecycle>().StartRecycle();
    }

    public void Shoot(Vector3 force)
    {
        //z ignored
        rb.useGravity = true;
        Vector3 direction = new Vector3(force.x * xForceScale * power , force.y * yForceScale * power, force.y * zForceScale * power);
        
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            GameManager.Instance.UpdateScore();
        }
    }

}
