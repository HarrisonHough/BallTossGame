using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Mouse Flick Input Class 
*/

public class MouseFlickInput : MonoBehaviour {

    [SerializeField]
    private Ball ball;

    [SerializeField]
    Vector3 startPoint;
    [SerializeField]
    Vector3 endPoint;
    private bool grabbed = false;

    private float touchTimer = 0f;

    private const string PlayerTag = "Player";
    
    void Start()
    {
        //TODO refactor
        if (ball == null)
        {
            ball = FindObjectOfType<Ball>();
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag.Contains(PlayerTag))
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
        deltaPos.y +=  touchTimer;
        
        deltaPos = -deltaPos;
        ball.Shoot(deltaPos);
    }
}
