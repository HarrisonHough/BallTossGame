using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickInput : TouchInput
{
    private bool ballIsGrabbed = false;
    public static Ball activeBall;
    // Update is called once per frame
    protected override void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseInput();
#else
        HandleTouches();
#endif
    }
    
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchStart(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            TouchRelease(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            TouchHold();
        }
    }
    
    protected override void HandleTouches()
    {
        var touches = Input.touches;
        if (touches.Length > 0)
        {
            HandleTouch(touches[0]);
        }
    }

    protected override void TouchStart(Vector3 touchPosition)
    {
        base.TouchStart(touchPosition);
        activeBall = null;
        Ray ray = Camera.main.ScreenPointToRay(startPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag.Contains("Player"))
            {
                activeBall = hit.transform.gameObject.GetComponent<Ball>();
                ballIsGrabbed = true;
            }
        }
    }

    protected override void TouchRelease(Vector3 touchPosition)
    {
        ballIsGrabbed = false;
        var deltaPosition = CalculateDelta();
        deltaPosition.x = deltaPosition.x.Remap(0, Screen.width, 0,1);
        deltaPosition.y = deltaPosition.y.Remap(0, Screen.height, 0, 1);
        deltaPosition.y +=  touchDuration;
        if (activeBall != null)
        {
            activeBall.Shoot(deltaPosition);
        }
    }
}
