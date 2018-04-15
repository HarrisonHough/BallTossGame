﻿using UnityEngine;
using System.Collections;

public static class CustomExtensions {


    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="from1"></param>
    /// <param name="to1"></param>
    /// <param name="from2"></param>
    /// <param name="to2"></param>
    /// <returns></returns>
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        //EG Debug.Log(2.Remap(1, 3, 0, 10));    // 5
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }


    
}

