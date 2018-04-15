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

    private float touchTimer = 0f;

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
                    touchTimer = 0f;
                }
            }

        }
        else if (Input.GetMouseButtonUp(0) && grabbed)
        {

            Release();
            grabbed = false;
        }

        if (Input.GetMouseButton(0))
        {
            touchTimer += Time.deltaTime;
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
        deltaPos.x = deltaPos.x.Remap(0, Screen.width, 0,1);
        deltaPos.y = deltaPos.y.Remap(0, Screen.height, 0, 1);

        Debug.Log("touch timer = " + (1 - touchTimer));
        //deltaPos.x +=  touchTimer;
        deltaPos.y +=  touchTimer;

        //Debug.Log("DeltaX = " + deltaPos.x);
        //Debug.Log("DeltaY = " + deltaPos.y);
        deltaPos = -deltaPos;
        ball.Shoot(deltaPos);
    }
}
