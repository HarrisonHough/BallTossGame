using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    protected Vector3 startPoint;
    protected Vector3 endPoint;
    protected float touchDuration = 0f;

    public static Action<float, Vector3> OnTouchRelease;
    public static Action<Vector3> OnTouchStart;
    
    protected virtual void Update()
    {
        HandleTouches();

    }
    protected virtual void HandleTouches()
    {
        var touches = Input.touches;
        for (int i = 0; i < touches.Length; i++)
        {
            HandleTouch(touches[0]);
        }
    }

    protected virtual void HandleTouch(Touch touch)
    {
        TouchHold();
        if (touch.phase == TouchPhase.Began)
        {
            TouchStart(touch.position);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            endPoint = touch.position;
            TouchRelease(touch.position);
        }
    }

    protected virtual void TouchStart(Vector3 touchPosition)
    {
        startPoint = touchPosition;
        touchDuration = 0f;
    }

    protected virtual void TouchRelease(Vector3 touchPosition)
    {
        endPoint = touchPosition;
    }

    protected virtual void TouchHold()
    {
        touchDuration += Time.deltaTime;
    }

    protected Vector3 CalculateDelta()
    {
        endPoint = Input.mousePosition;
        Vector3 deltaPos = endPoint - startPoint;
        return deltaPos;
    }
}
