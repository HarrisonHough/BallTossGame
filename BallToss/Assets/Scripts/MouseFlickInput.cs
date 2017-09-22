using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFlickInput : MonoBehaviour {

    [SerializeField]
    private Ball ball;

    [SerializeField]
    Vector3 startPoint;
    [SerializeField]
    Vector3 endPoint;
    private bool grabbed = false;

    // Use this for initialization
    void Start()
    {

        if (ball == null)
        {
            ball = FindObjectOfType<Ball>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    grabbed = true;
                    Grab();
                }
            }

        }
        else if (Input.GetMouseButtonUp(0) && grabbed)
        {

            Release();
            grabbed = false;
        }
    }


    private void Grab()
    {
        startPoint = Input.mousePosition;
    }

    private void Release()
    {
        endPoint = Input.mousePosition;
        Vector3 deltaPos = startPoint - endPoint;
        deltaPos = -deltaPos;
        ball.Shoot(deltaPos);
    }
}
